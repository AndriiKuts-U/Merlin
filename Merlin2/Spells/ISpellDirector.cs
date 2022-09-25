using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin2.Spells
{
    public interface ISpellDirector
    {
        ISpell Build(string spellName);
    }

}
