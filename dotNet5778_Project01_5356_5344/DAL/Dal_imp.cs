using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;

namespace DAL
{
    /// <summary>
    /// implantation for all DAL methods
    /// this layer is in charge of taking care of all the data process in this program
    /// each function helps the process either go to upper levels or writes into the Data Source
    /// </summary>
    public class Dal_imp : Idal
    {
        public Dal_imp() { }

        /// <summary>
        /// checks if nanny exists in DS and then adds to DS
        /// </summary>
        /// <param name="nanny"></param>
        public void addNanny(Nanny nanny)
        {
            if (isNannyInList(nanny.id))
                throw new Exception("nanny already in list\n");
            DataSource.listOfNannys.Add(nanny);
            return;

        }

        /// <summary>
        /// removes a nanny from DS
        /// </summary>
        /// <param name="nanny"></param>
        public void deleteNanny(Nanny nanny)
        {
            if (!isNannyInList(nanny.id))
                throw new Exception("nanny is not in list\n");

            // deletes all contracts associated with nanny
            IEnumerable<Contract> nannyContracts = ListOfContractsById(nanny.id);
            if (nannyContracts != null)
            {
                foreach (Contract c in nannyContracts)
                    deleteContract(c);
            }

            DataSource.listOfNannys.Remove(nanny);
        }

        /// <summary>
        /// gets a nanny from UI and updates the information in the DS
        /// </summary>
        /// <param name="nanny"></param>
        public void updateNanny(Nanny nanny)
        {
            if (!isNannyInList(nanny.id))
                throw new Exception("the nanny is not in the system.\n");
            foreach (Nanny temp in DataSource.listOfNannys)
            {
                if (temp.id == nanny.id)
                {
                    DataSource.listOfNannys.Remove(temp);
                    DataSource.listOfNannys.Add(nanny);
                    // ---update also all contracts of nanny's ???
                    return;
                }
            }
        }

        /// <summary>
        /// return a Nanny object from DS based on Nanny ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Nanny nannyById(int id)
        {
            var list = from Nanny temp in getListOfNanny()
                       where temp.id == id
                       select temp;

            return list.ElementAt(0);
        }

