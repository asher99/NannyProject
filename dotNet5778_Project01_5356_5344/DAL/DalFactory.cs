using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /*public class DalFactory
    {
        public static Idal GetDAL()
        {
            return new Dal_imp();
        }
    }*/
    /*public class DalFactory
    {
        private static Idal dal;
        private DalFactory() { }//
        static DalFactory()//
        {
            dal = new Dal_imp();
        }
        public static Idal Get_dal
        {
            get
            {
                if (dal == null)
                {
                    dal = new Dal_imp();
                }
                return dal;
            }
        }
    }*/
    public class DalFactory
    {
        private static Idal dal_instance;

        private DalFactory() { }
        static DalFactory() { dal_instance = new Dal_imp(); } // called once at program startup

        public static Idal DALInstance { get { return dal_instance; } }
    }
}
