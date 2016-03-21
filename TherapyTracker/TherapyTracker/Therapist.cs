using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TherapyTracker
{
    public class Therapist
    {
        public String name;
        public Discipline discipline;
        Schedule schedule;
        CompletedSchedule completedSchedule;
        Time punchInPunchOut;
        Dictionary<DateTime, double> productivityLog = new Dictionary<DateTime, double>();
        public bool punchStatus = false;//true = punched in, false = punched out
        public Therapist(String Name, Discipline Discipline)
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
        //public void AddAppointment() <-This seems to get done within the Schedule class
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
        }
        public void CheckProductivity()
        {
            //Ask for date
            //Pull from dictionary based on date
        }
        public void AddProductivity()
        {
            //should run after therapists punches out
            double hoursWorked = punchInPunchOut.subtractTimeDifferenceMinutes();
            double patientContact = completedSchedule.calculatePatientContactMinutes();
            double productivity = patientContact / hoursWorked;
            //total divided by patient contact
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
