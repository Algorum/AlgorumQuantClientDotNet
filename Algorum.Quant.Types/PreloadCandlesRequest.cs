using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorum.Quant.Types
{
   public class PreloadCandlesRequest
   {
      public string IndicatorUid
      {
         get;
         set;
      }

      public DateTime PreloadEndTime
      {
         get;
         set;
      }

      public int CandleCount
      {
         get;
         set;
      }

      public string ApiKey
      {
         get;
         set;
      }

      public string ApiSecretKey
      {
         get;
         set;
      }
   }
}
