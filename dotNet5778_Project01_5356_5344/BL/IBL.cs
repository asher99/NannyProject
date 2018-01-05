using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;


namespace BL
{
    /// <summary>
    /// the interface of the BL layer
    /// points to all the methods that are defined in IBL_imp
    /// </summary>
   public interface IBL
    {
        void addNanny(Nanny nanny);
        void deleteNanny(Nanny nanny);
        void updateNanny(Nanny nanny);
        Nanny nannyById(int id);

        void addMother(Mother mother);
        void deleteMother(Mother mother);
        void updateMother(Mother mother);

        void addChild(Child child);
        void deleteChild(Child child);
        void updateChild(Child child);

        void addContract(Contract contract);
        void deleteContract(Contract contract);
        void updateContract(Contract contract);

        IEnumerable<Nanny> getListOfNanny();
        IEnumerable<Mother> getListOfMother();
        IEnumerable<Child> getListOfChild();
        IEnumerable<Contract> getListOfContract();

        // scan all ids in all lists
        bool IdExist(int id);

        bool initalizeContractNumber(Contract contract);

        bool isNannyInList(int nanny);
        bool isMotherInList(int mother);
        bool isChildInList(int child);
        bool isContractInList(Contract contract);

        Nanny GetNannyByID(int nannyId);
        Child getChildByID(int childId);
        Mother getMotherByID(int motherId);
        int distanceBetweenAddresses(string source, string dest);
        IEnumerable<IGrouping<int, Nanny>> GroupOfNannysByAgeOfKid(IEnumerable<Nanny> collection, bool byMinAge, bool sorted);
        IEnumerable<IGrouping<int, Contract>> GroupOfContractsByDistance(IEnumerable<Contract> collection, bool sorted);


        IEnumerable<Contract> ListOfContractsById(int id);
        IEnumerable<Child> getListOfChildByMother(Mother mother);
        IEnumerable<Nanny> potentialNannys(Mother mother);

        void findAddress(string source);


    }
}
