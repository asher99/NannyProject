using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    /// <summary>
    /// Represents a child that is going to be taken care of by a nanny
    /// only the child has information about his mother
    /// </summary>
    public class Child
    {
        public int id { set; get; }

        public string name { set; get; }

        public int momsId { set; get; }

        public DateTime birthday { set; get; }

        public bool hasSpecialNeeds { set; get; }

        public string specialNeeds { set; get; }

        // more options if needed

        public override string ToString()
        {
            return name + " - CHILD\n child id: " + id + "\n birth date:\t" + birthday.ToShortDateString() + "\n mother id: " + momsId + '\n';
        }

        // calculates the child age in months using his birthday 
        public int ageInMonths()
        {
            int age = birthday.Year * 12 + birthday.Month;
            int today = DateTime.Today.Year * 12 + DateTime.Today.Month;
            return today - age;
        }

        public Child(string my_name, int my_id, int my_motherId, DateTime my_birthday, bool my_specialNeeds, string my_specialNeedsString)
        {
            name = my_name;
            id = my_id;
            momsId = my_motherId;
            birthday = my_birthday;
            hasSpecialNeeds = my_specialNeeds;
            specialNeeds = my_specialNeedsString;

        }

        public Child() { birthday = DateTime.Now; }

        public bool compareChildren(Child otherChild)
        {
            if (otherChild.id == this.id)
                return true;
            else return false;
        }

    }
}
