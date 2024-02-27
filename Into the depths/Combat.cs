using Into_the_depths.Classes;
using Into_the_depths.Monster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Into_the_depths
{
    public static class Combat
    {
        private static Character selectedChar;
        private static BaseMonster selectedMonster;
        private static bool whoAttacks;
        public static void MeleeCombat(Character c, BaseMonster m, bool b) 
        { 
            selectedChar = c;
            selectedMonster = m;
            whoAttacks = b;
            if (whoAttacks)
            {

            }
            else
            {

            }
        }
    }
}
