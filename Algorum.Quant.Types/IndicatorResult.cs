using System;
using System.Collections.Generic;
using System.Text;

namespace Algorum.Quant.Types
{
   public class IndicatorResult
   {
      public string Indicator
      {
         get;
         set;
      }

      public DateTime Timestamp
      {
         get;
         set;
      }

      public Dictionary<string, double> ParamMap
      {
         get;
         set;
      }

      public bool HasResultMap
      {
         get;
         set;
      }

      public Dictionary<string, double> ResultMap
      {
         get;
         set;
      }

      public double Result
      {
         get;
         set;
      }
   }
}
