using Merlin2d.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin2.Spells
{
    public interface ISpellBuilder
    {
        ISpellBuilder AddEffect(string effectName);
        ISpellBuilder SetAnimation(Animation animation); //unused for self-cast spells
        ISpellBuilder SetSpellCost(int cost);
        ISpell CreateSpell(IWizard caster);
    }

}
