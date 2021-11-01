using System;
using System.Collections.Generic;
using System.Text;

namespace Algorum.Quant.Types
{
   public class CrossAbove : Crossover
   {
      public CrossAbove()
         : base()
      {
         // No-Op
         StopCrossOverUpdate = true;
      }

      public override bool Evaluate( double leftVal, double rightVal )
      {
         if ( !StopCrossOverUpdate )
         {
            CrossOverReached = leftVal > rightVal;

            if ( CrossOverReached )
               StopCrossOverUpdate = true;
         }
         else
         {
            if ( leftVal < rightVal )
               StopCrossOverUpdate = false;

            CrossOverReached = false;
         }

         return CrossOverReached;
      }
   }
}
