using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Xml.Linq;
namespace DAL
{
    class Dal_XML_imp : Idal
    {
        void addNanny(Nanny nanny)
        {
            throw new NotImplementedException();
        }

        void deleteNanny(Nanny nanny)
        {
            throw new NotImplementedException();
        }

        void updateNanny(Nanny nanny)
        {
            throw new NotImplementedException();
        }

        Nanny nannyById(int id)
        {
            throw new NotImplementedException();
        }

        void addMother(Mother mother)
        {
            throw new NotImplementedException();
        }

        void deleteMother(Mother mother)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
