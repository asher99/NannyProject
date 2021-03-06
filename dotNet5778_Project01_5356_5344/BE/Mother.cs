﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    /// <summary>
    /// Represents a mother has personal information
    /// and information about hours of need of nanny
    /// </summary>
    public class Mother
    {
        public int id { set; get; }

        public string familyName { set; get; }

        public string firstName { set; get; }

        public string phoneNumber { set; get; }

        public string address { set; get; }

        public int addressRadius { set; get; }   // in kilometer

        public bool[] daysOfNanny { set; get; }

        public Day[] hoursByNanny { set; get; }

        public bool wantsATrialMeeting { set; get; }

        public string comments { set; get; }
        // more options if needed

        /// <summary>
        /// to string method 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return familyName + ' ' + firstName + " - MOTHER\n" + address + "\n id:\t" + id + '\n';
        }

        // constructors
        public Mother(string my_familyName, string my_firstName, string my_address, int my_id, string my_phone)
        {
            familyName = my_familyName;
            firstName = my_firstName;
            address = my_address;
            id = my_id;
            phoneNumber = my_phone;
        }

        public Mother() { daysOfNanny = new bool[6]; hoursByNanny = new Day[6]; }

    }
}
