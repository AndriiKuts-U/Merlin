using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin2.Strategies
{
    public class NormalSpeedStrategy : ISpeedStrategy
    {
        

        public double GetSpeed(double speed)
        {
            return speed;
        }
    }
}
