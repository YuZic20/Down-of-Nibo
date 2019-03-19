using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Down_of_Nibo
{
    class World
    {
        
        public RegionMap WorldMap { get; set; }
        

        public bool HaveTimeleft(int Turns)
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
    }

}
