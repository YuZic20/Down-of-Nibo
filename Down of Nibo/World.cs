﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Down_of_Nibo
{
    class World
    {
        public int Turns { get; set; }
        public Map WorldMap { get; set; }

        public bool HaveTimeleft()
        {
            if (Turns > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void SetTime(int Time)
        {
            Turns = Time;
        }
    }
}