        /// <summary>
        /// checks if nanny's id is in the DS
        /// </summary>
        /// <param name="nannyId"></param>
        /// <returns></returns>
        public bool isNannyInList(int nannyId)
        {
            foreach (Nanny temp in DataSource.listOfNannys)
            {
                if (temp.id == nannyId)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// adds a mother to list
        /// </summary>
        /// <param name="mother"></param>
        public void addMother(Mother mother)
        {
            // if trying to add a existing mother
            if (isMotherInList(mother.id))
                throw new Exception("you are trying to add a existing mother.\n");
            else
                DataSource.listOfMothers.Add(mother);
        }

        /// <summary>
        /// deletes mother from list
        /// 
        /// </summary>
        /// <param name="mother"></param>
        public void deleteMother(Mother mother)
        {
            // if the mother for delete is not in the system
            if (!isMotherInList(mother.id))
                throw new Exception("you are trying to delete a mother that does not exist\n");

            //deletes all children => all contracts => decreasing Nanny number of signed contracts
            IEnumerable<Child> childrenOfMother = getListOfChildByMother(mother);
            if (childrenOfMother != null)
            {
                foreach (Child c in childrenOfMother)
                    deleteChild(c);
            }

            DataSource.listOfMothers.Remove(mother);
        }

        /// <summary>
        /// update mothers info in list
        /// </summary>
        /// <param name="mother"></param>
        public void updateMother(Mother mother)
        {
            if (!isMotherInList(mother.id))
                throw new Exception("the mother for update is not in the system.\n");

            // ---update contract ???
            foreach (Mother temp in DataSource.listOfMothers)
            {
                if (temp.id == mother.id)
                {
                    DataSource.listOfMothers.Remove(temp);
                    DataSource.listOfMothers.Add(mother);
                    return;
                }
            }
        }

        /// <summary>
        /// checks if mother is in list
        /// </summary>
        /// <param name="motherId"></param>
        /// <returns></returns>
        public bool isMotherInList(int motherId)
        {
            foreach (Mother temp in DataSource.listOfMothers)
            {
                if (temp.id == motherId)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// adds child to list
        /// </summary>
        /// <param name="child"></param>
        public void addChild(Child child)
        {
            if (isChildInList(child.id))
                throw new Exception("child already in list\n");

            DataSource.listOfChilds.Add(child);
        }

        /// <summary>
        /// removes child from list
        /// </summary>
        /// <param name="child"></param>
        public void deleteChild(Child child)
        {
            if (!isChildInList(child.id))
                throw new Exception("child is not in the system\n");

            // delete all contracts that this child was involved with => decreasing Nanny number of signed contracts
            IEnumerable<Contract> childContracts = ListOfContractsById(child.id);
            if (childContracts != null)
            {
                foreach (Contract c in childContracts.ToList())
                    deleteContract(c);
            }

            DataSource.listOfChilds.Remove(child);
        }

        /// <summary>
        /// updates child info
        /// </summary>
        /// <param name="child"></param>
        public void updateChild(Child child)
        {
            if (!isChildInList(child.id))
                throw new Exception("the child is not in the system.\n");
            // --- update contract
            foreach (Child temp in DataSource.listOfChilds)
            {
                if (temp.id == child.id)
                {
                    DataSource.listOfChilds.Remove(temp);
                    DataSource.listOfChilds.Add(child);
                    return;
                }
            }
        }

        /// <summary>
        /// checks if child is on list
        /// </summary>
        /// <param name="childId"></param>
        /// <returns></returns>
        public bool isChildInList(int childId)
        {
            foreach (Child temp in DataSource.listOfChilds)
            {
                if (temp.id == childId)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// adds a contract to list
        /// </summary>
        /// <param name="contract"></param>
        public void addContract(Contract contract)
        {
            if (isContractInList(contract))
                throw new Exception("the contract is already in the system.\n");
            DataSource.listOfContracts.Add(contract);
        }

        /// <summary>
        /// removes a contract
        /// </summary>
        /// <param name="contract"></param>
        public void deleteContract(Contract contract)
        {
            if (!isContractInList(contract))
                throw new Exception("the contract is not in the system.\n");
            DataSource.listOfContracts.Remove(contract);
        }

        /// <summary>
        /// updates contract info
        /// </summary>
        /// <param name="contract"></param>
        public void updateContract(Contract contract)
        {
            if (!isContractInList(contract))
                throw new Exception("the contract is not in the system.\n");
            foreach (Contract temp in DataSource.listOfContracts)
            {
                if (temp.numberOfContract == contract.numberOfContract)
                {
                    DataSource.listOfContracts.Remove(temp);
                    DataSource.listOfContracts.Add(contract);
                    return;
                }
            }
        }

        /// <summary>
        /// checks if contract is on list
        /// </summary>
        /// <param name="contract"></param>
        /// <returns></returns>
        public bool isContractInList(Contract contract)
        {
            foreach (Contract temp in DataSource.listOfContracts)
            {
                if (temp.numberOfContract == contract.numberOfContract)
                    return true;
            }
            return false;
        }

        // gets for all of the lists in data source
        public IEnumerable<Nanny> getListOfNanny() { return DataSource.listOfNannys.AsEnumerable(); }
        public IEnumerable<Mother> getListOfMother() { return DataSource.listOfMothers.AsEnumerable(); }
        public IEnumerable<Child> getListOfChild() { return DataSource.listOfChilds.AsEnumerable(); }
        public IEnumerable<Contract> getListOfContract() { return DataSource.listOfContracts.AsEnumerable(); }

        /// <summary>
        /// checks if the id exists in all 3 lists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool IdExist(int id)
        {
            return (isNannyInList(id) || isMotherInList(id) || isChildInList(id));
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
        public bool initalizeContractNumber(Contract contract)
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
        /// gets mothers id by using her childes id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int getMotherId(int id)
        {
            foreach (Child temp in DataSource.listOfChilds)
            {
                if (temp.id == id)
                {
                    return temp.momsId;
                }
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

            return from temp in getListOfContract()
                   where (temp.NannysId == my_id || temp.childId == my_id)
                   select temp;
        }

        /// <summary>
        /// return a list of all of a mothers children
        /// </summary>
        /// <param name="mother"></param>
        /// <returns></returns>
        public IEnumerable<Child> getListOfChildByMother(Mother mother)
        {
            return from child in getListOfChild()
                   where child.momsId == mother.id
                   select child;
        }

        /// <summary>
        /// returns a list of all the children in the group of a nanny
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Child> getListOfChildrenOfNanny(int id)
        {
            IEnumerable<Child> item= null;
           foreach(Contract contract in ListOfContractsById(id))
            {
                item = from child in getListOfChild()
                where contract.childId == child.id
                select child;
            }

            return item;
        }
    }
}
