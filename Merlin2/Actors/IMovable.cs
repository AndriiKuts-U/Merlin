using Merlin2.Strategies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin2.Actors
{
    public interface IMovable 
    {
        void SetSpeedStrategy(ISpeedStrategy strategy);
        double GetSpeed(double speed);

    }
}
