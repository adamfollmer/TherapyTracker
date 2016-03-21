using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TherapyTracker;

namespace UserInput
{
    class UserInterface
    {
        public void PrintMainMenu()
        {
            Console.WriteLine("Please identify your role: ");
            Console.WriteLine("1. Therapist");
            Console.WriteLine("2. Director");
            Console.WriteLine("3. Nurse");
            Console.WriteLine("4. Patient");
            MakeMenuSelection();
        }
        public void MakeMenuSelection()
        {
            int userChoice = Convert.ToInt32(Console.ReadLine());
            switch (userChoice)
            {
                case 1:
                    Therapist.TherapistMenu();
                    break;
                case 2:
                    Director.SelectMenu();
                    break;
                case 3:
                    Nurse.SelectMenu();
                    break;
                case 4:
                    Patient.PatientMenu();
                    break;
                default:
                    break;
            }
        }
        public void SelectTherapist()
        {

        }
    }
}
