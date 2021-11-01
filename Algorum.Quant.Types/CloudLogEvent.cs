using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorum.Quant.Types
{
   public class CloudLogEvents
   {
      public List<string> Messages
      {
         get;
         set;
      }

      public string NextToken
      {
         get;
         set;
      }
   }
}
