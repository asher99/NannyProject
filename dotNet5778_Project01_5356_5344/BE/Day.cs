using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    /// <summary>
    /// Represents a day of work start and finish
    /// int for hour and a int for minute
    /// </summary>
    public class Day
    {
        public int start_hour { set; get; }
        public int start_minute { set; get; }

        public int finish_hour { set; get; }
        public int finish_minute { set; get; }

        public float workTime()
        {
            float total = 0;
            total += finish_hour - start_hour;
            total -= (60 - start_minute) / 60;
            total += finish_minute / 60;

            return total;
        }

        public Day(int stHour, int stMinu, int finHour, int finMinu)
        {
            start_hour = stHour;
            start_minute = stMinu;
            finish_hour = finHour;
            finish_minute = finMinu;
        }

        /// <summary>
        /// construct a Day object with Two strings represent start time and finish time.
        /// The strings come in this form: 00:00.
        /// </summary>
        /// <param name="str_start"></param>
        /// <param name="str_finish"></param>
        public Day(string str_start, string str_finish)
        {

            // handle when the user enter a time before 10:00 AM
            if (str_start[1] == ':')
                str_start = "0" + str_start;

            if (str_finish[1] == ':')
                str_finish = "0" + str_finish;

            // handle illegal input
            if (str_start[2] != ':' || str_finish[2] != ':')
                throw new Exception("at least one of your working time is illegal");


            // fill fields
            start_hour = int.Parse(str_start.Substring(0, 2));
            start_minute = int.Parse(str_start.Substring(3));

            finish_hour = int.Parse(str_finish.Substring(0, 2));
            finish_minute = int.Parse(str_finish.Substring(3));

            // handle illegal input
            if (start_hour >= finish_hour)
                throw new Exception("at least one of your working time is illegal");

        }

        public Day() { }

    }
}
