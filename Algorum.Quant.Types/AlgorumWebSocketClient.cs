using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Algorum.Quant.Types
{
   public class AlgorumWebSocketClient
   {
      protected delegate Task MessageHandlerAsync( AlgorumWebSocketMessage message );

      protected WebSocket _webSocket;
      protected HttpContext _context;
      protected string _userId;

      protected ConcurrentDictionary<string, AutoResetEvent> _callMap = new ConcurrentDictionary<string, AutoResetEvent>();
      protected ConcurrentDictionary<string, AlgorumWebSocketMessage> _msgMap = new ConcurrentDictionary<string, AlgorumWebSocketMessage>();
      private Dictionary<string, MessageHandlerAsync> _messageHandlerMap = new Dictionary<string, MessageHandlerAsync>();
      public AlgorumWebSocketClient( HttpContext httpContext, WebSocket webSocket, string userId )
      {
         _context = httpContext;
         _webSocket = webSocket;
         _userId = userId;
      }

      public AlgorumWebSocketClient()
      {
         // No-Op
      }

      protected void AddMessageHandler( string name, MessageHandlerAsync handler )
      {
         _messageHandlerMap[name] = handler;
      }

      protected virtual async Task OnCloseAsync()
      {
         _messageHandlerMap.Clear();
      }

      private async Task HandleMessageAsync( AlgorumWebSocketMessage message )
      {
         MessageHandlerAsync handler;

         if ( _messageHandlerMap.TryGetValue( message.Name.ToLower(), out handler ) )
            await handler( message );
      }

      public async Task ConnectAsync( string uri, string userId, string securityToken )
      {
         ClientWebSocket webSocket = new ClientWebSocket();

         if ( !string.IsNullOrWhiteSpace( securityToken ) )
            webSocket.Options.SetRequestHeader( "Authorization", $"Bearer {securityToken}" );

         webSocket.Options.SetRequestHeader( "x-algorum-userid", userId );

         await webSocket.ConnectAsync( new Uri( uri ), CancellationToken.None );

         _webSocket = webSocket;

         _ = Task.Run( async () => await ProcessMessagesAsync() );
      }

      public async Task CloseAsync()
      {
         await _webSocket.CloseAsync( WebSocketCloseStatus.NormalClosure, "User closed", CancellationToken.None );
      }

      public async Task ProcessMessagesAsync()
      {
         try
         {
            var cancelToken = new CancellationTokenSource().Token;
            var (response, messageBytes) = await ReceiveFullMessageAsync( _webSocket, cancelToken );

            while ( !response.CloseStatus.HasValue )
            {
               var messageBytesTemp = messageBytes;
               _ = Task.Run( async () => await ProcessMessageAsync( messageBytesTemp ) );
               (response, messageBytes) = await ReceiveFullMessageAsync( _webSocket, cancelToken );
            }

            await _webSocket.CloseAsync( response.CloseStatus.Value, response.CloseStatusDescription, CancellationToken.None );
         }
         catch ( WebSocketException wsx )
         {
            Console.WriteLine( wsx.ToString() );
         }
         finally
         {
            await OnCloseAsync();
         }
      }

      public async Task SendAsync<T>( string name, T obj )
      {
         var msg = JsonConvert.SerializeObject( new AlgorumWebSocketMessage()
         {
            Name = name,
            MessageType = AlgorumMessageType.Oneway,
            JsonData = JsonConvert.SerializeObject( obj, new StringEnumConverter() )
         }, new StringEnumConverter() );

         await _webSocket.SendAsync( new ArraySegment<byte>( Encoding.UTF8.GetBytes( msg ) ), WebSocketMessageType.Text, true, CancellationToken.None );
      }

      public async Task SendAsync( AlgorumWebSocketMessage agMessage )
      {
         var msg = JsonConvert.SerializeObject( agMessage, new StringEnumConverter() );

         await _webSocket.SendAsync( new ArraySegment<byte>( Encoding.UTF8.GetBytes( msg ) ), WebSocketMessageType.Text, true, CancellationToken.None );
      }

      public async Task SendResponseObjectAsync<T>( AlgorumWebSocketMessage message, T response )
      {
         await SendAsync( new AlgorumWebSocketMessage()
         {
            Name = message.Name,
            CorId = message.CorId,
            JsonData = JsonConvert.SerializeObject( response, new StringEnumConverter() ),
            MessageType = AlgorumMessageType.Response
         } );
      }

      public async Task SendResponseAsync( AlgorumWebSocketMessage message )
      {
         await SendAsync( new AlgorumWebSocketMessage()
         {
            Name = message.Name,
            CorId = message.CorId,
            JsonData = JsonConvert.SerializeObject( null, new StringEnumConverter() ),
            MessageType = AlgorumMessageType.Response
         } );
      }

      public async Task SendErrorResponseAsync( Exception ex, AlgorumWebSocketMessage message )
      {
         await SendAsync( new AlgorumWebSocketMessage()
         {
            Name = message.Name,
            CorId = message.CorId,
            JsonData = JsonConvert.SerializeObject( null, new StringEnumConverter() ),
            MessageType = AlgorumMessageType.ErrorResponse,
            Error = new AlgorumWebSocketError()
            {
               ErrorCode = ex.HResult,
               ErrorMessage = ex.Message,
               ErrorStackTrace = ex.StackTrace
            }
         } );
      }

      public async Task SendErrorResponseAsync( int errorCode, string errorMessage, string errorStackTrace, AlgorumWebSocketMessage message )
      {
         await SendAsync( new AlgorumWebSocketMessage()
         {
            Name = message.Name,
            CorId = message.CorId,
            JsonData = JsonConvert.SerializeObject( null, new StringEnumConverter() ),
            MessageType = AlgorumMessageType.ErrorResponse,
            Error = new AlgorumWebSocketError()
            {
               ErrorCode = errorCode,
               ErrorMessage = errorMessage,
               ErrorStackTrace = errorStackTrace
            }
         } );
      }

      public async Task<R> ExecuteAsync<T, R>( string messageName, T request )
      {
         var corid = Guid.NewGuid().ToString();
         var syncObj = new AutoResetEvent( false );

         try
         {
            if ( !_callMap.TryAdd( corid, syncObj ) )
               throw new ApplicationException( $"Failed to all request to call map. msg {messageName}, corid {corid}" );

            var agMessage = new AlgorumWebSocketMessage()
            {
               Name = messageName,
               MessageType = AlgorumMessageType.Request,
               CorId = corid,
               JsonData = JsonConvert.SerializeObject( request, new StringEnumConverter() )
            };

            await SendAsync( agMessage );

            syncObj.WaitOne();

            var agResult = _msgMap[corid];

            if ( agResult != null )
            {
               if ( agResult.MessageType == AlgorumMessageType.ErrorResponse )
                  throw new ApplicationException( agResult.Error.ErrorMessage );

               if ( !string.IsNullOrWhiteSpace( agResult.JsonData ) )
                  return JsonConvert.DeserializeObject<R>( agResult.JsonData );
               else
                  return default( R );
            }
            else
            {
               return default( R );
            }
         }
         finally
         {
            if ( _callMap.TryRemove( corid, out syncObj ) )
               syncObj.Dispose();

            AlgorumWebSocketMessage msg;
            _msgMap.TryRemove( corid, out msg );
         }
      }

      public async Task ExecuteAsync<T>( string messageName, T request )
      {
         var corid = Guid.NewGuid().ToString();
         var syncObj = new AutoResetEvent( false );

         try
         {
            if ( !_callMap.TryAdd( corid, syncObj ) )
               throw new ApplicationException( $"Failed to all request to call map. msg {messageName}, corid {corid}" );

            var agMessage = new AlgorumWebSocketMessage()
            {
               Name = messageName,
               MessageType = AlgorumMessageType.Request,
               CorId = corid,
               JsonData = JsonConvert.SerializeObject( request, new StringEnumConverter() )
            };

            await SendAsync( agMessage );

            syncObj.WaitOne();

            var agResult = _msgMap[corid];

            if ( agResult != null )
            {
               if ( agResult.MessageType == AlgorumMessageType.ErrorResponse )
                  throw new ApplicationException( agResult.Error.ErrorMessage );
            }
         }
         finally
         {
            if ( _callMap.TryRemove( corid, out syncObj ) )
               syncObj.Dispose();

            AlgorumWebSocketMessage msg;
            _msgMap.TryRemove( corid, out msg );
         }
      }

      public async Task<R> ExecuteAsync<R>( string messageName )
      {
         var corid = Guid.NewGuid().ToString();
         var syncObj = new AutoResetEvent( false );

         try
         {
            if ( !_callMap.TryAdd( corid, syncObj ) )
               throw new ApplicationException( $"Failed to all request to call map. msg {messageName}, corid {corid}" );

            var agMessage = new AlgorumWebSocketMessage()
            {
               Name = messageName,
               MessageType = AlgorumMessageType.Request,
               CorId = corid
            };

            await SendAsync( agMessage );

            syncObj.WaitOne();

            var agResult = _msgMap[corid];

            if ( agResult != null )
            {
               if ( agResult.MessageType == AlgorumMessageType.ErrorResponse )
                  throw new ApplicationException( agResult.Error.ErrorMessage );

               if ( !string.IsNullOrWhiteSpace( agResult.JsonData ) )
                  return JsonConvert.DeserializeObject<R>( agResult.JsonData );
               else
                  return default( R );
            }
            else
            {
               return default( R );
            }
         }
         finally
         {
            if ( _callMap.TryRemove( corid, out syncObj ) )
               syncObj.Dispose();

            AlgorumWebSocketMessage msg;
            _msgMap.TryRemove( corid, out msg );
         }
      }

      protected virtual async Task ProcessMessageAsync( AlgorumWebSocketMessage message )
      {
         await HandleMessageAsync( message );
      }

      private async Task ProcessMessageAsync( IEnumerable<byte> messageBytes )
      {
         try
         {
            var messageString = Encoding.UTF8.GetString( messageBytes.ToArray() );

            var agMessage = JsonConvert.DeserializeObject<AlgorumWebSocketMessage>( messageString );

            if ( agMessage == null )
               return;

            if ( !string.IsNullOrWhiteSpace( agMessage.CorId ) &&
               ( ( agMessage.MessageType == AlgorumMessageType.Response ) || ( agMessage.MessageType == AlgorumMessageType.ErrorResponse ) ) )
            {
               _msgMap.TryAdd( agMessage.CorId, agMessage );

               if ( _callMap.ContainsKey( agMessage.CorId ) )
                  _callMap[agMessage.CorId].Set();
               else
                  Console.WriteLine( $"ERROR: NO CallMap entry found. {agMessage.CorId}, {agMessage.Name}, {agMessage.JsonData}" );
            }
            else
            {
               await ProcessMessageAsync( agMessage );
            }
         }
         catch ( Exception ex )
         {
            Console.WriteLine( ex.ToString() );
         }
      }

      private async Task<(WebSocketReceiveResult, IEnumerable<byte>)> ReceiveFullMessageAsync( WebSocket socket, CancellationToken cancelToken )
      {
         WebSocketReceiveResult response;
         var message = new List<byte>();

         var buffer = new byte[1024 * 32];
         do
         {
            response = await socket.ReceiveAsync( new ArraySegment<byte>( buffer ), cancelToken );
            message.AddRange( new ArraySegment<byte>( buffer, 0, response.Count ) );
         } while ( !response.EndOfMessage );

         return (response, message);
      }

   }
}
