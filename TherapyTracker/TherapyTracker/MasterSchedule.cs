using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using (System.IO.StreamWriter file =
//    new System.IO.StreamWriter(@"C:\Users\AdamLaptop\Documents\Visual Studio 2015\Projects\TherapyTracker\LogFiles");

namespace TherapyTracker
{
    class MasterSchedule
    {
        List<Schedule> masterSchedule = new List<Schedule>();
        public MasterSchedule()
        {
        }

        public void AddSchedule (Schedule schedule)
        {
            masterSchedule.Add(schedule);
        }

        //Currently broken because access levels are fucked for
        //itterating a list of another list
        public void PrintMasterScheduleToFile()
        {
            foreach (Schedule schedule in masterSchedule)
            {
                //IEnumerable<Schedule> schedule();
               // foreach (Appointment appointment in schedule)
                {

                }
            }
        }
    }
}
