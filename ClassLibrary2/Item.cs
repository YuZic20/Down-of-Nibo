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
        public bool Eqipible { get; set; }
        
        public List<AEfect> Efects {get; set; }
    }
}
