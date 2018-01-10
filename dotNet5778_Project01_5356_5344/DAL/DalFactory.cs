using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{   
    public class DalFactory
    {
        private static Idal dal;

        private DalFactory() { }

        static DalFactory() { dal = new Dal_imp(); }
        //static DalFactory() { dal = new Dal_XML_imp(); }

        public static Idal Get_DAL { get { return dal; } }
    }
}
