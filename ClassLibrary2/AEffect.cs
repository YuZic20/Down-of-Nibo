﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class AEffect
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Stats FixedStats { get; set; } = new Stats();
        public Stats MStats { get; set; } = new Stats();

    }

}
