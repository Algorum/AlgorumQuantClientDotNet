using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorum.Quant.Types
{
   public class TickData
   {
      public string Id
      {
         get;
         set;
      }

      public DateTime Date
      {
         get;
         set;
      }


      public DateTime Timestamp
      {
         get;
         set;
      }

      public double LTP
      {
         get;
         set;
      }

      public double LTQ
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

      public bool LastTick
      {
         get;
         set;
      }

      public bool DayLastTick
      {
         get;
         set;
      }

      public Symbol Symbol
      {
         get;
         set;
      }

      public double OpenInterest
      {
         get;
         set;
      }
   }
}
