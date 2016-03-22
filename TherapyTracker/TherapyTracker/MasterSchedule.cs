using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace TherapyTracker
{
    public class MasterSchedule
    {
        public List<Schedule> masterSchedule = new List<Schedule>();
        public MasterSchedule()
        {
        }

        public void AddSchedule (Schedule schedule)
        {
            masterSchedule.Add(schedule);
        }

        public void PrintMasterScheduleToFile()
        {
            StreamWriter writer = File.CreateText("C:\\PrintLog\\masterSchedule.txt");
            foreach (Schedule schedule in masterSchedule)
            {
                writer.WriteLine(schedule.therapist.name + "'s schedule:");
                for (int appointment = 0; appointment < schedule.therapistSchedule.Count; appointment++)
                {
                    writer.WriteLine(schedule.therapistSchedule[appointment].patientIdentifier.name);
                    writer.WriteLine(schedule.therapistSchedule[appointment].startTime);
                    writer.WriteLine(schedule.therapistSchedule[appointment].endTime);
                    writer.WriteLine();
                }
            }
            writer.Close();
        }
        //Not going to worry about the below class right now.
        public void UploadMasterScheduleFromFile()
        {
            StreamReader reader = new StreamReader("C:\\PrintLog\\masterSchedule.txt");
            while (true)
            {
            }

        }
    }
}
