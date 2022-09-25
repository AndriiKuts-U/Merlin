using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Merlin2.Spells
{
    public interface ISpell
    {
        ISpell AddEffect(ICommand effect);
        void AddEffects(IEnumerable<ICommand> effects);
        int GetCost();
        void Cast();
    }

}
