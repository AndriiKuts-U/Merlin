using Merlin2.Actors;
using Merlin2d.Game;
using Merlin2d.Game.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin2.Items
{
    public class HealingPotion : AbstractActor, IItem, IUsable
    {
        private int usesRemaining = 1;
        public HealingPotion()
        {
            SetAnimation(new Animation("resources/sprites/healing_potion.png",24,24));
        }
        public override void Update()
        {
         
        }

        public void Use(ICharacter character)
        {
            if (usesRemaining-- >= 0)
            {

            }
        }
    }
}
