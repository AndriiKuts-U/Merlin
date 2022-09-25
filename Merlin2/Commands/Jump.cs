using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;



namespace Merlin2.Commands
{
    public class Jump : Command
    { 
        private IActor actor;
        private int height;
        private int speed;
        private int actualHeight = 0;
        private int acceleration = 0;
       
  

        public Jump(IActor actor,int height, int speed, int acceleration)
        {
            this.speed = speed;
            this.height = height;
            this.acceleration = acceleration;
            if(actor != null)
            {
                this.actor = actor;
            }
            else
            {
                throw new ArgumentException("error message goes here");
            }

        }
  
      
        public void Execute()
        {

           if(actualHeight >= 180)
           {
                actualHeight = 0;
                acceleration = 15;
                return;
           }
                for(int i = 0; i < acceleration + speed; i++)
                {
                    actor.SetPosition(actor.GetX(), actor.GetY() - 1);
                    if (actor.GetWorld().IntersectWithWall(actor))
                    { 
                        actualHeight = 0;
                        acceleration = 15;
                         return;
                    }

                }
                actualHeight+=(speed + acceleration) - 7;

                if(acceleration > 0)
                {
                         acceleration--;
                }
              
            
         
            
        }
    }
}
