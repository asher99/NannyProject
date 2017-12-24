using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
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

        public Day() { }

    }
}
