using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Down_of_Nibo
{
    class Item
    {
        public string Name { get; set; }
        public int Eqipible { get; set; }//duration přidat
        public List<Efect> Efects {get; set; }
    }
}
