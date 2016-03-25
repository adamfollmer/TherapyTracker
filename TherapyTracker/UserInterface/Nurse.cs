using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInput
{
    public class Nurse : Patient
    {
        public MainMenu menu;
        public TherapyTracker.Director mainDirector;
        public TherapyTracker.Patient patient;
        public TherapyTracker.Nurse ratchet;
        public Nurse (MainMenu Menu) : base(Menu)
        {
            menu = Menu;
            mainDirector = Menu.program.mainDirector;
            ratchet = new TherapyTracker.Nurse();
        }
        public void PrintMenu()
        {
            Console.WriteLine("\n1. Remove a patient");
            Console.WriteLine("2. Add patient time preference");
            Console.WriteLine("3. Remove patient time preference");
            Console.WriteLine("4. Exit to main menu\n");
            Console.WriteLine();
        }
        public void CheckIfNewPatient()
        {
            Console.WriteLine("Is this refering to a new patient? (1)Yes or (2)No");
            int userInput = 0;
            try
            {
                userInput = Convert.ToInt32(Console.ReadLine());
                if (userInput != 1 && userInput != 2)
                {
                    Console.WriteLine("Please enter 1 or 2.");
                    CheckIfNewPatient();
                    return;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid number.");
                CheckIfNewPatient();
            }
            if (userInput == 1)
            {
                GetNewPatientInformation(mainDirector);
            }
            else if (userInput == 2)
            {
                patient = menu.SelectPatient();
                SelectMenuChoice();
            }
        }
        public void SelectMenuChoice()
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
                    SelectMenuChoice();
                    return;
                }
                switch (userChoice)
                {
                    case 1:
                        ratchet.RemovePatient(patient, mainDirector);
                        break;
                    case 2:
                        ratchet.AddPatientPrefrences(patient, GetTimeForPatientPreferenceAdd());
                        break;
                    case 3:
                        ratchet.RemovePatientPreference(patient, GetConflictType());
                        break;
                    default:
                        break;
                }
            }
        }
        public TherapyTracker.PatientTimeConflicts GetTimeForPatientPreferenceAdd()
        {
            Console.WriteLine("What is the start time of the conflict?");
            DateTime start = menu.VerifyFullDateTimeSequence();
            Console.WriteLine("What is the end time of the conflict?");
            DateTime end = menu.VerifyFullDateTimeSequence();
            Console.WriteLine("What is the reason for the conflict?");

            TherapyTracker.PatientTimeConflicts.ConflictType reason =
                (TherapyTracker.PatientTimeConflicts.ConflictType)GetConflictType();
            TherapyTracker.PatientTimeConflicts conflict =
                new TherapyTracker.PatientTimeConflicts(start, end, reason);
            return conflict;
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
