using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Into_the_depths.HeroClasses
{
    public abstract class Hero
    {
        public abstract int Strength { get; set; }
        public abstract int Agility { get; set; }
        public abstract int Intellect { get; set; }
        public abstract int Spirit { get; set; }

        public abstract int Stamina { get; set; }

        public abstract int Armor { get; set; }
        public abstract int PhysicalDefense { get; set; }
        public abstract int MagicDefense { get; set; }

        public abstract int FireResist { get; set; }
        public abstract int ColdResist { get; set; }
        public abstract int PoisonResist { get; set; }
        public abstract int ArcaneResist { get; set; }


    }
}
