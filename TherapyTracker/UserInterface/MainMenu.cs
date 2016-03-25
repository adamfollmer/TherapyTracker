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
            userTherapist = new Therapist();
            userDirector = new Director(this);
            userPatient = new Patient();
            userNurse = new Nurse();
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
                        userTherapist.SelectMenuChoice(SelectTherapist(), this);
                        break;
                    case 2:
                        userDirector.SelectMenuChoice();
                        break;
                    case 3:
                        CheckIfNewPatient();
                        break;
                    case 4:
                        userPatient.PatientMenu(SelectPatient(), program);
                        break;
                    case 5:
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
                if (userChoice <= 0 || userChoice > program.mainDirector.masterTherapistList.Count)
                {
                    Console.WriteLine("Please enter a valid number.");
                    return SelectTherapist();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a number.");
                return SelectTherapist();
            }
            return (program.mainDirector.masterTherapistList[userChoice - 1]);
        }
        public TherapyTracker.Patient SelectPatient()
        {
            Console.WriteLine("\nPlease enter the patient unique identifier\n");
            int userChoice = 0;
            try
            {
                userChoice = Convert.ToInt32(Console.ReadLine());
                int patientCount = 0;
                foreach (TherapyTracker.Patient patient in program.mainDirector.masterPatientList)
                {
                    if (userChoice == program.mainDirector.masterPatientList[patientCount].uniqueID)
                    {
                        return patient;
                    }
                    patientCount++;
                }
                Console.WriteLine("\nNot a valid choice, returning to main menu\n");
                Console.WriteLine("Please ask the director if you're having difficulty recalling an ID");
                MakeMenuSelection();
                return null;
            }
            catch (FormatException)
            {
                Console.WriteLine("Please ask the director if you're having difficulty recalling an ID");
                MakeMenuSelection();
                return null;
            }

        }
        public void CheckIfNewPatient()//should go in the nurseclass
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
                userNurse.GetNewPatientInformation(program.mainDirector);
            }
            else if (userInput == 2)
            {
                userNurse.SelectMenuChoice(SelectPatient(), program);
            }
        }
    }
}
