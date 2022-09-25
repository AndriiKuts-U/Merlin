using Merlin2d.Game.Actions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Merlin2.Actors
{
    public interface ICharacter : IMovable
    {
        void ChangeHealth(int delta);
        int GetHealth();
        void Die();
        void AddEffect(Command effect);
        void RemoveEffect(Command effect);

    }
}
