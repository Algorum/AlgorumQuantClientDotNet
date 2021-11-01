using System;
using System.Collections.Generic;
using System.Text;

namespace Algorum.Quant.Types
{
   public class GetIndicatorsRequest
   {
      public string IndicatorUid
      {
         get;
         set;
      }

      public List<IndicatorRequest> IndicatorRequests
      {
         get;
         set;
      }
   }
}
