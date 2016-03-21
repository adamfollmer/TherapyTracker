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
            DateTime start1 = new DateTime(2016, 3, 21, 9, 30, 0);
            DateTime end2 = new DateTime(2016, 3, 21, 10, 30, 0);
            Time testTime = new Time(start, end);

            //Console.WriteLine(testTime.subtractTimeDifferenceHours());
            //Console.ReadLine();

            //Adding a few mock appointments to a mock schedule to the masterSchedule
            Patient patientOne = new Patient("Shirley");
            Patient patientTwo = new Patient("Tom");
            Appointment appointmentOne = new Appointment(start, end, patientOne);
            Appointment appointmentTwo = new Appointment(start1, end2, patientTwo);
            Therapist therapistOne = new Therapist("Adam", Therapist.Discipline.speechTherapist);
            Schedule scheduleOne = new Schedule(therapistOne);
            MasterSchedule master = new MasterSchedule();
            scheduleOne.addAppointment(appointmentOne);
            scheduleOne.addAppointment(appointmentTwo);
            master.AddSchedule(scheduleOne);
            master.PrintMasterScheduleToFile();
            Console.ReadLine();
        }
    }
}
