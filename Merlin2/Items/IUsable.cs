using Merlin2.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin2.Items
{
   internal interface IUsable
    {

        public void Use(ICharacter character);
    }
}
