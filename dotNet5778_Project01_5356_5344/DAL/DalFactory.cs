﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DalFactory
    {
        public static Idal GetDAL()
        {
            return new Dal_imp();
        }
    }
}