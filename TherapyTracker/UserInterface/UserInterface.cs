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
            MakeMenuSelection();
        }
        public void MakeMenuSelection()
        {
            int userChoice = Convert.ToInt32(Console.ReadLine());
            switch (userChoice)
            {
                case 1:
                    userTherapist.MakeMenuSelection(SelectTherapist());
                    break;
                case 2:
                    userDirector.SelectMenu(program);
                    break;
                case 3://should be done
                    CheckIfNewPatient();
                    break;
                case 4://should be done
                    userPatient.PatientMenu(SelectPatient(), program);
                    break;
                default:
                    //return PrintMainMenu?
                    break;
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
            foreach (TherapyTracker.Patient patient in program.patientList.masterPatientList)
            {
                if (userChoice == program.patientList.masterPatientList[patientCount].uniqueID)
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
                userNurse.GetNewPatientInformation(program);
            }
            else
            {
                userNurse.SelectMenuChoice(SelectPatient(), program);
            }
        }

    }
}
