﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Into_the_depths.Items.Equipment
{
    public class MainHand : BaseEquipment
    {
        public MainHand(string name, int str, int agi, int inte, int spi, int sta, int armor, int magicdefense)
            : base(name, str, agi, inte, spi, sta, armor, magicdefense)
        {
        }
    }
}
