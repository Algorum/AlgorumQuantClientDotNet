using System;
using System.Collections.Generic;
using System.Text;

namespace Algorum.Quant.Types
{
   public class Crossover
   {
      public Crossover()
      {
      }

      public bool CrossOverReached
      {
         get;
         set;
      }

      public bool StopCrossOverUpdate
      {
         get;
         set;
      }

      public virtual bool Evaluate( double leftVal, double rightVal )
      {
         return false;
      }
   }
}
