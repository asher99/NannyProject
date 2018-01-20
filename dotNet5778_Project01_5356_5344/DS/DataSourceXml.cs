/// Thank To Eliezer Ginzburger Phd for the Help in this file.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using DAL;
namespace DS
{
    /// <summary>
    /// in charge of saving and loading all of XML data using paths
    /// </summary>
    public static class DataSourceXml
    {
        // determine a directory for the XML files of this solutions
        private static string solutionDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName;

        // determine a path for the XML files
        private static string filePath = System.IO.Path.Combine(solutionDirectory, "DS", "dataSourceXML");

        // define path for the XML files:
        private static XElement motherRoot = null;
        static string motherPath = Path.Combine(filePath, "MothersXML.xml");

        private static XElement contractRoot = null;
        static string contractPath = Path.Combine(filePath, "ContractsXML.xml");

        private static XElement childRoot = null;
        static string childPath = Path.Combine(filePath, "ChildrenXML.xml");

        private static XElement nannyRoot = null;
        static string nannyPath = Path.Combine(filePath, "NannysXML.xml");

        private static XElement numberRoot = null;
        static string numberPath = Path.Combine(filePath, "serialNumber.xml");


        /// Static Constructor
        static DataSourceXml()
        {
            // check if default directory exist, if not - create it. 
            bool exists = Directory.Exists(filePath);

            if (!exists)
            {
                Directory.CreateDirectory(filePath);
            }

            // if needed files aren't exist - create them. anyway, load the data from those directories / files.
            if (!File.Exists(motherPath))
            {
                CreateFile("Mothers", motherPath);

            }
            else
            {
                motherRoot = LoadData(motherPath);
            }

            if (!File.Exists(contractPath))
            {
                CreateFile("Contracts", contractPath);
            }
            else
            {
                contractRoot = LoadData(contractPath);
            }

            if (!File.Exists(childPath))
            {
                CreateFile("Children", childPath);

            }
            else
            {
                childRoot = LoadData(childPath);
            }

            if (!File.Exists(nannyPath))
            {
                CreateFile("Nannys", nannyPath);

            }
            else
            {
                nannyRoot = LoadData(nannyPath);
            }

            if (!File.Exists(numberPath))
            {
                CreateFile("ContractNumber", nannyPath);

            }
            else
            {
                numberRoot = LoadData(numberPath);
            }
        }


        /// <summary>
        /// save the Xelement to the root.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="path"></param>
        public static void Save(XElement root, string path)
        {
            root.Save(path);
        }

        /// <summary>
        /// saves the mother path to the mother root.
        /// </summary>
        public static void SaveMothers()
        {
            motherRoot.Save(motherPath);
        }

        /// <summary>
        /// saves the contract path to the mother root.
        /// </summary>
        public static void SaveContracts()
        {
            contractRoot.Save(contractPath);
        }

        /// <summary>
        /// saves the children path to the mother root.
        /// </summary>
        public static void SaveChildren()
        {
            childRoot.Save(childPath);
        }

        /// <summary>
        /// saves the nanny path to the mother root.
        /// </summary>
        public static void SaveNannys()
        {
            nannyRoot.Save(nannyPath);
        }

        /// <summary>
        /// saves the serial number path to the mother root.
        /// </summary>
        public static void SaveNumbers()
        {
            numberRoot.Save(numberPath);
        }

        /// <summary>
        /// construct the XElement for Nannys.
        /// </summary>
        public static XElement Nannys
        {
            get
            {
                nannyRoot = LoadData(nannyPath);
                return nannyRoot;
            }
        }

        /// <summary>
        /// construct the XElement for Mothers.
        /// </summary>
        public static XElement Mothers
        {
            get
            {
                motherRoot = LoadData(motherPath);
                return motherRoot;
            }
        }

        /// <summary>
        /// construct the XElement for Children.
        /// </summary>
        public static XElement Children
        {
            get
            {
                childRoot = LoadData(childPath);
                return childRoot;
            }
        }

        /// <summary>
        /// construct the XElement for Contracts.
        /// </summary>
        public static XElement Contracts
        {
            get
            {
                contractRoot = LoadData(contractPath);
                return contractRoot;
            }
        }

        /// <summary>
        /// construct the XElement for the contract Serial number.
        /// </summary>
        public static XElement ContractNumber
        {
            get
            {
                numberRoot = LoadData(numberPath);
                return numberRoot;
            }
        }

        /// Create XML file.
        private static void CreateFile(string typename, string path)
        {
            XElement root = new XElement(typename);
            root.Save(path);
        }

        /// load the XML file.
        private static XElement LoadData(string path)
        {
            XElement root;
            try
            {
                root = XElement.Load(path);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
            return root;
        }
    }
}


