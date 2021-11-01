using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorum.Quant.Types
{
   public class PlaceOrderRequest
   {
      public DateTime Timestamp
      {
         get;
         set;
      }

      public string Validity
      {
         get;
         set;
      }

      public Symbol Symbol
      {
         get;
         set;
      }

      public TradeExchange TradeExchange
      {
         get;
         set;
      }

      public OrderType OrderType
      {
         get;
         set;
      }

      public OrderDirection OrderDirection
      {
         get;
         set;
      }

      public OrderProductType OrderProductType
      {
         get;
         set;
      }

      public string Tag
      {
         get;
         set;
      }

      public double Quantity
      {
         get;
         set;
      }

      public double Price
      {
         get;
         set;
      }

      public double TriggerPrice
      {
         get;
         set;
      }

      public SlippageType SlippageType
      {
         get;
         set;
      }

      public double Slippage
      {
         get;
         set;
      }
   }
}
