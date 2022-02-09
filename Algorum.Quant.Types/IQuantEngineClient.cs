using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Algorum.Quant.Types
{
   public interface IQuantEngineClient
   {
      Task OnOrderUpdateAsync( Order order );
      Task OnTickAsync( TickData tickData );
      Task<string> OnCustomEventAsync( string eventData );
      Task OnStopAsync();

      Task<string> PlaceOrderAsync( PlaceOrderRequest placeOrderRequest );
      Task SubscribeSymbolsAsync( List<Symbol> symbols );
      Task UnsubscribeSymbolsAsync( List<Symbol> symbols );
      Task<RemoteIndicatorEvaluator> CreateIndicatorEvaluatorAsync( CreateIndicatorRequest createIndicatorRequest );
      Task<string> GetDataAsync( string key );
      Task SetDataAsync<T>( string key, T value );
      Task LogAsync( LogLevel logLevel, string message );
      Task<string> BacktestAsync( BacktestRequest backtestRequest );
      Task StartTradingAsync( TradingRequest tradingRequest );
      Task StopTradingAsync();
      Task<List<DateTime>> GetHolidaysAsync( TradeExchange exchange );
      void Wait();
      Task<StrategyRunSummary> GetStrategyRunSummaryAsync( double capital, List<KeyValuePair<Symbol, TickData>> symbolLastTicks );
   }
}
