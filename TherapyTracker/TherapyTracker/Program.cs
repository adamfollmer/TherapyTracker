using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TherapyTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            //Testing how subtractTimeDifference works in appointment
            DateTime start = new DateTime(2016, 3, 21, 6, 0, 0);
            DateTime end = new DateTime(2016, 3, 21, 14, 0, 0);
            Time testTime = new Time(start, end);

            Console.WriteLine(testTime.subtractTimeDifferenceHours());
            Console.ReadLine();
        }
    }
}
