using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorum.Quant.Types
{
   public static class SymbolExtensions
   {
      public static bool IsMatch( this Symbol source, TickData tickData )
      {
         var sourceId = source.GetInstrumentIdentifier( tickData.Timestamp );
         var tickId = tickData.Symbol.GetInstrumentIdentifier( tickData.Timestamp );

         return string.Compare( sourceId, tickId, true ) == 0;
      }

      public static string GetInstrumentIdentifier( this Symbol source, DateTime timestamp )
      {
         string typePart = string.Empty;

         switch ( source.SymbolType )
         {
         case SymbolType.FuturesIndex:
            typePart = "FUTIDX";
            break;
         case SymbolType.FuturesStock:
            typePart = "FUTSTK";
            break;
         case SymbolType.OptionsIndex:
            typePart = "OPTIDX";
            break;
         case SymbolType.OptionsStock:
            typePart = "OPTSTK";
            break;
         }

         string namePart = source.Ticker;
         string expiryPart = string.Empty;
         string optionTypePart;

         if ( source.SymbolType == SymbolType.FuturesIndex || source.SymbolType == SymbolType.FuturesStock )
            optionTypePart = OptionType.XX.ToString();
         else
            optionTypePart = source.OptionType == OptionType.None ? string.Empty : source.OptionType.ToString();

         string optionValue = source.OptionValue == 0 ? string.Empty : source.OptionValue.ToString( "N:0" );

         if ( source.SymbolType == SymbolType.FuturesIndex || source.SymbolType == SymbolType.FuturesStock )
         {
            var expiryDate = timestamp.AddMonths( source.FNOMonth );
            var curMonthLastDate = expiryDate.GetLastSpecificDayOfTheMonth( DayOfWeek.Thursday );

            if ( expiryDate.Day > curMonthLastDate.Day )
            {
               var nextMonth = timestamp.AddMonths( 1 );
               expiryDate = nextMonth.GetLastSpecificDayOfTheMonth( DayOfWeek.Thursday );
            }

            expiryPart = expiryDate.ToString( "ddMMyyyy" );
         }
         else if ( source.SymbolType == SymbolType.OptionsIndex || source.SymbolType == SymbolType.OptionsStock )
         {
            if ( source.FNOPeriodType == FNOPeriodType.Monthly )
            {
               var expiryDate = timestamp.AddMonths( source.FNOMonth );
               var curMonthLastDate = expiryDate.GetLastSpecificDayOfTheMonth( DayOfWeek.Thursday );

               if ( expiryDate.Day > curMonthLastDate.Day )
               {
                  var nextMonth = timestamp.AddMonths( 1 );
                  expiryDate = nextMonth.GetLastSpecificDayOfTheMonth( DayOfWeek.Thursday );
               }

               expiryPart = expiryDate.ToString( "ddMMyyyy" );
            }
            else
            {
               var expiryDate = timestamp.GetSpecificDayOfTheWeek( DayOfWeek.Thursday, source.FNOWeek );

               if ( expiryDate.Day > timestamp.Day )
                  expiryDate = timestamp.GetSpecificDayOfTheWeek( DayOfWeek.Thursday, source.FNOWeek + 1 );

               expiryPart = expiryDate.ToString( "ddMMyyyy" );
            }
         }

         var builder = new StringBuilder();

         if ( !string.IsNullOrWhiteSpace( typePart ) )
            builder.Append( $"{typePart}_" );

         if ( !string.IsNullOrWhiteSpace( namePart ) )
            builder.Append( $"{namePart}" );

         if ( !string.IsNullOrWhiteSpace( expiryPart ) )
            builder.Append( $"_{expiryPart}" );

         if ( !string.IsNullOrWhiteSpace( optionTypePart ) )
            builder.Append( $"_{optionTypePart}" );

         if ( !string.IsNullOrWhiteSpace( optionValue ) )
            builder.Append( $"_{optionValue}" );

         return builder.ToString();
      }
   }

   public class Symbol : IComparable<Symbol>
   {
      /// <summary>
      /// Symbol type (stocks, futures, options, crypto, etc.,)
      /// </summary>
      public SymbolType SymbolType
      {
         get;
         set;
      }

      /// <summary>
      /// Symbol ticker
      /// </summary>
      public string Ticker
      {
         get;
         set;
      }

      public FNOPeriodType FNOPeriodType
      {
         get;
         set;
      }

      public int FNOMonth
      {
         get;
         set;
      }

      public int FNOWeek
      {
         get;
         set;
      }

      public long ScripToken
      {
         get;
         set;
      }

      public OptionType OptionType
      {
         get;
         set;
      }

      public double OptionValue
      {
         get;
         set;
      }

      public int CompareTo( Symbol other )
      {
         if ( other.SymbolType == SymbolType && string.Compare( other.Ticker, Ticker, true ) == 0 )
            return 0;

         return -1;
      }
   }
}
