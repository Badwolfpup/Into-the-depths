using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Into_the_depths.Monster
{
    public class BaseMonster
    {
        public string CharacterName { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intellect { get; set; }
        public int Spirit { get; set; }
        public int Stamina { get; set; }

        public int MaxHP { get; set; }

        public int CurrentHP { get; set; }
        public int MaxMP { get; set; }

        public int CurrentMP { get; set; }
        public int XP { get; set; }

        public int Level { get; set; }

        public int Armor { get; set; }
        public int MagicDefense { get; set; }

        public BaseMonster(string charactername, int str, int agi, int inte, int spi, int sta, int hp, int mp, int xp, int armor, int magicdefense, int level)
        {
            CharacterName = charactername;
            Strength = str;
            Agility = agi;
            Intellect = inte;
            Spirit = spi;
            Stamina = sta;
            MaxHP = hp;
            CurrentHP = hp;
            MaxMP = mp;
            CurrentMP = mp;
            XP = xp;
            Armor = armor;
            MagicDefense = magicdefense;
            Level = level;
        }

        public void AdjustForLevel()
        {
            //Some logic to adjust the values dependings on level
        }
    }
}
