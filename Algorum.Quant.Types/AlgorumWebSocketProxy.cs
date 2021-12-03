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
   public class AlgorumWebSocketProxy
   {
      protected delegate Task MessageHandlerAsync( AlgorumWebSocketMessage message );

      protected WebSocket _webSocket;
      protected WebSocket _webSocketRemote;
      protected HttpContext _context;

      public AlgorumWebSocketProxy( HttpContext httpContext, WebSocket webSocket, string newBasePath )
      {
         _context = httpContext;
         _webSocket = webSocket;

         ConnectAsync( newBasePath ).Wait();
      }

      protected virtual async Task OnCloseAsync()
      {
         await _webSocketRemote.CloseAsync( WebSocketCloseStatus.NormalClosure, "Proxy closed", CancellationToken.None );
      }

      public async Task ConnectAsync( string newBasePath )
      {
         ClientWebSocket webSocket = new ClientWebSocket();

         /*
          * REVISIT::
         foreach ( var header in _context.Request.Headers )
         {
            if ( !header.Key.ToLower().Contains( "Sec-Websocket-Accept" ) )
               webSocket.Options.SetRequestHeader( header.Key, header.Value );
         }
         */

         var uri = $"{newBasePath}{_context.Request.Path}{_context.Request.QueryString}";

         Console.WriteLine( $"Proxying to URI {uri}" );

         await webSocket.ConnectAsync( new Uri( uri ), CancellationToken.None );

         _webSocketRemote = webSocket;

         _ = Task.Run( async () => await ProcessRemoteMessagesAsync() );
      }

      public async Task CloseAsync()
      {
         await _webSocket.CloseAsync( WebSocketCloseStatus.NormalClosure, "User closed", CancellationToken.None );
      }

      public async Task ProcessRemoteMessagesAsync()
      {
         try
         {
            var cancelToken = new CancellationTokenSource().Token;
            var (response, messageBytes) = await ReceiveFullMessageAsync( _webSocketRemote, cancelToken );

            while ( !response.CloseStatus.HasValue )
            {
               var messageBytesTemp = messageBytes;
               await _webSocket.SendAsync( new ReadOnlyMemory<byte>( messageBytes.ToArray() ), WebSocketMessageType.Text, true, CancellationToken.None );
               (response, messageBytes) = await ReceiveFullMessageAsync( _webSocketRemote, cancelToken );
            }

            await _webSocketRemote.CloseAsync( response.CloseStatus.Value, response.CloseStatusDescription, CancellationToken.None );
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

      public async Task ProcessMessagesAsync()
      {
         try
         {
            var cancelToken = new CancellationTokenSource().Token;
            var (response, messageBytes) = await ReceiveFullMessageAsync( _webSocket, cancelToken );

            while ( !response.CloseStatus.HasValue )
            {
               var messageBytesTemp = messageBytes;
               await _webSocketRemote.SendAsync( new ReadOnlyMemory<byte>( messageBytes.ToArray() ), WebSocketMessageType.Text, true, CancellationToken.None );
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

      private async Task<(WebSocketReceiveResult, List<byte>)> ReceiveFullMessageAsync( WebSocket socket, CancellationToken cancelToken )
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
