using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace DS
{
    /// <summary>
    /// the Data Source
    /// all the data in the program is stored here
    /// only the DAL level can extract or store data in this level
    /// includes 4 types of lists 
    /// for this program example we stored few object for long term use
    /// </summary>
    public class DataSource
    {
        public static List<Nanny> listOfNannys = new List<Nanny>();
        public static List<Mother> listOfMothers = new List<Mother>();
        public static List<Child> listOfChilds = new List<Child>();
        public static List<Contract> listOfContracts = new List<Contract>();

        // stored object for long term use of this project
    }
}
