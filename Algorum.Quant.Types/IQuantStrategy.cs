using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Algorum.Quant.Types
{
   public interface IQuantStrategy
   {
      Task OnTickAsync( TickData tickData );
      Task InitializeAsync( string state, ILogger logger, IQuantEngine quantEngine );
      Task OnOrderUpdateAsync( Order order );
      Task OnAccessTokenChangeAsync( string accessToken );
   }
}
