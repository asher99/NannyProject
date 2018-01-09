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

        void addContract(Contract contract)
        {
            throw new NotImplementedException();
        }

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

        void updateContract(Contract contract)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Nanny> getListOfNanny()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        IEnumerable<Contract> getListOfContract()
        {
            throw new NotImplementedException();
        }

        // scan all ids in all lists
        bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        bool initalizeContractNumber(Contract contract)
        {
            throw new NotImplementedException();
        }

        bool isNannyInList(int nanny)
        {
            throw new NotImplementedException();
        }

        bool isMotherInList(int mother)
        {
            throw new NotImplementedException();
        }

        bool isChildInList(int child)
        {
            throw new NotImplementedException();
        }

        bool isContractInList(Contract contract)
        {
            throw new NotImplementedException();
        }

        int getMotherId(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Contract> ListOfContractsById(int my_id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Child> getListOfChildByMother(Mother mother)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Child> getListOfChildrenOfNanny(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Child> checkAgeOfKids(IEnumerable<Child> list, Nanny nanny)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Contract> getListOfContractByMother(Mother thisMother)
        {
            throw new NotImplementedException();
        }
    }
}
