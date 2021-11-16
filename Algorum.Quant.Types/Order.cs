using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorum.Quant.Types
{
   public class Order
   {
      public string UserId { get; set; }
      public string StrategyId { get; set; }
      public bool Backtesting { get; set; }
      public string BacktestId { get; set; }
      public double TriggerPrice { get; set; }
      public OrderDirection OrderDirection { get; set; }
      public Symbol Symbol { get; set; }
      public string Tag { get; set; }
      public string StatusMessage { get; set; }
      public OrderStatus Status { get; set; }
      public double Quantity { get; set; }
      public OrderProductType ProductType { get; set; }
      public double Price { get; set; }
      public string PlacedBy { get; set; }
      public double PendingQuantity { get; set; }
      public string ParentOrderId { get; set; }
      public OrderType OrderType { get; set; }
      public DateTime? OrderTimestamp { get; set; }
      public string OrderId { get; set; }
      public uint InstrumentToken { get; set; }
      public double FilledQuantity { get; set; }
      public DateTime? ExchangeTimestamp { get; set; }
      public string ExchangeOrderId { get; set; }
      public TradeExchange Exchange { get; set; }
      public double DisclosedQuantity { get; set; }
      public double CancelledQuantity { get; set; }
      public double AveragePrice { get; set; }
      public string Validity { get; set; }
      public string Variety { get; set; }
      public string BrokerageOrderJson { get; set; }
      public bool Short { get; set; }
      public SlippageType SlippageType { get; set; }
      public double Slippage { get; set; }
      public TickData LastTick { get; set; }
   }
}
