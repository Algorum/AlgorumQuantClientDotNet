using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorum.Quant.Types
{
   public interface IQuantEngine
   {
      Task<string> PlaceOrderAsync( PlaceOrderRequest placeOrderRequest );
      Task<IIndicatorEvaluator> GetTechnicalIndicatorEvaluatorAsync( Symbol symbol, CandlePeriod candlePeriod, int periodSpan );
      Task StoreAsync( string state );
      Task SubscribeAsync( List<Symbol> symbols );
      Task UnsubscribeAsync( List<Symbol> symbols );
      bool IsBacktesting();
      Task SetAccessToken( string accessToken );
   }
}
