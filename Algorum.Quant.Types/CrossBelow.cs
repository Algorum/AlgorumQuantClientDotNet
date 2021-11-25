using System;
using System.Collections.Generic;
using System.Text;

namespace Algorum.Quant.Types
{
   public class CrossBelow : Crossover
   {
      public CrossBelow()
         : base()
      {
         StopCrossOverUpdate = true;
      }

      public override bool Evaluate( double leftVal, double rightVal )
      {
         if ( !StopCrossOverUpdate )
         {
            CrossOverReached = leftVal < rightVal;

            if ( CrossOverReached )
               StopCrossOverUpdate = true;
         }
         else
         {
            if ( leftVal > rightVal )
               StopCrossOverUpdate = false;

            CrossOverReached = false;
         }

         return CrossOverReached;
      }
   }
}
