using System;
using System.Collections.Generic;
using System.Text;

namespace Algorum.Quant.Types
{
   public class IndicatorRequest
   {
      public string Indicator
      {
         get;
         set;
      }

      public bool CustomPeriod
      {
         get;
         set;
      }

      public CandlePeriod CandlePeriod
      {
         get;
         set;
      }

      public int PeriodSpan
      {
         get;
         set;
      }

      public List<Ohlcv> Candles
      {
         get;
         set;
      }

      public Dictionary<string, double> ParamMap
      {
         get;
         set;
      }
   }
}
