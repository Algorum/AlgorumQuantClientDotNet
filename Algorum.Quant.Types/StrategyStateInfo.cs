using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorum.Quant.Types
{
   public class StrategyStateInfo
   {
      public string Key
      {
         get;
         set;
      }

      public double SizeBytes
      {
         get;
         set;
      }

      public DateTime LastWrittenTime
      {
         get;
         set;
      }
   }
}
