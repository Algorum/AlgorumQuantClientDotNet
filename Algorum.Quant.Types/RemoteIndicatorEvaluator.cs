using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorum.Quant.Types
{
   public class RemoteIndicatorEvaluator : IIndicatorEvaluator
   {
      private AlgorumWebSocketClient _wsClient;
      private string _uid;
      private Symbol _symbol;

      public RemoteIndicatorEvaluator( AlgorumWebSocketClient wsClient, string uid, Symbol symbol )
      {
         _wsClient = wsClient;
         _uid = uid;
         _symbol = symbol;
      }

      public string Uid => _uid;

      public async Task<double> ABANDONEDBABYBEARAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest> { new IndicatorRequest()
               {
                  Indicator = "ABANDONEDBABYBEAR",
                  ParamMap = new Dictionary<string, double>()
                  {
                     { "period", period }
                  } }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> ABANDONEDBABYBULLAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest> { new IndicatorRequest()
               {
                  Indicator = "ABANDONEDBABYBULL",
                  ParamMap = new Dictionary<string, double>()
                  {
                     { "period", period }
                  } }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> ADAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest> { new IndicatorRequest()
               {
                  Indicator = "AD",
                  ParamMap = new Dictionary<string, double>()
                  {
                     { "period", period }
                  } }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> ADOSCAsync( double shortPeriod, double longPeriod )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest> { new IndicatorRequest()
               {
                  Indicator = "ADOSC",
                  ParamMap = new Dictionary<string, double>()
                  {
                     { "shortPeriod", shortPeriod },
                     { "longPeriod", longPeriod }
                  } }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> ADXAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest> { new IndicatorRequest()
               {
                  Indicator = "ADX",
                  ParamMap = new Dictionary<string, double>()
                  {
                     { "period", period }
                  } }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> ADXRAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest> { new IndicatorRequest()
               {
                  Indicator = "ADXR",
                  ParamMap = new Dictionary<string, double>()
                  {
                     { "period", period }
                  } }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> AOAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest> { new IndicatorRequest()
               {
                  Indicator = "AO",
                  ParamMap = new Dictionary<string, double>()
                  {
                     { "period", period }
                  } }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> APOAsync( double shortPeriod, double longPeriod )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest> { new IndicatorRequest()
               {
                  Indicator = "APO",
                  ParamMap = new Dictionary<string, double>()
                  {
                     { "shortPeriod", shortPeriod },
                     { "longPeriod", longPeriod }
                  } }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> AROONDOWNAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest> { new IndicatorRequest()
               {
                  Indicator = "AROONDOWN",
                  ParamMap = new Dictionary<string, double>()
                  {
                     { "period", period }
                  } }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> AROONOSCAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest> { new IndicatorRequest()
               {
                  Indicator = "AROONOSC",
                  ParamMap = new Dictionary<string, double>()
                  {
                     { "period", period }
                  } }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> AROONUPAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest> { new IndicatorRequest()
               {
                  Indicator = "AROONUP",
                  ParamMap = new Dictionary<string, double>()
                  {
                     { "period", period }
                  } }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> ATRAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest> { new IndicatorRequest()
               {
                  Indicator = "ATR",
                  ParamMap = new Dictionary<string, double>()
                  {
                     { "period", period }
                  } }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> AVGPRICEAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest> { new IndicatorRequest()
               {
                  Indicator = "AVGPRICE",
                  ParamMap = new Dictionary<string, double>()
                  {
                     { "period", period }
                  } }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> BBANDLOWERAsync( double period, double stddev )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest> { new IndicatorRequest()
               {
                  Indicator = "BBANDLOWER",
                  ParamMap = new Dictionary<string, double>()
                  {
                     { "period", period },
                     { "stddev", stddev }
                  } }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> BBANDMIDAsync( double period, double stddev )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest> { new IndicatorRequest()
               {
                  Indicator = "BBANDMID",
                  ParamMap = new Dictionary<string, double>()
                  {
                     { "period", period },
                     { "stddev", stddev }
                  } }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> BBANDUPAsync( double period, double stddev )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest> { new IndicatorRequest()
               {
                  Indicator = "BBANDUP",
                  ParamMap = new Dictionary<string, double>()
                  {
                     { "period", period },
                     { "stddev", stddev }
                  } }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> BIGBLACKCANDLEAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest> { new IndicatorRequest()
               {
                  Indicator = "BIGBLACKCANDLE",
                  ParamMap = new Dictionary<string, double>()
                  {
                     { "period", period }
                  } }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> BIGWHITECANDLEAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest> { new IndicatorRequest()
               {
                  Indicator = "BIGWHITECANDLE",
                  ParamMap = new Dictionary<string, double>()
                  {
                     { "period", period }
                  } }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> BLACKMARUBOZUAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest> { new IndicatorRequest()
               {
                  Indicator = "BLACKMARUBOZU",
                  ParamMap = new Dictionary<string, double>()
                  {
                     { "period", period }
                  } }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> BOPAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest> { new IndicatorRequest()
               {
                  Indicator = "BOP",
                  ParamMap = new Dictionary<string, double>()
                  {
                     { "period", period }
                  } }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> CANDLECLOSEAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest> { new IndicatorRequest()
               {
                  Indicator = "CANDLECLOSE",
                  ParamMap = new Dictionary<string, double>()
                  {
                     { "period", period }
                  } }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> CANDLEHIGHAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest> { new IndicatorRequest()
               {
                  Indicator = "CANDLEHIGH",
                  ParamMap = new Dictionary<string, double>()
                  {
                     { "period", period }
                  } }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> CANDLELOWAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest> { new IndicatorRequest()
               {
                  Indicator = "CANDLELOW",
                  ParamMap = new Dictionary<string, double>()
                  {
                     { "period", period }
                  } }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> CANDLEOPENAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest> { new IndicatorRequest()
               {
                  Indicator = "CANDLEOPEN",
                  ParamMap = new Dictionary<string, double>()
                  {
                     { "period", period }
                  } }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> CCIAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest> { new IndicatorRequest()
               {
                  Indicator = "CCI",
                  ParamMap = new Dictionary<string, double>()
                  {
                     { "period", period }
                  } }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> CLOSEAsync()
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "CLOSE"
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> COSAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "COS",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> DEMAAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "DEMA",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> DOJIAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "DOJI",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> DRAGONFLYDOJIAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "DRAGONFLYDOJI",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> EMAAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "EMA",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> ENGULFINGBEARAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "ENGULFINGBEAR",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> ENGULFINGBULLAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "ENGULFINGBULL",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> EVENINGDOJISTARAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "EVENINGDOJISTAR",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> EVENINGSTARAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "EVENINGSTAR",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> FOURPRICEDOJIAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "FOURPRICEDOJI",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> GRAVESTONEDOJIAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "GRAVESTONEDOJI",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> HAMMERAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "HAMMER",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> HANGINGMANAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "HANGINGMAN",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> HIGHAsync()
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "HIGH"
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> HMAAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "HMA",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> INVERTEDHAMMERAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "INVERTEDHAMMER",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> KAMAAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "KAMA",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> LONGLEGGEDDOJIAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "LONGLEGGEDDOJI",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> LOWAsync()
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "LOW"
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> MACDAsync( double shortPeriod, double longPeriod, double signalPeriod )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "MACD",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "shortPeriod", shortPeriod },
                        { "longPeriod", longPeriod },
                        { "signalPeriod", signalPeriod }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> MACDSIGNALAsync( double shortPeriod, double longPeriod, double signalPeriod )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "MACDSIGNAL",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "shortPeriod", shortPeriod },
                        { "longPeriod", longPeriod },
                        { "signalPeriod", signalPeriod }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> MARUBOZUAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "MARUBOZU",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> MDAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "MD",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> MFIAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "MFI",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> MinusDMIAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "MinusDMI",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> MOMAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "MOM",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> MORNINGDOJISTARAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "MORNINGDOJISTAR",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> MORNINGSTARAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "MORNINGSTAR",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> NATRAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "NATR",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> OBVAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "OBV",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> OPENAsync()
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "OPEN"
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> PlusDMIAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "PlusDMI",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> PPOAsync( double shortPeriod, double longPeriod )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "PPO",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "shortPeriod", shortPeriod },
                        { "longPeriod", longPeriod }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> PREVCLOSEAsync()
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "PREVCLOSE"
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> PREVHIGHAsync()
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "PREVHIGH"
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> PREVLOWAsync()
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "PREVLOW"
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> PREVOPENAsync()
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "PREVOPEN"
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> PSARAsync( double period, double acclFactorStep, double acclFactorMax )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "PSAR",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period },
                        { "acclFactorStep", acclFactorStep },
                        { "acclFactorMax", acclFactorMax }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> ROCAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "ROC",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> RSIAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "RSI",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> SINAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "SIN",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> SMAAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "SMA",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> SPINNINGTOPAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "SPINNINGTOP",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> STARAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "STAR",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> STDDEVAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "STDDEV",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> STOCHDAsync( double period, double slowingPeriod, double period2 )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "STOCHD",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period },
                        { "slowingPeriod", slowingPeriod },
                        { "period2", period2 }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> STOCHKAsync( double period, double slowingPeriod, double period2 )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "STOCHK",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period },
                        { "slowingPeriod", slowingPeriod },
                        { "period2", period2 }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> SUBAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "SUB",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> SUMAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "SUM",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<(double, double, double, double)> SUPPORTRESISTANCEAsync( double period, int level, int backtrackCandles )
      {
         var result = ( _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>( "get_indicators", new GetIndicatorsRequest()
         {
            IndicatorUid = _uid,
            IndicatorRequests = new List<IndicatorRequest>
            {
               new IndicatorRequest()
               {
                  Indicator = "SUPPORTRESISTANCE",
                  ParamMap = new Dictionary<string, double>()
                  {
                     { "period", period },
                     { "level", level },
                     { "backtrackCandles", backtrackCandles }
                  }
               }
            }
         } ) ).Result;

         if ( result != null && result.Count > 0 )
         {
            var indicatorResult = result.FirstOrDefault();

            if ( indicatorResult != null )
            {
               double supportValue = 0;
               double supportScore = 0;
               double resistanceValue = 0;
               double resistanceScore = 0;

               if ( indicatorResult.ResultMap != null )
               {
                  supportValue = indicatorResult.ResultMap["support"];
                  supportScore = indicatorResult.ResultMap["supportscore"];
                  resistanceValue = indicatorResult.ResultMap["resistance"];
                  resistanceScore = indicatorResult.ResultMap["resistancescore"];
               }

               return (supportValue, supportScore, resistanceValue, resistanceScore);
            }
         }

         return (0, 0, 0, 0);
      }

      public async Task<double> TANAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "TAN",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> TEMAAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "TEMA",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> THREEBLACKCROWSAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "THREEBLACKCROWS",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> THREEWHITESOLDIERSAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "THREEWHITESOLDIERS",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> TRAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "TR",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<(double, double)> TRENDAsync( double period, double skipPeriod = 0 )
      {
         var result = ( _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>( "get_indicators", new GetIndicatorsRequest()
         {
            IndicatorUid = _uid,
            IndicatorRequests = new List<IndicatorRequest>
            {
               new IndicatorRequest()
               {
                  Indicator = "TREND",
                  ParamMap = new Dictionary<string, double>()
                  {
                     { "period", period }
                  }
               }
            }
         } ) ).Result;

         if ( result != null && result.Count > 0 )
         {
            var indicatorResult = result.FirstOrDefault();

            if ( indicatorResult != null )
            {
               var direction = indicatorResult.Result;
               double strength = 0;

               if ( indicatorResult.ResultMap != null )
                  strength = indicatorResult.ResultMap["strength"];

               return (direction, strength);
            }
         }

         return (0, 0);
      }

      public async Task<double> TRIMAAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "TRIMA",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> TRIXAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "TRIX",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> TSFAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "TSF",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> UOSCAsync( double shortPeriod, double mediumPeriod, double longPeriod )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "UOSC",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "shortPeriod", shortPeriod },
                        { "mediumPeriod", mediumPeriod },
                        { "longPeriod", longPeriod }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> VARAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "VAR",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> VOLATILITYAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "VOLATILITY",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> VWMAAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "VWMA",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> WHITEMARUBOZUAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "WHITEMARUBOZU",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> WILLRAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "WILLR",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> WMAAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "WMA",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task<double> ZLEMAAsync( double period )
      {
         var result = await _wsClient.ExecuteAsync<GetIndicatorsRequest, List<IndicatorResult>>(
            "get_indicators",
            new GetIndicatorsRequest()
            {
               IndicatorUid = _uid,
               IndicatorRequests = new List<IndicatorRequest>
               {
                  new IndicatorRequest()
                  {
                     Indicator = "ZLEMA",
                     ParamMap = new Dictionary<string, double>()
                     {
                        { "period", period }
                     }
                  }
               }
            } );

         if ( result != null && result.Count > 0 )
         {
            var resultObj = result.FirstOrDefault()?.Result;
            return resultObj.Value;
         }

         return 0;
      }

      public async Task PreloadCandlesAsync( int candleCount, DateTime preloadEndTime, string bkApiKey, string bkApiSecretKey )
      {
         await _wsClient.ExecuteAsync( "preload_candles", new PreloadCandlesRequest()
         {
            IndicatorUid = _uid,
            CandleCount = candleCount,
            PreloadEndTime = preloadEndTime,
            ApiKey = bkApiKey,
            ApiSecretKey = bkApiSecretKey
         } );
      }
   }
}
