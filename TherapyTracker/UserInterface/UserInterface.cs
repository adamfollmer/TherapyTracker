using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TherapyTracker;

namespace UserInput
{
    public class UserInterface
    {
        public RunProgram program = new TherapyTracker.RunProgram();
        public Therapist userTherapist;
        public Director userDirector;
        public Patient userPatient;
        public Nurse userNurse;
        public UserInterface()
        {
            userTherapist = new Therapist();
            userDirector = new Director();
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
                userChoice = Convert.ToInt32(Console.ReadLine());
                switch (userChoice)
                {
                    case 1:
                        userTherapist.MakeMenuSelection(SelectTherapist(), this);
                        break;
                    case 2:
                        userDirector.SelectMenu(this);
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
            foreach (TherapyTracker.Therapist therapist in program.therapistList.masterList)
            {
                Console.WriteLine(i + ". " + therapist.name);
                i++;
            }
            Console.WriteLine();
        }
        public TherapyTracker.Therapist SelectTherapist()
        {
            PrintTherapists();
            int userChoice = Convert.ToInt32(Console.ReadLine());
            return (program.therapistList.masterList[userChoice - 1]);
        }
        public TherapyTracker.Patient SelectPatient()
        {
            Console.WriteLine("\nPlease enter the patient unique identifier\n");
            int userChoice = Convert.ToInt32(Console.ReadLine());
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
            PrintMainMenu();
            return null;
        }
        public void CheckIfNewPatient()
        {
            Console.WriteLine("Is this for a new patient? (1)Yes or (2)No");
            int userInput = Convert.ToInt32(Console.ReadLine());
            if (userInput == 1)
            {
                userNurse.GetNewPatientInformation(program.mainDirector);
            }
            else
            {
                userNurse.SelectMenuChoice(SelectPatient(), program);
            }
        }

    }
}
