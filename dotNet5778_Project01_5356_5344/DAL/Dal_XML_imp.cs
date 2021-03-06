﻿using System;
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
    /// <summary>
    /// implantation for all DAL methods
    /// this layer is in charge of taking care of all the data process in this program
    /// each function helps the process either go to upper levels or writes into the Data Source XML
    /// </summary>
    internal class Dal_XML_imp : Idal
    {
        /// <summary>
        /// checks if nanny exists in DS and then adds to DS
        /// </summary>
        /// <param name="nanny"></param>
        public void addNanny(Nanny nanny)
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
        public void deleteNanny(Nanny nanny)
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
        public void updateNanny(Nanny nanny)
        {
            XElement nannyElement = (from n in DS.DataSourceXml.Nannys.Elements()
                                     where Convert.ToInt32(n.Element("id").Value) == nanny.id
                                     select n).FirstOrDefault();

            if (nannyElement != null)
            {
                nannyElement.ReplaceWith(nanny.toXML());
                DataSourceXml.SaveNannys();
            }
            else
                throw new Exception("the nanny is not in the system.\n");
        }

        /// <summary>
        /// adds a mother to list
        /// </summary>
        /// <param name="mother"></param>
        public void addMother(Mother mother)
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
        /// </summary>
        /// <param name="mother"></param>
        public void deleteMother(Mother mother)
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
        public void updateMother(Mother mother)
        {
            XElement motherElement = (from m in DataSourceXml.Mothers.Elements()
                                      where Convert.ToInt32(m.Element("id").Value) == mother.id
                                      select m).FirstOrDefault();

            if (motherElement != null)
            {
                motherElement.ReplaceWith(mother.toXML());
                DataSourceXml.SaveMothers();
            }
            else
                throw new Exception("the mother is not in the system.\n");
        }

        /// <summary>
        /// adds child to list
        /// </summary>
        /// <param name="child"></param>
        public void addChild(Child child)
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
        public void deleteChild(Child child)
        {
            XElement childElement = (from n in DataSourceXml.Children.Elements()
                                     where Convert.ToInt32(n.Element("id").Value) == child.id
                                     select n).FirstOrDefault();
            if (childElement != null)
            {
                childElement.Remove();
                DataSourceXml.SaveChildren();
            }
            else
                throw new Exception("child is not in the system\n");
        }


        /// <summary>
        /// updates child info
        /// </summary>
        /// <param name="child"></param>
        public void updateChild(Child child)
        {
            XElement childElement = (from c in DataSourceXml.Children.Elements()
                                     where Convert.ToInt32(c.Element("id").Value) == child.id
                                     select c).FirstOrDefault();

            if (childElement != null)
            {
                childElement.ReplaceWith(child.toXML());
                DataSourceXml.SaveChildren();
            }
            else
                throw new Exception("the child is not in the system.\n");

        }


        /// <summary>
        /// adds a contract to list
        /// </summary>
        /// <param name="contract"></param>
        public void addContract(Contract contract)
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
        public void deleteContract(Contract contract)
        {
            XElement contractElement = (from n in DataSourceXml.Contracts.Elements()
                                        where Convert.ToInt32(n.Element("numberOfContract").Value) == contract.numberOfContract
                                        select n).FirstOrDefault();
            if (contractElement != null)
            {
                contractElement.Remove();
                DataSourceXml.SaveContracts();
            }
            else
                throw new Exception("the contract is not in the system.\n");
        }

        /// <summary>
        /// updates contract info
        /// </summary>
        /// <param name="contract"></param>
        public void updateContract(Contract contract)
        {
            var temp = (from c in DataSourceXml.Contracts.Elements()
                        where Convert.ToInt32(c.Element("numberOfContract").Value) == contract.numberOfContract
                        select c).FirstOrDefault();

            if (temp != null)
            {
                temp.ReplaceWith(contract.toXML());
                DataSourceXml.SaveContracts();
            }
            else
                throw new Exception("the contract is not in the system.\n");
        }

        // return list of all nannys stored in the Data Source
        public IEnumerable<Nanny> getListOfNanny()
        {
            XElement root = DataSourceXml.Nannys;
            List<Nanny> result = new List<Nanny>();
            foreach (var n in root.Elements("Nanny"))
            {
                result.Add(n.toNanny());
            }
            return result.AsEnumerable();
        }

        // return list of all mothers stored in the Data Source
        public IEnumerable<Mother> getListOfMother()
        {
            XElement root = DataSourceXml.Mothers;
            List<Mother> result = new List<Mother>();
            foreach (var m in root.Elements("Mother"))
            {
                result.Add(m.toMother());
            }
            return result.AsEnumerable();
        }

        // return list of all children stored in the Data Source
        public IEnumerable<Child> getListOfChild()
        {
            XElement root = DataSourceXml.Children;
            List<Child> result = new List<Child>();
            foreach (var c in root.Elements("Child"))
            {
                result.Add(c.toChild());
            }
            return result.AsEnumerable();
        }

        // return list of all contracts stored in the Data Source
        public IEnumerable<Contract> getListOfContract()
        {
            XElement root = DataSourceXml.Contracts;
            List<Contract> result = new List<Contract>();
            foreach (var c in root.Elements("Contract"))
            {
                result.Add(c.toContract());
            }
            return result.AsEnumerable();
        }

        // scan all ids in all lists and return if a received id is exist
        public bool IdExist(int id)
        {
            return (isChildInList(id) || isMotherInList(id) || isNannyInList(id));
        }

        /// <summary>
        /// gives a contract a serial number
        /// </summary>
        /// <param name="contract"></param>
        /// <returns></returns>
        public bool initalizeContractNumber(Contract contract)
        {
            if (IdExist(contract.NannysId) && IdExist(getMotherId(contract.childId)))
            {
                //gets the serial number from XML file
                int contractsSerialNumber = Int32.Parse(DataSourceXml.ContractNumber.Element("serialNumber").Value);
                contract.numberOfContract = ++contractsSerialNumber;

                DataSourceXml.ContractNumber.Element("serialNumber").SetValue(contractsSerialNumber);
                DataSourceXml.SaveNumbers();

                contract.isSingedContract = true;           // now contract is signed

                return true;
            }
            else return false;
        }


        /// <summary>
        /// checks if nanny's id is in the DS
        /// </summary>
        /// <param name="nannyId"></param>
        /// <returns>bool</returns>
        public bool isNannyInList(int id)
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
        public bool isMotherInList(int id)
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
        public bool isChildInList(int id)
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
        public bool isContractInList(Contract contract)
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
        public int getMotherId(int id)
        {
            XElement root = DataSourceXml.Children;

            foreach (var c in root.Elements("Child"))
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
        public IEnumerable<Contract> ListOfContractsById(int my_id)
        {
            XElement root = DataSourceXml.Contracts;
            List<Contract> result = new List<Contract>();
            foreach (var c in root.Elements("Contract"))
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
        public IEnumerable<Child> getListOfChildByMother(Mother mother)
        {
            XElement root = DataSourceXml.Children;
            List<Child> result = new List<Child>();
            foreach (var c in root.Elements("Child"))
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
        public IEnumerable<Child> getListOfChildrenOfNanny(int id)
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
        public IEnumerable<Child> checkAgeOfKids(IEnumerable<Child> list, Nanny nanny)
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
        public IEnumerable<Contract> getListOfContractByMother(Mother thisMother)
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
