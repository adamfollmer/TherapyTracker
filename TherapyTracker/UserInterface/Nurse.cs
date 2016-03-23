using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInput
{
    public class Nurse:Patient
    {
        public TherapyTracker.Nurse ratchet = new TherapyTracker.Nurse();
        public void PrintMenu()
        {
            Console.WriteLine("1. Remove a patient");
            Console.WriteLine("2. Add patient time preference");
            Console.WriteLine("3. Remove patient time preference");
            Console.WriteLine();
        }
        public void SelectMenuChoice(TherapyTracker.Patient Patient, TherapyTracker.RunProgram Program)
        {
            PrintMenu();
            int userChoice = Convert.ToInt32(Console.ReadLine());
            switch (userChoice)
            {
                case 1:
                    ratchet.RemovePatient(Patient, Program.mainDirector);
                    break;
                case 2:
                    ratchet.AddPatientPrefrences(Patient, GetTimeForPatientPreferenceAdd());
                    break;
                case 3:
                    ratchet.RemovePatientPreference(Patient, GetConflictTypeForRemoval());
                    break;
                default:
                    break;
            }
        }
        public TherapyTracker.PatientTimeConflicts GetTimeForPatientPreferenceAdd ()
        {
            Console.WriteLine("What is the start time of the conflict?");
            DateTime start = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("What is the end time of the conflict?");
            DateTime end = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("What is the reason for the conflict?");
            PrintConflictTypes();
            TherapyTracker.PatientTimeConflicts.ConflictType reason = 
                (TherapyTracker.PatientTimeConflicts.ConflictType)Convert.ToInt32(Console.ReadLine());
            TherapyTracker.PatientTimeConflicts conflict = 
                new TherapyTracker.PatientTimeConflicts(start, end, reason);
            return conflict;
        }
        public void PrintConflictTypes()//There is a way of iterating through enums, but will skip for now
        {
            Console.WriteLine("1. Meal");
            Console.WriteLine("2. Appointment");
            Console.WriteLine("3. Preference");
        }
        public int GetConflictTypeForRemoval()
        {
            PrintConflictTypes();
            Console.WriteLine("What conflict type do you want to remove?");
            int userInput =  Convert.ToInt32(Console.ReadLine());
            return userInput;
        } 
        public void GetNewPatientInformation(TherapyTracker.Director Director)
        {
            Console.WriteLine("What is the Patient's Name?");
            string newPatientName = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Provide a unique numerical identifier for the patient.");
            int newPatientID = Convert.ToInt32(Console.ReadLine());
            TherapyTracker.Patient newPatient = new TherapyTracker.Patient(newPatientName, newPatientID);
            ratchet.AddPatient(newPatient, Director);
        }
    }
}
