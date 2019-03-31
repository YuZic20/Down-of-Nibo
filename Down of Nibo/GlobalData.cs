using ClassLibrary2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Down_of_Nibo
{
    public class GlobalData
    {
        public List<Combo> learndCombos = new List<Combo>();
        public int Turns { get; set; } = 100;
        public Character Player { get; set; } = new Character();
        public Mob[] Mobs { get; set; } = new Mob[3];

        public List<Quest>[] Quests { get; set; } = new List<Quest>[3];
        public Stats Training { get; set; } = new Stats();

    }
}
