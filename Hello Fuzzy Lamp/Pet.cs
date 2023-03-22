using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Fuzzy_Lamp
{
    class Pet
    {
        int hungry = 0;
        public int Hungry { 
            get
            {
                return hungry;
            }
            set
            {
                hungry = Math.Min(10, value);
                hungry = Math.Max(0, value);
            } 
        }
        int boredom = 0;
        public int Boredom
        {
            get
            {
                return boredom;
            }
            set
            {
                boredom = Math.Min(10, value);
                boredom = Math.Max(0, value);
            }
        }
    }
}
