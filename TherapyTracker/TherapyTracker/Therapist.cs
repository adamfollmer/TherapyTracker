using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TherapyTracker
{
    public class Therapist
    {
        public string name;
        public Discipline discipline;
        public Schedule schedule;
        public CompletedSchedule completedSchedule;
        public Time punchInPunchOut;
        Dictionary<DateTime, double> productivityLog = new Dictionary<DateTime, double>();
        public bool punchStatus = false;//true = punched in, false = punched out
        public Therapist(string Name, Discipline Discipline)
        {
            name = Name;
            schedule = new Schedule(this);
            completedSchedule = new CompletedSchedule(this);
            discipline = Discipline;
        }

        public enum Discipline
        {
            speechTherapist,
            physicalTherapist,
            occupationalTherapist,
        }
        public void AddAppointment(Appointment Appointment)
        {
            schedule.addAppointment(Appointment);
        }
        public void GetNewPatient() //By far the most complicated thing
        {
            //Look at remaining schedule
            //Determine which patient is available by checking:
            //Patients preferences
            //Other scheduled times
        }
        public void AutoPunch()
        {
            if (punchStatus == false)
            {
                punchInPunchOut.startTime = DateTime.Now;
                punchStatus = true;
            } else
            {
                punchInPunchOut.endTime = DateTime.Now;
                AddProductivity();
                punchStatus = false;
            }
        }
        public void ManualPunchIn(DateTime time)
        {
            //Real time punch versus missed punch
            //Take information if missed punch
            punchInPunchOut.startTime = time;

        }
        public void ManualPunchOut(DateTime time)
        {
            //Real time out punch versus missed punch
            //Take information if missed punch
            punchInPunchOut.endTime = time;
            AddProductivity();
        }
        public void CheckProductivity(DateTime CheckDate)
        {
            double productivitiy;
            if (productivityLog.TryGetValue(CheckDate, out productivitiy))
            {
                Console.WriteLine(productivitiy);
            }
            else
            {
                Console.WriteLine("No productivity information logged for that day");
            }
            
            //Pull from dictionary based on date
        }
        public void AddProductivity()
        {
            double hoursWorked = punchInPunchOut.subtractTimeDifferenceMinutes();
            double patientContact = completedSchedule.calculatePatientContactMinutes();
            double productivity = (patientContact / hoursWorked) * 100;
            productivityLog.Add(DateTime.Today.Date, productivity);
           
        }
        public void CompleteAppointment()
        {
            //Ask which appointment this is in reference to.
            //Ask Was the appointment completed as schedule
            //If yes, transfer info from scheduled appointment to completed appointment
            //If no, Take user input for time in, time end, and patient
        }
    }
}
