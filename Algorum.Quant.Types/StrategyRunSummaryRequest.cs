using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorum.Quant.Types
{
   public class StrategyRunSummaryRequest
   {
      public double Capital
      {
         get;
         set;
      }

      public List<KeyValuePair<Symbol, TickData>> SymbolLastTicks
      {
         get;
         set;
      }

      public StatsType StatsType
      {
         get;
         set;
      }

      public int OrderCount
      {
         get;
         set;
      }
   }
}
