﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Down_of_Nibo
{
    class Eqiped
    {
        public Item helmet { get; set; }
        public Item Body { get; set; }
        public Item Shoes { get; set; }
        public Item Weapon { get; set; }
        public List<Item> Consumed { get; set; }
    }
}