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
    /// this layer is incharge of taking care of all the data process in this program
    /// each function helps the process either go to upper levels or writes into the Data Source
    /// </summary>
    public class Dal_imp : Idal
    {


        /// <summary>
        /// checks if nanny exists in DS and then adds to DS
        /// </summary>
        /// <param name="nanny"></param>
        public void addNanny(Nanny nanny)
        {
            if (isNannyInList(nanny.id))
                throw new Exception("nanny already in list\n");
            else
            {
                DataSource.listOfNannys.Add(nanny);
                return;
            }
        }

        /// <summary>
        /// removes a nanny from DS
        /// </summary>
        /// <param name="nanny"></param>
        public void deleteNanny(Nanny nanny)
        {
            // ---do not delete if have existing contracts
            if (isNannyInList(nanny.id))
                DataSource.listOfNannys.Remove(nanny);
            else
                throw new Exception("nanny is not in list\n");
        }

        /// <summary>
        /// gets a nanny from UI and updates the information in the DS
        /// </summary>
        /// <param name="nanny"></param>
        public void updateNanny(Nanny nanny)
        {
            foreach (Nanny temp in DataSource.listOfNannys)
            {
                if (temp.id == nanny.id)
                {
                    DataSource.listOfNannys.Remove(temp);
                    DataSource.listOfNannys.Add(nanny);
                    // ---update also all contracts of nannys
                    return;
                }
            }
        }

        /// <summary>
        /// checks if nannys id is in the DS
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
            DataSource.listOfMothers.Add(mother);
        }

        /// <summary>
        /// deletes mother from list
        /// 
        /// </summary>
        /// <param name="mother"></param>
        public void deleteMother(Mother mother)
        {
            DataSource.listOfMothers.Remove(mother);
        }

        /// <summary>
        /// update mothers info in list
        /// </summary>
        /// <param name="mother"></param>
        public void updateMother(Mother mother)
        {
            // ---update contract
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
            DataSource.listOfChilds.Add(child);
        }

        /// <summary>
        /// removes child from list
        /// </summary>
        /// <param name="child"></param>
        public void deleteChild(Child child)
        {
            DataSource.listOfChilds.Remove(child);
        }

        /// <summary>
        /// updates child info
        /// </summary>
        /// <param name="child"></param>
        public void updateChild(Child child)
        {
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
                DataSource.listOfContracts.Add(contract);
        }

        /// <summary>
        /// removes a contract
        /// </summary>
        /// <param name="contract"></param>
        public void deleteContract(Contract contract)
        {
                DataSource.listOfContracts.Remove(contract);
        }

        /// <summary>
        /// updates contract info
        /// </summary>
        /// <param name="contract"></param>
        public void updateContract(Contract contract)
        {
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
        public IEnumerable<Child> getListOfChild() { return DataSource.listOfChilds.AsEnumerable(); } // not good implemention
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
        /// gets mothers id by using her childs id
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
    }
}
