﻿using ClassLibrary2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Down_of_Nibo
{
    class Quest
    {
        public int decription { get; set; }
        public  Mob[] Mobs { get; set; } = new Mob[3];
        public Item Reward { get; set; }


        public void StartBattle()
        {
            Mobs.CopyTo(Globals.Mobs,0);
            //start battle
        }
    }
}
