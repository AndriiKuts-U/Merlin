using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin2.Commands
{
  

    public class Fall<T> : IAction<T> where T : IActor
    {
        private int speed;
        
        public Fall(int speed)
        {
            
            this.speed = speed;
        }

        public void Execute(T t)
        {
            for (int i = 0; i < speed; i++)
            {
                t.SetPosition(t.GetX(), t.GetY() + 1);

                if (t.GetWorld().IntersectWithWall(t))
                {
                    break;
                }
            }
            
            while (t.GetWorld().IntersectWithWall(t))
            {
                    t.SetPosition(t.GetX() , t.GetY() - 1);
            }
         

        }
    }

}
