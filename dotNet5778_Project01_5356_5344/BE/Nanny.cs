using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    /// <summary>
    /// Represents a nanny has personal and professional information 
    /// and includes address ext.
    /// </summary>
    public class Nanny
    {
        // nanny's Personal Information

        public int id { set; get; }

        public string familyName { set; get; }

        public string firstName { set; get; }

        public DateTime birthday { set; get; }

        public string phoneNumber { set; get; }

        public string address { set; get; }

        public bool hasElevator { set; get; }

        public int floorNumber { set; get; }

        // professional details
        public int seniority { set; get; }

        public int maxOfKids { set; get; } // size of group

        public int minAgeOfKid { set; get; }// in months

        public int maxAgeOfKid { set; get; }

        public bool doesWorkPerHour { set; get; } // if the nanny allowed to care for few hours

        public int hourWage { set; get; }

        public int monthlyWage { set; get; }

        public bool[] daysOfWork { set; get; } 

        public Day[] hoursOfWork { set; get; } // each day hour of start and hour of finish

        public bool hasGovVacationDays { set; get; }

        public string Recommendations { set; get; }

        public int numberOfSignedContracts { set; get; }
        // Extra space for more Properties if needed

        public override string ToString()
        {
            return familyName + ' ' + firstName + "- NANNY\n" + address + "\n id number:\t" + id + "\n birth date:\t:" + birthday.ToShortDateString() + "\n wage per hour:\t" + hourWage + "\n wage per month:" + monthlyWage + "\n phone number:\t" + phoneNumber
                + "\n nanny can take care " + maxOfKids + " kids that are " + minAgeOfKid + " to " + maxAgeOfKid + " months old\n";
        }


        public Nanny(string my_lastName, string my_firstName, string my_address, int my_id,DateTime my_birthday, string my_phone, bool my_doesWorkPerHour, int perHour, int perMonth, int maxKids, int my_minAge, int my_maxAge)
        {
            familyName = my_lastName;
            firstName = my_firstName;
            address = my_address;
            id = my_id;
            phoneNumber = my_phone;
            doesWorkPerHour = my_doesWorkPerHour;
            monthlyWage = perMonth;
            hourWage = perHour;
            birthday = my_birthday;
            maxOfKids = maxKids;
            minAgeOfKid = my_minAge;
            maxAgeOfKid = my_maxAge;
         
        }

        public Nanny() { numberOfSignedContracts = 0; daysOfWork = new bool[6]; hoursOfWork = new Day[6]; birthday = DateTime.Now; }

    }
}
