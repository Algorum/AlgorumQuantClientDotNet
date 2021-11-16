using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Algorum.Quant.Types
{
   public interface IIndicatorEvaluator
   {
      string Uid
      {
         get;
      }

      Task ClearCandlesAsync();
      Task<double> TSFAsync( double period );
      Task<double> SMAAsync( double period );
      Task<double> EMAAsync( double period );
      Task<double> HMAAsync( double period );
      Task<double> DEMAAsync( double period );
      Task<double> KAMAAsync( double period );
      Task<double> TEMAAsync( double period );
      Task<double> TRIMAAsync( double period );
      Task<double> WMAAsync( double period );
      Task<double> ZLEMAAsync( double period );
      Task<double> RSIAsync( double period );
      Task<double> ADAsync( double period );
      Task<double> ADOSCAsync( double shortPeriod, double longPeriod );
      Task<double> AOAsync( double period );
      Task<double> PlusDMIAsync( double period );
      Task<double> MinusDMIAsync( double period );
      Task<double> ADXAsync( double period );
      Task<double> ADXRAsync( double period );
      Task<double> PSARAsync( double period, double acclFactorStep, double acclFactorMax );
      Task<double> MACDAsync( double shortPeriod, double longPeriod, double signalPeriod );
      Task<double> MACDSIGNALAsync( double shortPeriod, double longPeriod, double signalPeriod );
      Task<double> STDDEVAsync( double period );
      Task<double> AROONUPAsync( double period );
      Task<double> AROONDOWNAsync( double period );
      Task<double> AROONOSCAsync( double period );
      Task<double> APOAsync( double shortPeriod, double longPeriod );
      Task<double> PPOAsync( double shortPeriod, double longPeriod );
      Task<double> ATRAsync( double period );
      Task<double> TRAsync( double period );
      Task<double> BBANDLOWERAsync( double period, double stddev );
      Task<double> BBANDUPAsync( double period, double stddev );
      Task<double> BBANDMIDAsync( double period, double stddev );
      Task<double> CCIAsync( double period );
      Task<double> MFIAsync( double period );
      Task<double> WILLRAsync( double period );
      Task<double> TRIXAsync( double period );
      Task<double> ROCAsync( double period );
      Task<double> BOPAsync( double period );
      Task<double> UOSCAsync( double shortPeriod, double mediumPeriod, double longPeriod );
      Task<double> MOMAsync( double period );
      Task<double> STOCHKAsync( double period, double slowingPeriod, double period2 );
      Task<double> STOCHDAsync( double period, double slowingPeriod, double period2 );
      Task<double> OBVAsync( double period );
      Task<double> NATRAsync( double period );
      Task<double> VWMAAsync( double period );
      Task<double> AVGPRICEAsync( double period );
      Task<double> VOLATILITYAsync( double period );
      Task<double> VARAsync( double period );
      Task<double> MDAsync( double period );
      Task<double> SUMAsync( double period );
      Task<double> SUBAsync( double period );
      Task<double> TANAsync( double period );
      Task<double> SINAsync( double period );
      Task<double> COSAsync( double period );
      Task<double> OPENAsync();
      Task<double> CLOSEAsync();
      Task<double> HIGHAsync();
      Task<double> LOWAsync();
      Task<double> PREVOPENAsync();
      Task<double> PREVCLOSEAsync();
      Task<double> PREVHIGHAsync();
      Task<double> PREVLOWAsync();
      Task<double> CANDLEOPENAsync( double period );
      Task<double> CANDLEHIGHAsync( double period );
      Task<double> CANDLELOWAsync( double period );
      Task<double> CANDLECLOSEAsync( double period );
      Task<double> EVENINGSTARAsync( double period );
      Task<double> THREEWHITESOLDIERSAsync( double period );
      Task<double> HAMMERAsync( double period );
      Task<double> INVERTEDHAMMERAsync( double period );
      Task<double> DRAGONFLYDOJIAsync( double period );
      Task<double> MORNINGSTARAsync( double period );
      Task<double> THREEBLACKCROWSAsync( double period );
      Task<double> ABANDONEDBABYBULLAsync( double period );
      Task<double> ABANDONEDBABYBEARAsync( double period );
      Task<double> BIGBLACKCANDLEAsync( double period );
      Task<double> BIGWHITECANDLEAsync( double period );
      Task<double> BLACKMARUBOZUAsync( double period );
      Task<double> DOJIAsync( double period );
      Task<double> ENGULFINGBEARAsync( double period );
      Task<double> ENGULFINGBULLAsync( double period );
      Task<double> EVENINGDOJISTARAsync( double period );
      Task<double> FOURPRICEDOJIAsync( double period );
      Task<double> GRAVESTONEDOJIAsync( double period );
      Task<double> HANGINGMANAsync( double period );
      Task<double> LONGLEGGEDDOJIAsync( double period );
      Task<double> MARUBOZUAsync( double period );
      Task<double> MORNINGDOJISTARAsync( double period );
      Task<double> SPINNINGTOPAsync( double period );
      Task<double> STARAsync( double period );
      Task<double> WHITEMARUBOZUAsync( double period );
      Task<(double, double, double, double)> SUPPORTRESISTANCEAsync( double period, int level, int backtrackCandles );
      Task<(double, double)> TRENDAsync( double period, double skipPeriod = 0 );

      Task PreloadCandlesAsync( int candleCount, DateTime preloadEndTime, string bkApiKey, string bkApiSecretKey );
   }
}
