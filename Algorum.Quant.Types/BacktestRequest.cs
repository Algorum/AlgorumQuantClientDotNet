using System;
using System.Collections.Generic;

namespace Algorum.Quant.Types
{
   public class BacktestRequest
   {
      public string Uid
      {
         get;
         set;
      }

      public DateTime StartDate
      {
         get;
         set;
      }

      public DateTime EndDate
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
