using Merlin2.Actors;
using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin2.Spells
{
    public class SpellEffectFactory : IFactory
    {
        IActor actor;
        public IActor Create(string actorType, string actorName, int x, int y)
        {
            if (actorType == "player")
            {

                actor = new Player();

                actor.SetName(actorName);
                actor.SetPosition(x, y);
                return actor;

            }
            if (actorType == "enemy")
            {


                Enemy enemy = new Enemy(actor);

                enemy.SetName(actorName);
                enemy.SetPosition(x, y);
                Console.WriteLine($"\n\n{enemy.GetX() },{enemy.GetY()}\n\n");
                return enemy;
            }


            return null;



        }
    }
}
