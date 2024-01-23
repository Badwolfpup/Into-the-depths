using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Into_the_depths.HeroClasses
{
    public class Character
    {
        public string CharacterName { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intellect { get; set; }
        public int Spirit { get; set; }
        public int Stamina { get; set; }

        public int HP { get; set; }
        public int MP { get; set; }
        public int XP { get; set; }

        public int Armor { get; set; }
        public int MagicDefense { get; set; }

        public Character(string charactername, int str, int agi, int inte, int spi, int sta, int hp, int mp, int xp, int armor, int magicdefense)
        {
            CharacterName = charactername;
            Strength = str;
            Agility = agi;
            Intellect = inte;
            Spirit = spi;
            Stamina = sta;
            HP = hp;
            MP = mp;
            XP = xp;
            Armor = armor;
            MagicDefense = magicdefense;
        }
    }
}
