using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class Item
    {
        public string Name { get; set; }

        //public enum Eqipible { Not, head, Body, Weapon };
        public int Eqip { get; set; }
        public bool usable { get; set; }

        public List<AEffect> Efects {get; set; }
    }
}
