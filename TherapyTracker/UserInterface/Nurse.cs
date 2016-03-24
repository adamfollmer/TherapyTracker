using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInput
{
    public class Nurse : Patient
    {
        public TherapyTracker.Nurse ratchet = new TherapyTracker.Nurse();
        public void PrintMenu()
        {
            Console.WriteLine("\n1. Remove a patient");
            Console.WriteLine("2. Add patient time preference");
            Console.WriteLine("3. Remove patient time preference");
            Console.WriteLine("4. Exit to main menu\n");
            Console.WriteLine();
        }
        public void SelectMenuChoice(TherapyTracker.Patient Patient, TherapyTracker.RunProgram Program)
        {
            int userChoice = 0;
            while (userChoice != 4)
            {
                PrintMenu();
                try
                {
                    userChoice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter in a number");
                    SelectMenuChoice(Patient, Program);
                    return;
                }
                switch (userChoice)
                {
                    case 1:
                        ratchet.RemovePatient(Patient, Program.mainDirector);
                        break;
                    case 2:
                        ratchet.AddPatientPrefrences(Patient, GetTimeForPatientPreferenceAdd());
                        break;
                    case 3:
                        ratchet.RemovePatientPreference(Patient, GetConflictType());
                        break;
                    default:
                        break;
                }
            }
        }
        public TherapyTracker.PatientTimeConflicts GetTimeForPatientPreferenceAdd()
        {
            Console.WriteLine("What is the start time of the conflict?");
            DateTime start = VerifyDateTime();
            Console.WriteLine("What is the end time of the conflict?");
            DateTime end = VerifyDateTime();
            Console.WriteLine("What is the reason for the conflict?");

            TherapyTracker.PatientTimeConflicts.ConflictType reason =
                (TherapyTracker.PatientTimeConflicts.ConflictType)GetConflictType();
            TherapyTracker.PatientTimeConflicts conflict =
                new TherapyTracker.PatientTimeConflicts(start, end, reason);
            return conflict;
        }
        public DateTime VerifyDateTime()
        {
            string input = Console.ReadLine();
            DateTime dateTime;
            if (DateTime.TryParse(input, out dateTime))
            {
                return dateTime;
            }
            else
            {
                Console.WriteLine("Please enter date and time in the following format: ");
                Console.WriteLine("Month/Date/Year Hour:Minute:00");
                return VerifyDateTime();
            }
        }
        public void PrintConflictTypes()
        {
            Console.WriteLine("1. Meal");
            Console.WriteLine("2. Appointment");
            Console.WriteLine("3. Preference");
        }
        public int GetConflictType()
        {
            PrintConflictTypes();
            Console.WriteLine("Select conflict type?");
            try
            {
                int userInput = Convert.ToInt32(Console.ReadLine());
                if (userInput < 0 || userInput > 4)
                {
                    Console.WriteLine("Please select from the available options.");
                    return GetConflictType();
                }
                return userInput;
            }
            catch (FormatException)
            {
                Console.WriteLine("Please only enter a number");
                return GetConflictType();
            }
        }
        public void GetNewPatientInformation(TherapyTracker.Director Director)
        {
            Console.WriteLine("What is the Patient's Name?");
            string newPatientName = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Provide a unique numerical identifier for the patient.");
            try
            {
                int newPatientID = Convert.ToInt32(Console.ReadLine());
                if (newPatientID < 1000 || newPatientID > 10000)
                {
                    Console.WriteLine("Please only enter a four digit number");
                    GetNewPatientInformation(Director);
                    return;
                }
                TherapyTracker.Patient newPatient = new TherapyTracker.Patient(newPatientName, newPatientID);
                ratchet.AddPatient(newPatient, Director);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please only enter a number");
                GetNewPatientInformation(Director);
            } 
        }
    }
}
