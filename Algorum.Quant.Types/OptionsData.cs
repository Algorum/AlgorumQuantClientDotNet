using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorum.Quant.Types
{
   public class OptionsData
   {
      public Symbol Symbol
      {
         get;
         set;
      }

      public DateTime LastTradeTime
      {
         get;
         set;
      }

      public DateTime ServerTime
      {
         get;
         set;
      }

      public double LTP
      {
         get;
         set;
      }

      public double Bid
      {
         get;
         set;
      }

      public double Ask
      {
         get;
         set;
      }

      public double OpenInterest
      {
         get;
         set;
      }

      public double OpenInterestChange
      {
         get;
         set;
      }
   }
}
