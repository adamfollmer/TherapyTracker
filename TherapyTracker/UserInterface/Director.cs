using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInput
{
    public class Director
    {
        TherapyTracker.Director mainDirector;
        MainMenu menu;
        public Director (MainMenu Menu)
        {
            mainDirector = Menu.program.mainDirector;
            menu = Menu;
        }
        public void PrintMenuOptions()
        {
            Console.WriteLine("\n1. Set patient's RUG level");
            Console.WriteLine("2. Increase minutes for appointment");
            Console.WriteLine("3. Reduce minutes for appointment");
            Console.WriteLine("4. View all Schedules");
            Console.WriteLine("5. View all Patient Information\n");
            Console.WriteLine("6. Return to Main Menu");
        }
        public void SelectMenuChoice()
        {
            int userChoice = 0;
            while (userChoice != 6)
            {
                PrintMenuOptions();
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
                        SetRug();
                        break;
                    case 2:
                        IncreaseMinutes();
                        break;
                    case 3:
                        DecreaseMinutes();
                        break;
                    case 4:
                        mainDirector.PrintTherapistSchedules();
                        break;
                    case 5:
                        mainDirector.PrintPatientList();
                        break;
                    default:
                        break;
                }
            }
        }
        public void SetRug()
        {
            TherapyTracker.Patient holdPatient = menu.SelectPatient();
            int rugLevel = SelectRugOption();
            mainDirector.UpdatePatientRUGLevel(holdPatient, rugLevel);

        }
        public int SelectRugOption()
        {
            Console.WriteLine("Pick a number corresponding to a level");
            Console.WriteLine("1. RU\n2. RV\n3. RH\n4. RM\n5. RL");
            int userInput = VerifyRugSelection();
            return userInput;
        }
        public int VerifyRugSelection()
        {
            int userInput = 0;
            try
            {
                userInput = Convert.ToInt32(Console.ReadLine());
                if (userInput < 0 || userInput > 5)
                {
                    Console.WriteLine("Please select from a valid option");
                    return VerifyRugSelection();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter numbers only.");
                return VerifyRugSelection();
            }
            return userInput;
        }
        public void IncreaseMinutes()
        {
            int appointmentID = GetAppointmentID();
            Console.WriteLine("How much more time is required?");
            double timeIncrease = VerifyMinuteAmount();
            mainDirector.IncreasePatientTimeSeen(appointmentID, timeIncrease);
        }
        public void DecreaseMinutes()
        {
            int appointmentID = GetAppointmentID();
            Console.WriteLine("How much less time would you like?");
            double timeDecrease = VerifyMinuteAmount();
            mainDirector.DecreasePatientTimeSeen(appointmentID, timeDecrease);
        }
        public double VerifyMinuteAmount()
        {
            double userInput = 0;
            try
            {
                userInput = Convert.ToDouble(Console.ReadLine());
                if (userInput < 0 || userInput > 120)
                {
                    Console.WriteLine("The amount of time is too short or too long");
                    return VerifyMinuteAmount();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter numbers only.");
                return VerifyMinuteAmount();
            }
            return userInput;
        }
        public int GetAppointmentID()
        {
            Console.WriteLine("Please enter a valid appointment ID");
            int appointmentID;
            appointmentID = Convert.ToInt32(Console.ReadLine());
            return appointmentID;
        }
        public int VerifyAppointmentID()
        {
            int userInput = 0;
            try
            {
                userInput = Convert.ToInt32(Console.ReadLine());
                foreach (TherapyTracker.Therapist therapist in mainDirector.masterTherapistList)
                {
                    foreach(TherapyTracker.Appointment appointment in therapist.schedule)
                    {
                        if (userInput == appointment.appointmentID)
                        {
                            return userInput;
                        }
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter numbers only.");
                return VerifyAppointmentID();
            }
            Console.WriteLine("Not a valid ID, printing patient list so you can select an ID");
            mainDirector.PrintPatientList();
            return VerifyAppointmentID();
        }
        
    }
}
