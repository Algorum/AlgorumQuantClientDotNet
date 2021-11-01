using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Algorum.Quant.Types
{
   public abstract class QuantEngineClient : AlgorumWebSocketClient, IQuantEngineClient
   {
      private const double MultiplyFactor = ( (double) ( 60 * 24 ) / (double) 405 );

      private AutoResetEvent _stopEvent = new AutoResetEvent( false );
      private BlockingCollection<TickData> _ticks = new BlockingCollection<TickData>( new ConcurrentQueue<TickData>() );
      private CancellationTokenSource _tickTaskCancelTokenSource = new CancellationTokenSource();
      private TickData _lastProgressTick;
      private double _progressPercent;

      public StrategyLaunchMode LaunchMode
      {
         get;
         protected set;
      }

      public DateTime BacktestStartDate
      {
         get;
         protected set;
      }

      public DateTime BacktestEndDate
      {
         get;
         protected set;
      }

      public string StrategyId
      {
         get;
         protected set;
      }

      public QuantEngineClient( string url, string apiKey, StrategyLaunchMode launchMode, string sid )
      {
         LaunchMode = launchMode;
         StrategyId = sid;

         AddMessageHandler( "tick", TickHandlerAsync );
         AddMessageHandler( "order_update", OrderUpdateHandlerAsync );
         AddMessageHandler( "stop", StopHandlerAsync );

         Initialize( url );

         /*
         _ = Task.Run( async () =>
         {
            while ( true )
            {
               TickData tickData = _ticks.Take();

               if ( tickData != null )
                  await OnTickHandlerAsync( tickData );
            }
         }, _tickTaskCancelTokenSource.Token );
         */
      }

      protected override async Task OnCloseAsync()
      {
         await base.OnCloseAsync();

         _tickTaskCancelTokenSource.Cancel();
         _stopEvent.Set();
      }

      private async Task StopHandlerAsync( AlgorumWebSocketMessage message )
      {
         await OnStopAsync();
         await SendResponseAsync( message );
      }

      private async Task OrderUpdateHandlerAsync( AlgorumWebSocketMessage message )
      {
         var order = JsonConvert.DeserializeObject<Order>( message.JsonData );
         await OnOrderUpdateAsync( order );
         await SendResponseAsync( message );
      }

      private async Task TickHandlerAsync( AlgorumWebSocketMessage message )
      {
         var tickData = JsonConvert.DeserializeObject<TickData>( message.JsonData );

         //_ticks.Add( tickData );

         if ( tickData != null )
         {
            lock ( this )
               OnTickHandlerAsync( tickData ).Wait();
         }

         await SendResponseAsync( message );
      }

      private void Initialize( string url )
      {
         ConnectAsync( url ).Wait();
      }

      public async Task LogAsync( LogLevel logLevel, string message )
      {
         await SendAsync( "log", new
         {
            LogLevel = logLevel,
            Message = message
         } );
      }

      public async Task<RemoteIndicatorEvaluator> CreateIndicatorEvaluatorAsync( CreateIndicatorRequest createIndicatorRequest )
      {
         var uid = await ExecuteAsync<CreateIndicatorRequest, string>( "create_indicator_evaluator", createIndicatorRequest );

         var remoteIndicatorEval = new RemoteIndicatorEvaluator( this, uid, createIndicatorRequest.Symbol );
         return remoteIndicatorEval;
      }

      public async Task<string> GetDataAsync( string key )
      {
         return await ExecuteAsync<string, string>( "get_data", key );
      }

      public async Task<T> GetDataAsync<T>( string key )
      {
         var val = await ExecuteAsync<string, string>( "get_data", key );

         if ( !string.IsNullOrWhiteSpace( val ) )
            return JsonConvert.DeserializeObject<T>( val );

         return default( T );
      }

      public async Task<string> PlaceOrderAsync( PlaceOrderRequest placeOrderRequest )
      {
         return await ExecuteAsync<PlaceOrderRequest, string>( "place_order", placeOrderRequest );
      }

      public async Task SetDataAsync<T>( string key, T value )
      {
         try
         {
            string val = string.Empty;

            lock ( value )
               val = JsonConvert.SerializeObject( value );

            await ExecuteAsync( "set_data", new QuantData() { Key = key, Value = val } );
         }
         catch ( Exception ex )
         {
            Console.WriteLine( ex );
         }
      }

      public async Task SubscribeSymbolsAsync( List<Symbol> symbols )
      {
         await ExecuteAsync( "sub_symbols", symbols );
      }

      public async Task UnsubscribeSymbolsAsync( List<Symbol> symbols )
      {
         await ExecuteAsync( "unsub_symbols", symbols );
      }

      public virtual async Task<string> BacktestAsync( DateTime startDate, DateTime endDate, string bkApiKey, string bkApiSecretKey, int samplingTimeInSeconds )
      {
         BacktestStartDate = startDate;
         BacktestEndDate = endDate;

         return await ExecuteAsync<BacktestRequest, string>( "backtest", new BacktestRequest()
         {
            StartDate = startDate,
            EndDate = endDate,
            Uid = Guid.NewGuid().ToString(),
            ApiKey = bkApiKey,
            ApiSecretKey = bkApiSecretKey,
            SamplingTimeInSeconds = samplingTimeInSeconds
         } );
      }

      public virtual async Task<string> BacktestAsync( BacktestRequest backtestRequest )
      {
         backtestRequest.Uid = Guid.NewGuid().ToString();

         BacktestStartDate = backtestRequest.StartDate;
         BacktestEndDate = backtestRequest.EndDate;

         return await ExecuteAsync<BacktestRequest, string>( "backtest", backtestRequest );
      }

      public virtual async Task StartTradingAsync( TradingRequest tradingRequest )
      {
         await ExecuteAsync( "start_trading", tradingRequest );
      }

      public virtual async Task StopTradingAsync()
      {
         await ExecuteAsync<string>( "stop_trading" );
      }

      public virtual Dictionary<string, object> GetStats( TickData tickData )
      {
         return null;
      }

      public virtual async Task SendProgressAsync( TickData tickData )
      {
         if ( LaunchMode == StrategyLaunchMode.Backtesting )
         {
            var totalSeconds = ( BacktestEndDate - BacktestStartDate ).TotalSeconds * ( (double) 70 / 100 );
            var processedSeconds = ( tickData.Timestamp - _lastProgressTick.Timestamp ).TotalSeconds * MultiplyFactor;

            var progressPercent = ( processedSeconds / totalSeconds ) * 100;

            if ( ( _progressPercent + progressPercent >= 100 ) && !tickData.LastTick )
               progressPercent = 0;
            else if ( tickData.LastTick )
               _progressPercent = 100;

            if ( progressPercent >= 0.1 || progressPercent == 0 || tickData.LastTick )
            {
               if ( !tickData.LastTick )
                  _progressPercent += progressPercent;

               await SendAsync( "publish_progress", _progressPercent );

               var stats = GetStats( tickData );
               await SendAsync( "publish_stats", stats );

               // DIAG::
               Console.WriteLine( $"Progress: {_progressPercent:N2}" );

               foreach ( var kvp in stats )
                  Console.WriteLine( $"{kvp.Key}: {kvp.Value}" );

               _lastProgressTick = tickData;
            }

            if ( _progressPercent >= 100 )
            {
               await Task.Delay( 5000 );
               await OnCloseAsync();
            }
         }
         else
         {
            var stats = GetStats( tickData );
            await SendAsync( "publish_stats", stats );
         }
      }

      public abstract Task OnOrderUpdateAsync( Order order );
      public abstract Task OnTickAsync( TickData tickData );

      public async Task OnTickHandlerAsync( TickData tickData )
      {
         if ( ( _lastProgressTick == null ) || ( _lastProgressTick.Timestamp.Day != tickData.Timestamp.Day ) )
            _lastProgressTick = tickData;

         await OnTickAsync( tickData );
      }

      public abstract Task<string> OnCustomEventAsync( string eventData );

      public async Task OnStopAsync()
      {
         _stopEvent.Set();
      }

      public void Wait()
      {
         // Wait until we are stopped
         _stopEvent.WaitOne();
      }
   }
}
