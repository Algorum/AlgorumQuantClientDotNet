using System;

namespace Algorum.Quant.Types
{
   public class Ohlcv
   {
      public string DateId
      {
         get;
         set;
      }

      public decimal Open
      {
         get;
         set;
      }

      public decimal High
      {
         get;
         set;
      }

      public decimal Low
      {
         get;
         set;
      }

      public decimal Close
      {
         get;
         set;
      }

      public decimal Volume
      {
         get;
         set;
      }

      public DateTimeOffset DateTime
      {
         get { return DateTimeNormal; }
         set { DateTimeNormal = value.UtcDateTime; }
      }

      public DateTime DateTimeNormal
      {
         get;
         set;
      }

      public bool Updated
      {
         get;
         set;
      }
   }
}
