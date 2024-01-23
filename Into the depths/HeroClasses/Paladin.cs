using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Into_the_depths.HeroClasses
{
    internal class Paladin : Hero
    {
        public override int Strength { get; set; }
        public override int Agility { get; set; }
        public override int Intellect { get; set; }
        public override int Spirit { get; set; }
        public override int Stamina { get; set; }
        public override int Armor { get; set; }
        public override int PhysicalDefense { get; set; }
        public override int MagicDefense { get; set; }
        public override int FireResist { get; set; }
        public override int ColdResist { get; set; }
        public override int PoisonResist { get; set; }
        public override int ArcaneResist { get; set; }
    }
}
