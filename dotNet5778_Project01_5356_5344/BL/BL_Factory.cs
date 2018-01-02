using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BL_Factory
    {
        private static IBL bl;

        private BL_Factory() { }
        static BL_Factory() { bl = new IBL_imp(); } 

        public static IBL Get_BL { get { return bl; } }
    }
}

