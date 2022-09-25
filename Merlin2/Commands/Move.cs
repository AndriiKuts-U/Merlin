using Merlin2.Actors;

using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;
using System.Text;

namespace Merlin2.Commands
{
    public class Move : Command
    {
        private IActor movable;
        private int dx;
        private double step;
        private int dy;

        public Move(IActor movable, double step, int dx, int dy)
        {
            if (movable != null)
            {
                this.dx = dx;
                this.dy = dy;
                this.step = step;
                this.movable = movable;

            }
            else 
            {
                throw new ArgumentException("error message goes here");

            }
         

        }

        public void Execute()
        {
            movable.SetPosition((int)(movable.GetX() + dx * step), (int)(movable.GetY() + dy * step));

            while (movable.GetWorld().IntersectWithWall(movable))
            {
                movable.SetPosition(movable.GetX() + dx * -1, movable.GetY() + dy * -1  );
            }
          
        }
    }
}
