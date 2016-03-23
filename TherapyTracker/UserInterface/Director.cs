using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInput
{
    public class Director
    {
        public void PrintMenuOptions()
        {
            Console.WriteLine("\n1. Set patient's RUG level");
            Console.WriteLine("2. Increase minutes for appointment");
            Console.WriteLine("3. Reduce minutes for appointment");
            Console.WriteLine("4. Print all Schedules\n");
        }
        public void SelectMenu(UserInterface Menu)
        {
            PrintMenuOptions();
            int userChoice = Convert.ToInt32(Console.ReadLine());
            switch (userChoice)
            {
                case 1:
                    SetRug(Menu);
                    break;
                case 2:
                    IncreaseMinutes(Menu);
                    break;
                case 3:
                    DecreaseMinutes(Menu);
                    break;
                case 4:
                    Menu.program.mainDirector.PrintTherapistSchedules();
                    break;
                default:
                    break;
            }
        }
        public void SetRug(UserInterface Menu)
        {
            TherapyTracker.Patient holdPatient = Menu.SelectPatient();
            int rugLevel = PrintRUGOptions();
            Menu.program.mainDirector.UpdatePatientRUGLevel(holdPatient, rugLevel);
            
        }
        public int PrintRUGOptions()
        {
            Console.WriteLine("Pick a number corresponding to a level");
            Console.WriteLine("1. RU\n2. RV\n3. RH\n4. RM\n5. RL");
            int userInput = Convert.ToInt32(Console.ReadLine());
            return userInput;
        }
        public void IncreaseMinutes(UserInterface Menu)
        {
            int appointmentID = GetAppointmentID();
            Console.WriteLine("How much more time is required?");
            double timeIncrease = Convert.ToDouble(Console.ReadLine());
            Menu.program.mainDirector.IncreasePatientTimeSeen(appointmentID, timeIncrease);
        }
        public void DecreaseMinutes(UserInterface Menu)
        {
            int appointmentID = GetAppointmentID();
            Console.WriteLine("How much less time would you like?");
            double timeDecrease = Convert.ToDouble(Console.ReadLine());
            Menu.program.mainDirector.DecreasePatientTimeSeen(appointmentID, timeDecrease);
        }
        public int GetAppointmentID()
        {
            Console.WriteLine("Please enter a valid appointment ID");
            int appointmentID;
            appointmentID = Convert.ToInt32(Console.ReadLine());
            return appointmentID;
        }
    }
}
