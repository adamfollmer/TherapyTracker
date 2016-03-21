using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TherapyTracker
{
    class Therapist
    {
        String name;
        Schedule schedule;
        CompletedSchedule completedSchedule;
        Dictionary<DateTime, double> productivityLog = new Dictionary<DateTime, double>();
        bool punchStatus;//true = punched in, false = punched out
        public Therapist(String Name)
        {
            name = Name;
        }
        public void CalculatePatientContact()
        {
            //For each patient duration in completedSchedule
            //Add calculated minutes to a hold variable
            //return an int value
        }
        public void AddAppointment()
        {
            //What's the patients name
            //What's the start time
            //How long do you want to see the patient for
            //Calculate the end time
            //Verify no conflicts by checking masterSchedule
            //Print appointment details
        }
        public void GetNewPatient() //By far the most complicated thing
        {
            //Look at remaining schedule
            //Determine which patient is available by checking:
            //Patients preferences
            //Other scheduled times
        }

        public void ChangePatientPrefrences()
        {
            //What's the patients name
            //create new PatientTimeConflict 
            //Add it to potentialConflicts list in the patient
            //Print the new conflict
        }
        public void PunchIn()
        {
            //Real time punch versus missed punch
            //Take information if missed punch
        }
        public void PunchOut()
        {
            //Real time out punch versus missed punch
            //Take information if missed punch
        }
        public void CheckProductivity()
        {
            //Ask for date
            //Pull from dictionary based on date
        }
        public void AddProductivity()
        {
            //should run after therapists punches out
            //Time in - Time out
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
