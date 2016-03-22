using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInput
{
    public class Director : Therapist
    {
        UserInterface menu = new UserInterface();
        public void PrintMenuOptions()
        {
            Console.WriteLine("\n1. Set patient's RUG level");
            Console.WriteLine("2. Increase minutes for appointment");
            Console.WriteLine("3. Reduce minutes for appointment\n");
        }
        public void SelectMenu(TherapyTracker.RunProgram program)
        {
            PrintMenuOptions();
            int userChoice = Convert.ToInt32(Console.ReadLine());
            switch (userChoice)
            {
                case 1:
                    SetRug(program);
                    break;
                case 2:
                    IncreaseMinutes(program);
                    break;
                case 3:
                    DecreaseMinutes(program);
                    break;
                default:
                    break;
            }
        }
        public void SetRug(TherapyTracker.RunProgram program)
        {
            TherapyTracker.Patient holdPatient = menu.SelectPatient();
            int rugLevel = PrintRUGOptions();
            program.mainDirector.UpdatePatientRUGLevel(holdPatient, rugLevel);
            
        }
        public int PrintRUGOptions()
        {
            Console.WriteLine("Pick a number corresponding to a level");
            Console.WriteLine("1. RU\n2. RV\n3. RH\n4. RM\n5. RL");
            int userInput = Convert.ToInt32(Console.ReadLine());
            return userInput;
        }
        public void IncreaseMinutes(TherapyTracker.RunProgram program)
        {
            TherapyTracker.Patient holdPatient = menu.SelectPatient();
            TherapyTracker.Therapist holdTherapist = menu.SelectTherapist();
            Console.WriteLine("How much more time is required?");
            int timeIncrease = Convert.ToInt32(Console.ReadLine());
            program.mainDirector.IncreasePatientTimeSeen(holdPatient, holdTherapist, timeIncrease);
        }
        public void DecreaseMinutes(TherapyTracker.RunProgram program)
        {
            TherapyTracker.Patient holdPatient = menu.SelectPatient();
            TherapyTracker.Therapist holdTherapist = menu.SelectTherapist();
            Console.WriteLine("How much less time would you like?");
            int timeDecrease = Convert.ToInt32(Console.ReadLine());
            program.mainDirector.DecreasePatientTimeSeen(holdPatient, holdTherapist, timeDecrease);
        }
    }
}
