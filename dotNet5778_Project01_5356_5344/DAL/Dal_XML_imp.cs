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
    internal class Dal_XML_imp //: Idal
    {
        void addNanny(Nanny nanny)
        {
            var temp = (from n in DataSourceXml.Nannys.Elements()
                        where Convert.ToInt32(n.Element("id").Value) == nanny.id
                        select n).FirstOrDefault();
            if (temp != null)
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

            // here we update...

            DataSourceXml.SaveNannys();
        }

        Nanny nannyById(int id)
        {
            throw new NotImplementedException();
        }

        void addMother(Mother mother)
        {
            var temp = (from m in DataSourceXml.Mothers.Elements()
                        where Convert.ToInt32(m.Element("id").Value) == mother.id
                        select m).FirstOrDefault();
            if (temp != null)
            {
                DataSourceXml.Mothers.Add(mother.toXML());
                DataSourceXml.SaveMothers();
            }

        }

        void deleteMother(Mother mother)
        {
            XElement motherElement = (from n in DataSourceXml.Mothers.Elements()
                                      where Convert.ToInt32(n.Element("id").Value) == mother.id
                                      select n).FirstOrDefault();
            motherElement.Remove();

            DataSourceXml.SaveMothers();
        }

        void updateMother(Mother mother)
        {
            throw new NotImplementedException();
        }

        void addChild(Child child)
        {
            throw new NotImplementedException();
        }

        void deleteChild(Child child)
        {
            XElement childElement = (from n in DataSourceXml.Children.Elements()
                                     where Convert.ToInt32(n.Element("id").Value) == child.id
                                     select n).FirstOrDefault();
            childElement.Remove();

            DataSourceXml.SaveChildren();
        }

        void updateChild(Child child)
        {
            throw new NotImplementedException();
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
            contractElement.Remove();

            DataSourceXml.SaveContracts();
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
            throw new NotImplementedException();
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
