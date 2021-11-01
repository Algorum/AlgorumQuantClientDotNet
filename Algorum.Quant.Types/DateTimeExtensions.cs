using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorum.Quant.Types
{
   public static class DateTimeExtensions
   {
      static GregorianCalendar _gc = new GregorianCalendar();

      public static DateTime GetFirstSpecificDayOfTheMonth( this DateTime date, DayOfWeek dayofweek )
      {
         var firstDayOfMonth = new DateTime( date.Year, date.Month, 1 );

         while ( firstDayOfMonth.DayOfWeek != dayofweek )
            firstDayOfMonth = firstDayOfMonth.AddDays( 1 );

         return firstDayOfMonth;
      }

      public static DateTime GetLastSpecificDayOfTheMonth( this DateTime date, DayOfWeek dayofweek )
      {
         var lastDayOfMonth = new DateTime( date.Year, date.Month, DateTime.DaysInMonth( date.Year, date.Month ) );

         while ( lastDayOfMonth.DayOfWeek != dayofweek )
            lastDayOfMonth = lastDayOfMonth.AddDays( -1 );

         return lastDayOfMonth;
      }

      public static DateTime GetSpecificDayOfTheWeek( this DateTime date, DayOfWeek dayofweek, int week )
      {
         var expiryWeekDate = date.AddDays( week * 7 );
         var currentWeekday = (int) expiryWeekDate.DayOfWeek;
         var askedWeekday = (int) dayofweek;

         return expiryWeekDate.AddDays( -( currentWeekday - askedWeekday ) );
      }

      public static int GetWeekOfMonth( this DateTime time )
      {
         DateTime first = new DateTime( time.Year, time.Month, 1 );
         return time.GetWeekOfYear() - first.GetWeekOfYear() + 1;
      }

      public static int GetWeekOfYear( this DateTime time )
      {
         return _gc.GetWeekOfYear( time, CalendarWeekRule.FirstDay, DayOfWeek.Sunday );
      }
   }
}
