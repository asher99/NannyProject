using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Xml.Linq;
using DS;
using static DS.DataSource;

namespace DAL
{
    internal class Dal_XML_imp //: Idal
    {
        /// <summary>
        /// checks if nanny exists in DS and then adds to DS
        /// </summary>
        /// <param name="nanny"></param>
        void addNanny(Nanny nanny)
        {
            var temp = (from n in DataSourceXml.Nannys.Elements()
                        where Convert.ToInt32(n.Element("id").Value) == nanny.id
                        select n).FirstOrDefault();
            if (temp == null)
            {
                DataSourceXml.Nannys.Add(nanny.toXML());
                DataSourceXml.SaveNannys();
            }
            else
                throw new Exception("nanny already in list\n");

        }

        /// <summary>
        /// removes a nanny from DS
        /// </summary>
        /// <param name="nanny"></param>
        void deleteNanny(Nanny nanny)
        {
            XElement nannyElement = (from n in DataSourceXml.Nannys.Elements()
                                     where Convert.ToInt32(n.Element("id").Value) == nanny.id
                                     select n).FirstOrDefault();
            if (nannyElement != null)
            {
                nannyElement.Remove();
                DataSourceXml.SaveNannys();
            }
            else
                throw new Exception("nanny is not in list\n");

        }

        /// <summary>
        /// gets a nanny from UI and updates the information in the DS
        /// </summary>
        /// <param name="nanny"></param>
        void updateNanny(Nanny nanny)
        {
            XElement nannyElement = (from n in DS.DataSourceXml.Nannys.Elements()
                                     where Convert.ToInt32(n.Element("id").Value) == nanny.id
                                     select n).FirstOrDefault();

            if (nannyElement != null)
            {
                nannyElement.Remove();
                DataSourceXml.Nannys.Add(nanny.toXML());
                DataSourceXml.SaveNannys();
            }
            else
                throw new Exception("the nanny is not in the system.\n");
        }

        /// <summary>
        /// adds a mother to list
        /// </summary>
        /// <param name="mother"></param>
        void addMother(Mother mother)
        {
            var temp = (from m in DataSourceXml.Mothers.Elements()
                        where Convert.ToInt32(m.Element("id").Value) == mother.id
                        select m).FirstOrDefault();
            if (temp == null)
            {
                DataSourceXml.Mothers.Add(mother.toXML());
                DataSourceXml.SaveMothers();
            }
            else
                throw new Exception("you are trying to add a existing mother.\n");
        }

        /// <summary>
        /// deletes mother from list
        /// 
        /// </summary>
        /// <param name="mother"></param>
        void deleteMother(Mother mother)
        {
            XElement motherElement = (from n in DataSourceXml.Mothers.Elements()
                                      where Convert.ToInt32(n.Element("id").Value) == mother.id
                                      select n).FirstOrDefault();
            if (motherElement != null)
            {
                motherElement.Remove();
                DataSourceXml.SaveMothers();
            }
            else
                throw new Exception("you are trying to delete a mother that does not exist\n");
        }

        /// <summary>
        /// update mothers info in list
        /// </summary>
        /// <param name="mother"></param>
        void updateMother(Mother mother)
        {
            XElement motherElement = (from m in DataSourceXml.Mothers.Elements()
                                      where Convert.ToInt32(m.Element("id").Value) == mother.id
                                      select m).FirstOrDefault();

            if (motherElement != null)
            {
                motherElement.Remove();
                DataSourceXml.Mothers.Add(mother.toXML());
                DataSourceXml.SaveMothers();
            }
            else
                throw new Exception("the mother is not in the system.\n");
        }

        /// <summary>
        /// adds child to list
        /// </summary>
        /// <param name="child"></param>
        void addChild(Child child)
        {
            var temp = (from c in DataSourceXml.Children.Elements()
                        where Convert.ToInt32(c.Element("id").Value) == child.id
                        select c).FirstOrDefault();
            if (temp == null)
            {
                DataSourceXml.Children.Add(child.toXML());
                DataSourceXml.SaveChildren();
            }
            else
                throw new Exception("you are trying to add a existing child.\n");
        }

