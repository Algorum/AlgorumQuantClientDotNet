using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorum.Quant.Types
{
   public class TradingRequest
   {
      public double Capital
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

      public string ClientCode
      {
         get;
         set;
      }

      public string Password
      {
         get;
         set;
      }

      public string TwoFactorAuth
      {
         get;
         set;
      }

      public int SamplingTimeInSeconds
      {
         get;
         set;
      }

      public BrokeragePlatform BrokeragePlatform
      {
         get;
         set;
      }
   }
}
