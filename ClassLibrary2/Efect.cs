﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class Efect
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int time { get; set; }
        public Stats FixedStats { get; set; }
        public Stats MStats { get; set; }
        public int Duration { get; set; }
    }
}