        /// <summary>
        /// removes child from list
        /// </summary>
        /// <param name="child"></param>
        void deleteChild(Child child)
        {
            XElement childElement = (from n in DataSourceXml.Children.Elements()
                                     where Convert.ToInt32(n.Element("id").Value) == child.id
                                     select n).FirstOrDefault();
            if (childElement != null)
            {
                childElement.Remove();
                DataSourceXml.Children.Add(child.toXML());
                DataSourceXml.SaveChildren();
            }
            else
                throw new Exception("child is not in the system\n");
        }


        /// <summary>
        /// updates child info
        /// </summary>
        /// <param name="child"></param>
        void updateChild(Child child)
        {
            XElement childElement = (from c in DataSourceXml.Children.Elements()
                                     where Convert.ToInt32(c.Element("id").Value) == child.id
                                     select c).FirstOrDefault();

            if (childElement != null)
            {
                childElement.Remove();
                DataSourceXml.Children.Add(child.toXML());
                DataSourceXml.SaveChildren();
            }
            else
                throw new Exception("the child is not in the system.\n");

        }


        /// <summary>
        /// adds a contract to list
        /// </summary>
        /// <param name="contract"></param>
        void addContract(Contract contract)
        {
            var temp = (from c in DataSourceXml.Contracts.Elements()
                        where Convert.ToInt32(c.Element("numberOfContract").Value) == contract.numberOfContract
                        select c).FirstOrDefault();
            if (temp == null)
            {
                DataSourceXml.Contracts.Add(contract.toXML());
                DataSourceXml.SaveContracts();
            }
            else
                throw new Exception("the contract is already in the system.\n");
        }


        /// <summary>
        /// removes a contract
        /// </summary>
        /// <param name="contract"></param>
        void deleteContract(Contract contract)
        {
            XElement contractElement = (from n in DataSourceXml.Contracts.Elements()
                                        where Convert.ToInt32(n.Element("numberOfContract").Value) == contract.numberOfContract
                                        select n).FirstOrDefault();
            if (contractElement != null)
            {
                contractElement.Remove();
                DataSourceXml.Contracts.Add(contract.toXML());
                DataSourceXml.SaveContracts();
            }
            else
                throw new Exception("the contract is not in the system.\n");
        }

        /// <summary>
        /// updates contract info
        /// </summary>
        /// <param name="contract"></param>
        void updateContract(Contract contract)
        {
            var temp = (from c in DataSourceXml.Contracts.Elements()
                        where Convert.ToInt32(c.Element("numberOfContract").Value) == contract.numberOfContract
                        select c).FirstOrDefault();

            if (temp != null)
            {
                temp.Remove();
                DataSourceXml.Contracts.Add(contract.toXML());
                DataSourceXml.SaveContracts();
            }
            else
                throw new Exception("the contract is not in the system.\n");
        }

        // gets for all of the data in data source
        IEnumerable<Nanny> getListOfNanny()
        {
            XElement root = DataSourceXml.Nannys;
            List<Nanny> result = new List<Nanny>();
            foreach (var n in root.Elements("Nannys"))
            {
                result.Add(n.toNanny());
            }
            return result.AsEnumerable();
        }

        IEnumerable<Mother> getListOfMother()
        {
            XElement root = DataSourceXml.Mothers;
            List<Mother> result = new List<Mother>();
            foreach (var m in root.Elements("Mothers"))
            {
                result.Add(m.toMother());
            }
            return result.AsEnumerable();
        }

        IEnumerable<Child> getListOfChild()
        {
            XElement root = DataSourceXml.Children;
            List<Child> result = new List<Child>();
            foreach (var c in root.Elements("Children"))
            {
                result.Add(c.toChild());
            }
            return result.AsEnumerable();
        }

        IEnumerable<Contract> getListOfContract()
        {
            XElement root = DataSourceXml.Contracts;
            List<Contract> result = new List<Contract>();
            foreach (var c in root.Elements("Contracts"))
            {
                result.Add(c.toContract());
            }
            return result.AsEnumerable();
        }

        // scan all ids in all lists
        bool IdExist(int id)
        {
            return (isChildInList(id) || isMotherInList(id) || isNannyInList(id));
        }

        /// <summary>
        /// special static serial number for contracts
        /// </summary>
        static int contractsSerialNumber = 45687652;

        /// <summary>
        /// gives a contract a serial number
        /// </summary>
        /// <param name="contract"></param>
        /// <returns></returns>
        bool initalizeContractNumber(Contract contract)
        {
            if (IdExist(contract.NannysId) && IdExist(getMotherId(contract.childId)))
            {
                contract.numberOfContract = contractsSerialNumber + 3;
                contractsSerialNumber++;
                contract.isSingedContract = true;// now contract is signed

                return true;
            }
            else return false;
        }


