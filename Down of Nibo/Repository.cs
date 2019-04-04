using ClassLibrary2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Down_of_Nibo
{
    public static class Repository
    {
        public static List<Item> AllItems { get; set; } = new List<Item>();
        public static List<Combo> AllCombos { get; set; } = new List<Combo>();
        public static List<Mob> AllMobs { get; set; } = new List<Mob>();
        public static List<Effect_Duration> AllEffects { get; set; } = new List<Effect_Duration>();


    }
}
