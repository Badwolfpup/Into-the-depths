using Into_the_depths.Classes;

namespace Into_the_depths.Classes
{
    class Warrior : Character
    {

        public string ClassName { get; set; }
        public string IconPath { get; set; }

        public Warrior(string charactername, int strength, int agility, int intellect, int spirit, int stamina, int hp, int mp, int xp, int armor, int magicdefense, string saveid)
           : base(charactername, strength, agility, intellect, spirit, stamina, hp, mp, xp, armor, magicdefense, saveid)
        {
            ClassName = "Warrior";
            IconPath = "pack://application:,,,/Into the depths;component/Image/Icon/warrior%20ikon.jpg";
        }
    }
}
