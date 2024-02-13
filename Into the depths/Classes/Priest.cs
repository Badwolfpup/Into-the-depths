using Into_the_depths.Classes;

namespace Into_the_depths.Classes
{
    class Priest : Character
    {
        public string ClassName { get; set; }
        public string IconPath { get; set; }


        public Priest(string charactername, int strength, int agility, int intellect, int spirit, int stamina, int hp, int mp, int xp, int armor, int magicdefense, string saveid)
           : base(charactername, strength, agility, intellect, spirit, stamina, hp, mp, xp, armor, magicdefense, saveid)
        {
            ClassName = "Priest";
            IconPath = "pack://application:,,,/Into the depths;component/Image/Icon/priest%20ikon.jpg";
        }
    }
}
