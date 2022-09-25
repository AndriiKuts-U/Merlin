using Merlin2.Actors;
using Merlin2d.Game;
using Merlin2d.Game.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin2.Items
{
    public class ManaPotion : AbstractActor, IItem, IUsable
    {
        public ManaPotion()
        {
            SetAnimation(new Animation("resources/sprites/mana_potion.png", 24, 24));
        }

        public void Use(ICharacter character)
        {
            throw new NotImplementedException();
        }
        public override void Update()
        {

        }
    }
}
