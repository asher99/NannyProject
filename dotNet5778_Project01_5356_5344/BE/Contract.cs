using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    /// <summary>
    /// represents a contract that a mother does with a nanny.
    /// include hours of work and payments ext.
    /// </summary>
    public class Contract
    {
        public int numberOfContract { set; get; }// maybe a special class?

        public int NannysId { set; get; }

        public int childId { set; get; }

        public bool hadFirstMeeting { set; get; }

        public bool isSingedContract { set; get; }

        public float moneyPerHour { set; get; }

        public float monthSalary { set; get; }

        public bool isMonthContract { set; get; }

        public DateTime StartDate { set; get; }

        public DateTime ExpirationDate { set; get; }

        // more options if needed

        public override string ToString()
        {
            string temp = "CONTRACT NUMBER: " + numberOfContract + "\n nanny id: " + NannysId + "\n child id: " + childId + '\n'; 
            if (isMonthContract)
            {
                return temp + "salary per month:\t" + monthSalary + '\n' + "expiration date:\t" + ExpirationDate.ToString() + '\n';
            }
            else
            {
                return temp + "salary per hour:\t" + moneyPerHour + '\n' + "expiration date:\t" + ExpirationDate.ToString() + '\n';

            }
        }

        /// <summary>
        /// Contract object constructor. receive id of both nanny and child and boolean variable to determine if the contract is monthly or per hour.
        /// if it's per month : the salary enterd is monthly salary, if not: the salary is salary per hour.
        /// start date is immediatly and expiration date is in more six months.
        /// </summary>
        /// <param name="my_nannyId"></param>
        /// <param name="my_childId"></param>
        /// <param name="my_isMonthContract"></param>
        /// <param name="salary">based pn the boolean field, this salary can be per month or per hour.</param>
        public Contract(Nanny my_nanny, Child my_child, bool my_isMonthContract)
        {
            NannysId = my_nanny.id;
            childId = my_child.id;
            isMonthContract = my_isMonthContract;

            if (isMonthContract)
            {
                monthSalary = my_nanny.monthlyWage;
                moneyPerHour = 0;
            }

            else
            {
                monthSalary = 0;
                moneyPerHour = my_nanny.hourWage;
            }

            // initialize start date and expiration date.
            StartDate = DateTime.Now;
            ExpirationDate = StartDate.AddMonths(6);

            numberOfContract = -1;
            isSingedContract = false;
        }
    }

    
}
