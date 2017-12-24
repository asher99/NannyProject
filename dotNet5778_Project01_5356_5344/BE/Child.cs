using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Child
    {
        public int id { set; get; }

        public int momsId { set; get; }

        public string name { set; get; }

        public DateTime birthday { set; get; }

        public bool hasSpecialNeeds { set; get; }

        public string specialNeeds { set; get; }

        // more options if needed

        public override string ToString()
        {
            return name + " - CHILD\n child id: " + id + "\n birth date:\t" + birthday.ToShortDateString() + "\n mother id: " + momsId + '\n';
        }

        public Child(string my_name, int my_id, int my_motherId, DateTime my_birthday)
        {
            name = my_name;
            id = my_id;
            momsId = my_motherId;
            birthday = my_birthday;
        }

    }
}
