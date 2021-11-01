using System;
using System.Collections.Generic;
using System.Text;

namespace Algorum.Quant.Types
{
   public class AlgorumWebSocketError
   {
      public int ErrorCode
      {
         get;
         set;
      }

      public string ErrorMessage
      {
         get;
         set;
      }

      public string ErrorStackTrace
      {
         get;
         set;
      }
   }

   public class AlgorumWebSocketMessage
   {
      public string Name
      {
         get;
         set;
      }

      public AlgorumMessageType MessageType
      {
         get;
         set;
      }

      public string CorId
      {
         get;
         set;
      }

      public string JsonData
      {
         get;
         set;
      }

      public AlgorumWebSocketError Error
      {
         get;
         set;
      }
   }
}
