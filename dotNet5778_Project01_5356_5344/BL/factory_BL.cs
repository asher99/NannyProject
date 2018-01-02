using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class factory_BL
    {
        private static IBL bl;
        protected factory_BL() { }//
         static factory_BL()//
        {
            bl = new IBL_imp();
        }
        public static IBL Get_bl
        {
            get
            {
                if (bl == null)
                {
                    bl = new IBL_imp();
                }
                return bl;
            }
        }
    }
}
/*
 public class FactoryBL
    {
        private static IBL bl_instance;

        private FactoryBL() { }
        static FactoryBL() { bl_instance = new BL_imp(); } // called once at program startup

        public static IBL IBLInstance { get { return bl_instance; } }
    }
     */
