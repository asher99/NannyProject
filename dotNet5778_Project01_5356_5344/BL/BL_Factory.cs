using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    /// <summary>
    /// factory bl in charge of pointing to a bl interface that is used
    /// in order not to create more then one 
    /// </summary>
    public class BL_Factory
    {
        private static IBL bl;

        private BL_Factory() { }

        static BL_Factory() { bl = new IBL_imp(); }

        /// <summary>
        /// gets the bl that is open
        /// </summary>  
        public static IBL Get_BL { get { return bl; } }
    }
}

