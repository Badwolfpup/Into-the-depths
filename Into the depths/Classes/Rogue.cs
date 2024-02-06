using Into_the_depths.Classes;

namespace Into_the_depths.Classes
{
    class Rogue : Character
    {
        public string ClassName { get; set; }
        public string IconPath { get; set; }


        public Rogue(string charactername, int strength, int agility, int intellect, int spirit, int stamina, int hp, int mp, int xp, int armor, int magicdefense)
            : base(charactername, strength, agility, intellect, spirit, stamina, hp, mp, xp, armor, magicdefense)
        {
            ClassName = "Rogue";
            IconPath = "pack://application:,,,/Into the depths;component/Image/Icon/rogue%20ikon.jpg";
        }
    }
}