        /// <summary>
        /// checks if nanny's id is in the DS
        /// </summary>
        /// <param name="nannyId"></param>
        /// <returns>bool</returns>
        bool isNannyInList(int id)
        {
            return (from n in DataSourceXml.Nannys.Elements()
                    where Convert.ToInt32(n.Element("id").Value) == id
                    select n).Any();
        }

        /// <summary>
        /// checks if mother is in list
        /// </summary>
        /// <param name="motherId"></param>
        /// <returns></returns>
        bool isMotherInList(int id)
        {
            return (from m in DataSourceXml.Mothers.Elements()
                    where Convert.ToInt32(m.Element("id").Value) == id
                    select m).Any();
        }

        /// <summary>
        /// checks if child is on list
        /// </summary>
        /// <param name="childId"></param>
        /// <returns></returns>
        bool isChildInList(int id)
        {
            return (from c in DataSourceXml.Children.Elements()
                    where Convert.ToInt32(c.Element("id").Value) == id
                    select c).Any();
        }

        /// <summary>
        /// checks if contract is on list
        /// </summary>
        /// <param name="contract"></param>
        /// <returns></returns>
        bool isContractInList(Contract contract)
        {
            return (from c in DataSourceXml.Contracts.Elements()
                    where Convert.ToInt32(c.Element("numberOfContract").Value) == contract.numberOfContract
                    select c).Any();
        }


        /// <summary>
        /// gets mothers id by using her childes id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int getMotherId(int id)
        {
            XElement root = DataSourceXml.Children;

            foreach (var c in root.Elements("Children"))
            {
                if (Convert.ToInt32(c.Element("id").Value) == id)
                    return Convert.ToInt32(c.Element("momsId").Value);
            }

            return -1;
        }

        /// <summary>
        /// returns a list of all the contract that a id is involved
        /// </summary>
        /// <param name="my_id"></param>
        /// <returns></returns>
        IEnumerable<Contract> ListOfContractsById(int my_id)
        {
            XElement root = DataSourceXml.Contracts;
            List<Contract> result = new List<Contract>();
            foreach (var c in root.Elements("Contracts"))
            {
                if (Convert.ToInt32(c.Element("NannysId").Value) == my_id || Convert.ToInt32(c.Element("childId").Value) == my_id)
                    result.Add(c.toContract());
            }

            return result.AsEnumerable();
        }

        /// <summary>
        /// return a list of all of a mothers children
        /// </summary>
        /// <param name="mother"></param>
        /// <returns></returns>
        IEnumerable<Child> getListOfChildByMother(Mother mother)
        {
            XElement root = DataSourceXml.Children;
            List<Child> result = new List<Child>();
            foreach (var c in root.Elements("Children"))
            {
                if (Convert.ToInt32(c.Element("momsId").Value) == mother.id)
                    result.Add(c.toChild());
            }

            return result.AsEnumerable();
        }

        /// <summary>
        /// returns a list of all the children in the group of a nanny
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<Child> getListOfChildrenOfNanny(int id)
        {
            IEnumerable<Child> item = null;
            foreach (var contract in ListOfContractsById(id))
            {
                item = from child in getListOfChild()
                       where contract.childId == child.id
                       select child;
            }

            return item;
        }

        /// <summary>
        /// select from a list of children only the children that suitable for a nanny.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="nanny"></param>
        /// <returns></returns>
        IEnumerable<Child> checkAgeOfKids(IEnumerable<Child> list, Nanny nanny)
        {
            return from child in list
                   let age = child.ageInMonths()
                   where nanny.maxAgeOfKid > age && nanny.minAgeOfKid <= age
                   select child;
        }

        /// <summary>
        /// Return list of contracts by mother
        /// </summary>
        /// <param name="thisMother"></param>
        /// <returns></returns>
        IEnumerable<Contract> getListOfContractByMother(Mother thisMother)
        {
            List<Contract> contracts = new List<Contract>();
            foreach (Child kid in getListOfChildByMother(thisMother))
            {
                if (ListOfContractsById(kid.id).Any())
                    contracts.Add(ListOfContractsById(kid.id).ElementAt(0));
            }

            return contracts.AsEnumerable();
        }
    }
}
