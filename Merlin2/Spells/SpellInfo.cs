using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin2.Spells
{
    public class SpellInfo
    {
        public string Name { get; set; }
        public SpellType SpellType { get; set; }
        public IEnumerable<string> EffectNames { get; set; }
        public string AnimationPath { get; set; }
        public int AnimationWidth { get; set; }
        public int AnimationHeight { get; set; }

        public static implicit operator SpellInfo(string data)
        {
            string[] values = data.Split(";");
            SpellInfo info = new SpellInfo { Name = values[0], AnimationPath = values[2] };
            if (values[0].ToLower().Equals("projectile"))
            {
                info.SpellType = SpellType.Projectile;

            }
            else
            {
                throw new ArgumentException();
            }

            return info;
        }
    }

}
