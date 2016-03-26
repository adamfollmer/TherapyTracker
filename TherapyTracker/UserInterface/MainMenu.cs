using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TherapyTracker;

namespace UserInput
{
    public class MainMenu
    {
        public RunProgram program = new TherapyTracker.RunProgram();
        public Therapist userTherapist;
        public Director userDirector;
        public Patient userPatient;
        public Nurse userNurse;
        public MainMenu()
        {
            userTherapist = new Therapist(this);
            userDirector = new Director(this);
            userPatient = new Patient(this);
            userNurse = new Nurse(this);
        }
        public void PopulateBuilding()
        {
            program.PrePopulate();
        }
        public void PrintMainMenu()
        {
            Console.WriteLine("Please identify your role: \n");
            Console.WriteLine("1. Therapist");
            Console.WriteLine("2. Director");
            Console.WriteLine("3. Nurse");
            Console.WriteLine("4. Patient\n");
            Console.WriteLine("5. Exit Program");

        }
        public void MakeMenuSelection()
        {
            int userChoice = 0;
            while (userChoice != 5)
            {
                PrintMainMenu();
                try
                {
                    userChoice = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter in a number");
                    MakeMenuSelection();
                    return;
                }

                switch (userChoice)
                {
                    case 1:
                        userTherapist.AssignTherapist(SelectTherapist());
                        break;
                    case 2:
                        userDirector.SelectMenuChoice();
                        break;
                    case 3:
                        userNurse.CheckIfNewPatient();
                        break;
                    case 4:
                        userPatient.AssignPatient(SelectPatient());
                        break;
                    case 5:
                        Environment.Exit(1);
                        break;
                    default:
                        break;
                }
            }
        }
        public void PrintTherapists()
        {
            Console.WriteLine("\nPlease enter the corresponding number to select a therapist\n");
            int i = 1;

            foreach (TherapyTracker.Therapist therapist in program.mainDirector.masterTherapistList)
            {
                Console.WriteLine(i + ". " + therapist.name);
                i++;
            }
            Console.WriteLine();
        }
        public TherapyTracker.Therapist SelectTherapist()
        {
            PrintTherapists();
            int userChoice = 0;
            try
            {
                userChoice = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (userChoice <= 0 || userChoice > program.mainDirector.masterTherapistList.Count)
                {
                    Console.WriteLine("[ERROR]: Please enter a valid number.\n");
                    return SelectTherapist();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("[ERROR]: Please enter a number.\n");
                return SelectTherapist();
            }
            Console.Clear();
            return (program.mainDirector.masterTherapistList[userChoice - 1]);
        }
        public TherapyTracker.Patient SelectPatient()
        {
            Console.WriteLine("\nPlease enter the patient unique identifier\n");
            int userChoice = 0;
            try
            {
                userChoice = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                int patientCount = 0;
                foreach (TherapyTracker.Patient patient in program.mainDirector.masterPatientList)
                {
                    if (userChoice == program.mainDirector.masterPatientList[patientCount].uniqueID)
                    {
                        return patient;
                    }
                    patientCount++;
                }
                Console.WriteLine("[ERROR]: Not a valid choice, returning to main menu\n");
                Console.WriteLine("Please ask the director if you're having difficulty recalling an ID\n");
                MakeMenuSelection();
                return SelectPatient();
            }
            catch (FormatException)
            {
                Console.WriteLine("[ERROR]: Not a valid choice, returning to main menu\n");
                Console.WriteLine("Please ask the director if you're having difficulty recalling an ID\n");
                MakeMenuSelection();
                return SelectPatient();
            }

        }
        public DateTime VerifyTimeOnlySequence()
        {
            int second = 00;
            int minute = VerifyMinutes();
            int hour = VerifyHours();
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            DateTime verifiedTime = new DateTime(year, month, day, hour, minute, second);
            return verifiedTime;
        }
        public DateTime VerifyDateOnlySequence()
        {
            int year = DateTime.Now.Year;
            int month = VerifyMonth();
            int day = VerifyDay();
            DateTime verifiedDate = new DateTime(year, month, day);
            return verifiedDate;
        }
        public DateTime VerifyFullDateTimeSequence()
        {
            int year = DateTime.Now.Year;
            int month = VerifyMonth();
            int day = VerifyDay();
            int hour = VerifyHours();
            int minute = VerifyMinutes();
            int second = 00;
            DateTime verifiedDate = new DateTime(year, month, day, hour, minute, second);
            return verifiedDate;
        }
        public int VerifyMinutes()
        {
            
            Console.WriteLine("Enter in the minute:\n");
            int userMinutes;
            try
            {
                userMinutes = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (userMinutes < 0 || userMinutes > 59)
                {
                    Console.WriteLine("[ERROR]: Minutes range from 0 to 59\n");
                    return VerifyMinutes();
                }
                Console.Clear();
                return userMinutes;
            }
            catch (FormatException)
            {
                Console.WriteLine("[ERROR]: Please enter numbers only\n");
                return VerifyMinutes();
            }
            
        }
        public int VerifyHours()
        {
            
            Console.WriteLine("Enter in the hour:\n");
            int userHours;
            try
            {
                userHours = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (userHours < 0 || userHours > 23)
                {
                    Console.WriteLine("[ERROR]: Days range from 0 to 23\n");
                    return VerifyHours();
                }
                Console.Clear();
                return userHours;
            }
            catch (FormatException)
            {
                Console.WriteLine("[ERROR]: Please enter numbers only\n");
                return VerifyHours();
            }
            
        }
        public int VerifyMonth()
        {
            
            Console.WriteLine("Enter in the month\n");
            int userMonth;
            try
            {
                userMonth = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (userMonth <= 0 || userMonth > 12)
                {
                    Console.WriteLine("[ERROR]: Months range from 1 to 12\n");
                    return VerifyMonth();
                }
                Console.Clear();
                return userMonth;
            }
            catch (FormatException)
            {
                Console.WriteLine("[ERROR]: Please enter numbers only\n");
                return VerifyMonth();
            }
        }
        public int VerifyDay()
        {
            
            Console.WriteLine("Enter in the day\n");
            int userDay;
            try
            {
                userDay = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (userDay <= 0 || userDay > 31)
                {
                    Console.WriteLine("[ERROR]: Days range from 1 to 31\n");
                    return VerifyDay();
                }
                Console.Clear();
                return userDay;
            }
            catch (FormatException)
            {
                Console.WriteLine("[ERROR]: Please enter numbers only\n");
                return VerifyDay();
            }
        }
    }
}
