using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Algorum.Quant.Types
{
   public static class SymbolExtensions
   {
      public static bool IsMatch( this Symbol source, TickData tickData )
      {
         return source.Equals( tickData.Symbol );
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
            optionTypePart = $"{OptionType.XX}_0";
         else
            optionTypePart = source.OptionType == OptionType.None ? string.Empty : source.OptionType.ToString();

         string optionValue = source.OptionValue == 0 ? string.Empty : $"{(int) source.OptionValue}";

         if ( source.SymbolType == SymbolType.FuturesIndex || source.SymbolType == SymbolType.FuturesStock )
         {
            var expiryDate = timestamp.AddMonths( source.FNOMonth );
            var curMonthLastDate = expiryDate.GetLastSpecificDayOfTheMonth( DayOfWeek.Thursday );

            if ( expiryDate.Day > curMonthLastDate.Day )
            {
               var nextMonth = timestamp.AddMonths( 1 );
               expiryDate = nextMonth.GetLastSpecificDayOfTheMonth( DayOfWeek.Thursday );
            }
            else
            {
               expiryDate = curMonthLastDate;
            }

            expiryPart = expiryDate.ToString( "ddMMyyyy" ).ToUpper();
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
               else
               {
                  expiryDate = curMonthLastDate;
               }

               expiryPart = expiryDate.ToString( "ddMMyyyy" ).ToUpper();
            }
            else
            {
               var expiryDate = timestamp.GetSpecificDayOfTheWeek( DayOfWeek.Thursday, source.FNOWeek );

               if ( expiryDate.Day > timestamp.Day )
                  expiryDate = timestamp.GetSpecificDayOfTheWeek( DayOfWeek.Thursday, source.FNOWeek + 1 );

               expiryPart = expiryDate.ToString( "ddMMyyyy" ).ToUpper();
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

      public static string GetInstrumentIdentifier( this Symbol source )
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
         string optionTypePart;
         string expiryPart = string.Empty;

         if ( source.SymbolType == SymbolType.FuturesIndex || source.SymbolType == SymbolType.FuturesStock )
            optionTypePart = $"{OptionType.XX}_0";
         else
            optionTypePart = source.OptionType == OptionType.None ? string.Empty : source.OptionType.ToString();

         string optionValue = source.OptionValue == 0 ? string.Empty : $"{(int) source.OptionValue}";

         if ( source.SymbolType == SymbolType.FuturesIndex || source.SymbolType == SymbolType.FuturesStock ||
               source.SymbolType == SymbolType.OptionsIndex || source.SymbolType == SymbolType.OptionsStock )
         {
            expiryPart = $"{source.ExpiryDate.ToString( "ddMMMyyyy" ).ToUpper()}";
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

   public class Symbol : IComparable<Symbol>, IEquatable<Symbol>
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

      public OptionDistanceType OptionDistanceType
      {
         get;
         set;
      }

      public double OptionDistanceValue
      {
         get;
         set;
      }

      public double OptionValue
      {
         get;
         set;
      }

      public DateTime ExpiryDate
      {
         get;
         set;
      }

      public int CompareTo( Symbol other )
      {
         if ( string.Compare( Ticker, other.Ticker, true ) == 0 &&
                  SymbolType == other.SymbolType &&
                  FNOMonth == other.FNOMonth &&
                  FNOWeek == other.FNOWeek &&
                  FNOPeriodType == other.FNOPeriodType &&
                  OptionType == other.OptionType &&
                  OptionValue == other.OptionValue &&
                  ExpiryDate == other.ExpiryDate )
            return 0;

         return -1;
      }

      public override int GetHashCode()
      {
         string typePart = string.Empty;

         switch ( SymbolType )
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

         string namePart = Ticker;
         string expiryPart = string.Empty;
         string optionTypePart;

         if ( SymbolType == SymbolType.FuturesIndex || SymbolType == SymbolType.FuturesStock )
            optionTypePart = OptionType.XX.ToString();
         else
            optionTypePart = OptionType == OptionType.None ? string.Empty : OptionType.ToString();

         string optionValue = OptionValue == 0 ? string.Empty : ( (int) OptionValue ).ToString();

         if ( SymbolType == SymbolType.FuturesIndex || SymbolType == SymbolType.FuturesStock ||
            SymbolType == SymbolType.OptionsIndex || SymbolType == SymbolType.OptionsStock )
         {
            expiryPart = $"{ExpiryDate.ToString( "ddMMMyy" )}";
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

         return builder.ToString().GetHashCode();
      }

      public override bool Equals( object obj )
      {
         var other = (Symbol) obj;
         return CompareTo( other ) == 0;
      }

      public bool Equals( Symbol other )
      {
         return Equals( (object) other );
      }

      public override string ToString()
      {
         return this.GetInstrumentIdentifier();
      }
   }
}
