using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Merlin2.Spells
{
    public class SelfCastSpell : ISpell
    {
        private int cost;
        public SelfCastSpell()
        {

        }
       
        public ISpell AddEffect(ICommand effect)
        {
            throw new NotImplementedException();
        }

        public void AddEffects(IEnumerable<ICommand> effects)
        {
            throw new NotImplementedException();
        }

        public void Cast()
        {
            throw new NotImplementedException();
        }

        public int GetCost()
        {
            return cost;
        }
    }
}
