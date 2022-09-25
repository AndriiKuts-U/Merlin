using Merlin2.Actors;
using Merlin2.Strategies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Merlin2.Spells
{
    public class ProjectileSpell : AbstractActor, IMovable, ISpell
    {
        private int cost;
        private double speed;
        
        ISpeedStrategy strategy;
        IEnumerable<ICommand> effects;


        public ProjectileSpell(int cost)
        {
            this.cost = cost;
        }

        public ISpell AddEffect(ICommand effect)
        {

            throw new NotImplementedException();
        }

        public void AddEffects(IEnumerable<ICommand> effects)
        {
            this.effects = effects;

        }

        public void Cast()
        {
            throw new NotImplementedException();
        }

        public int GetCost()
        {
            return cost;
        }

        public double GetSpeed(double speed)
        {
            return speed;
        }

        public void SetSpeedStrategy(ISpeedStrategy strategy)
        {
            this.strategy = strategy;
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
