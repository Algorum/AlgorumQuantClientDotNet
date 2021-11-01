using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorum.Quant.Types
{
   public class OrderStatusData
   {
      public string OrderId
      {
         get;
         set;
      }

      public OrderDirection OrderDirection
      {
         get;
         set;
      }

      public Symbol Symbol
      {
         get;
         set;
      }

      public OrderStatus OrderStatus
      {
         get;
         set;
      }

      public string StatusMessage
      {
         get;
         set;
      }

      public double AverageTradedPrice
      {
         get;
         set;
      }

      public double TradedQuantity
      {
         get;
         set;
      }

      public DateTimeOffset OrderTimestamp
      {
         get;
         set;
      }
   }
}
