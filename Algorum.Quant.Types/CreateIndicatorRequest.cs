using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorum.Quant.Types
{
   public class CreateIndicatorRequest
   {
      public Symbol Symbol
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
   }
}
