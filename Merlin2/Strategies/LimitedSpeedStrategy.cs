using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin2.Strategies
{
    public class LimitedSpeedStrategy : ISpeedStrategy
    {
        public double GetSpeed(double speed)
        {
            return speed < 1 ? speed : 1;
        }
    }
}
