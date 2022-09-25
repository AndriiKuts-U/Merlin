using Merlin2.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin2.Spells
{
    public class SpellDirector : ISpellDirector
    {
        Dictionary<string, SpellInfo> spells;
       // Dictionary<string, int> effectCosts;
        IWizard wizard;
        public SpellDirector(IWizard wizard, ISpellDataProvider provider)
        {
            spells = provider.GetSpellInfo();
            this.wizard = wizard;
        }
        public ISpell Build(string spellName)
        {
            
            ISpellBuilder builder;
            if (spells[spellName].SpellType == SpellType.Projectile)
            {
                builder = new ProjectileSpellBuilder();
            }
            else 
            {
                builder = new SelfCastSpellBuilder();
            }
            return builder.AddEffect("DoT").AddEffect("slow").CreateSpell(wizard);
         
            
        }
    }
}
