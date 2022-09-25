using Merlin2.Strategies;
using Merlin2d.Game.Actions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Merlin2.Actors
{
    public abstract class AbstractCharacter : AbstractActor, ICharacter
    {
        private List<Command> effects = new List<Command>();
    
        private ISpeedStrategy speedStrategy;
        private int health;
        private bool die;


       
        public void AddEffect(Command effect)
        {
            effects.Add(effect);
        }

        public void ChangeHealth(int delta)
        {
            health += delta;
        }

        public bool GetDie()
        {
            return die;
        }
        public void Die()
        {
            if (this.GetHealth() <= 0) 
            {
                   die = true;
                    this.RemoveFromWorld();
            }
           
            
        }

        public int GetHealth()
        {
            return health;
        }

        public double GetSpeed(double speed)
        {
            return speed;
        }

        public void RemoveEffect(Command effect)
        {
         
            effects.Remove(effect);

        }

        public void SetSpeedStrategy(ISpeedStrategy strategy)
        {
            this.speedStrategy = strategy;
        }
        public override void Update()
        {
            effects.ForEach(e => e.Execute());
        }
    }
}
