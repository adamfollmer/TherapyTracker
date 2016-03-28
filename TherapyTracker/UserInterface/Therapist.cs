using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TherapyTracker;


namespace UserInput
{
    public class Therapist
    {
        TherapyTracker.Therapist userTherapist;
        MainMenu menu;
        public Therapist(MainMenu Menu)
        {
            menu = Menu;
        }
        public void AssignTherapist(TherapyTracker.Therapist Therapist)
        {
            userTherapist = Therapist;
            SelectMenuChoice();
        }
        public void PrintTherapistMenu()
        {
            Console.WriteLine("\nPlease select an option: \n");
            Console.WriteLine("1. Punch in or out");
            Console.WriteLine("2. Add an appointment");
            Console.WriteLine("3. Move next patient to the end of the schedule");
            Console.WriteLine("4. Check productivity from a previous day");
            Console.WriteLine("5. Complete an appointment");
            Console.WriteLine("6. View therapist schedule.");
            Console.WriteLine("7. View completed schedule.\n");
            Console.WriteLine("8. Return to Main Menu");
        }
        public void SelectMenuChoice()
        {
            int userChoice = 0;
            while (userChoice != 8)
            {
                Console.WriteLine("Welcome " + userTherapist.name + "!");
                PrintTherapistMenu();
                try
                {
                    userChoice = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                }
                catch (FormatException)
                {
                    Console.WriteLine("[ERROR]: Please enter in a number\n");
                    SelectMenuChoice();
                    return;
                }
                Console.Clear();
                switch (userChoice)
                {
                    case 1:
                        Punch();
                        break;
                    case 2:
                        AddAppointment();
                        break;
                    case 3:
                        userTherapist.MoveCurrentPatientToEndOfDay();
                        break;
                    case 4:
                        CheckProductivity();
                        break;
                    case 5:
                        CompleteAppointment();
                        break;
                    case 6:
                        userTherapist.PrintSchedule();
                        break;
                    case 7:
                        userTherapist.PrintCompletedSchedule();
                        break;
                    default:
                        break;
                }
            }
        }
        public void Punch()
        {
            Console.WriteLine("Would you like to (1) live punch or (2) manual punch?\n");
            int userChoice = VerifyOneOrTwo();
            if (userChoice == 1)
            {
                userTherapist.AutoPunch();
            }
            else
            {
                ManualPunch();
            }
        }
        public int VerifyOneOrTwo()
        {
            int userInput = 0;
            try
            {
                userInput = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (userInput < 0 || userInput > 2)
                {
                    Console.WriteLine("[ERROR]: Please select 1 or 2\n");
                    return VerifyOneOrTwo();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("[ERROR]: Please enter numbers only.\n");
                return VerifyOneOrTwo();
            }
            return userInput;
        }
        public void ManualPunch()
        {
            DateTime punch = menu.VerifyFullDateTimeSequence();
            if (punch.Ticks > DateTime.Now.Ticks)
            {
                Console.WriteLine("[ERROR]: Date can't be in the future");
                ManualPunch();
                return;
            }
            if (userTherapist.punchStatus == true)
            {
                if (punch.Ticks < userTherapist.punchIn.Ticks)
                {
                    Console.WriteLine("[ERROR]: Attempted punch out would occur before registered punch in");
                    ManualPunch();
                    return;
                }
                userTherapist.ManualPunchOut(punch);
            }
            else
            {
                userTherapist.ManualPunchIn(punch);
            }
        }
        public void AddAppointment()
        {
            TherapyTracker.Patient holdPatient = menu.SelectPatient();
            DateTime startTime = GetStartTime();
            DateTime endTime = GetEndTime(startTime);
            Appointment newAppointment = new TherapyTracker.Appointment(startTime, endTime, holdPatient);
            userTherapist.AddAppointment(newAppointment);
        }
        public DateTime GetStartTime()
        {
            Console.WriteLine("Appointment start time: \n");
            DateTime startTime = menu.VerifyFullDateTimeSequence();
            return startTime;
        }
        public DateTime GetEndTime(DateTime StartTime)
        {
            Console.WriteLine("FOR how many minutes?\n");
            int timeToSee = (int)menu.userDirector.VerifyMinuteAmount();
            DateTime endTime = StartTime.AddMinutes(timeToSee);
            return endTime;
        }
        public void CheckProductivity()
        {
            Console.WriteLine("Which date do you want to check your productivity for?\n");
            DateTime checkDate = menu.VerifyDateOnlySequence().Date;
            userTherapist.CheckProductivity(checkDate.Date);
        }
        public void CompleteAppointment()
        {
            TherapyTracker.Appointment appointmentToComplete = GetAppointment();
            Console.WriteLine("Did you complete the session as originally scheduled?\n");
            Console.WriteLine("(1)Yes or (2)No\n");
            int userInput = VerifyOneOrTwo();
            if (userInput == 1)
            {
                TherapyTracker.CompletedAppointment completed = TransferScheduledAppointmentToCompletedAppointment(appointmentToComplete);
                userTherapist.AddCompleteAppointment(completed);
            }
            else
            {
                TherapyTracker.CompletedAppointment completed = GetCompletedAppointmentTime(appointmentToComplete);
                userTherapist.AddCompleteAppointment(completed);
            }
        }
        public TherapyTracker.CompletedAppointment TransferScheduledAppointmentToCompletedAppointment(TherapyTracker.Appointment Appointment)
        {
            TherapyTracker.CompletedAppointment completedAppointment = new TherapyTracker.CompletedAppointment(Appointment.startTime, Appointment.endTime, Appointment.patientIdentifier);
            completedAppointment.appointmentID = Appointment.appointmentID;
            return completedAppointment;
        }
        public TherapyTracker.CompletedAppointment GetCompletedAppointmentTime(TherapyTracker.Appointment Appointment)
        {
            TherapyTracker.CompletedAppointment completedAppointment = TransferScheduledAppointmentToCompletedAppointment(Appointment);
            completedAppointment.startTime = GetStartTime();
            completedAppointment.endTime = GetEndTime(completedAppointment.startTime);
            return completedAppointment;
        }
        public TherapyTracker.Appointment GetAppointment()
        {
            int userInput = menu.userDirector.GetAppointmentID();
            foreach (Appointment appointment in userTherapist.schedule)
            {
                if (userInput == appointment.appointmentID)
                {
                    return appointment;
                }
            }
            Console.WriteLine("[ERROR]: This appointment is not in this therapists schedule");
            return GetAppointment();
        }
    }

}
