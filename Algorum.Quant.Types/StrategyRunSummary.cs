using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorum.Quant.Types
{
   public class StrategyRunSummary
   {
      public string StrategyId
      {
         get;
         set;
      }

      public string RunId
      {
         get;
         set;
      }

      public StrategyLaunchMode LaunchMode
      {
         get;
         set;
      }

      public BrokeragePlatform BrokeragePlatform
      {
         get;
         set;
      }

      public DateTime StartTime
      {
         get;
         set;
      }

      public DateTime EndTime
      {
         get;
         set;
      }

      public DateTime BacktestStartDate
      {
         get;
         set;
      }

      public DateTime BacktestEndDate
      {
         get;
         set;
      }

      public double PL
      {
         get;
         set;
      }

      public double Capital
      {
         get;
         set;
      }

      public List<Order> Orders
      {
         get;
         set;
      }

      public Dictionary<string, Dictionary<string, object>> SymbolStatsMap
      {
         get;
         set;
      }
   }
}
