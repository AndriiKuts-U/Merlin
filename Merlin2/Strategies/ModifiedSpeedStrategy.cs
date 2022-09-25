using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin2.Strategies
{
    public class ModifiedSpeedStrategy : ISpeedStrategy
    {
        private double speedMultiprier;
        public ModifiedSpeedStrategy(double speedMultiprier)
        {
            this.speedMultiprier = speedMultiprier;
        }
        public double GetSpeed(double speed)
        {
            return speedMultiprier * speed;
        }
    }
}
