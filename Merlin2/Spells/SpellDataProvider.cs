using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Merlin2.Spells
{
    public class SpellDataProvider : ISpellDataProvider
    {
        private static SpellDataProvider instance = null;

        private Dictionary<string, int> spelleffects;
        private Dictionary<string, SpellInfo> spellInfo;

        private SpellDataProvider()
        {

        }
        public static SpellDataProvider GetInstance()
        {
            if(instance == null)
            {
                instance = new SpellDataProvider();
            }
            return instance;
        }
        public Dictionary<string, int> GetSpellEffects()
        {
            return spelleffects;
        }

        public Dictionary<string, SpellInfo> GetSpellInfo()
        {
            return spellInfo;        }

        private Dictionary<string,SpellInfo> LoadSpellInfo()
        {
            List<string> lines = File.ReadAllLines("resources/spells.csv").Skip(1).ToList();

            Dictionary<string, SpellInfo> dictionary = new Dictionary<string, SpellInfo>();

            foreach(string line in lines)
            {
                try
                {
                SpellInfo info = line;
                dictionary.Add(info.Name,info);
                }
                catch(ArgumentException e)
                {
                    Console.WriteLine(e);
                }
               
            }
            return dictionary;
        }
    }
}
