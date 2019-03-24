using ClassLibrary2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Down_of_Nibo
{
    public static class Globals
    {
        public static List<Combo> leaarndCombos = new List<Combo>();
        public static int Turns { get; set; } = 100;
        public static Character Player { get; set; } = new Character();
        public static Mob[] Mobs { get; set; } = new Mob[3];
        public static List<RegionMap> regionMaps { get; set; } = new List<RegionMap>();
        public static Stats Traing { get; set; }
        //add curent fraim
    }
}
