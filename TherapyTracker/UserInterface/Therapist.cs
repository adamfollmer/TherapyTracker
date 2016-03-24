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
        public Therapist()
        {
        }
        public void PrintTherapistMenu()
        {
            Console.WriteLine("\nPlease select an option: \n");
            Console.WriteLine("1. Punch in or out");
            Console.WriteLine("2. Add an appointment");
            Console.WriteLine("3. Assign a new patient");
            Console.WriteLine("4. Check productivity from a previous day");
            Console.WriteLine("5. Complete an appointment");
            Console.WriteLine("6. View therapist schedule.");
            Console.WriteLine("7. View completed schedule.\n");
            Console.WriteLine("8. Return to Main Menu");
        }
        public void MakeMenuSelection(TherapyTracker.Therapist Therapist, UserInterface Menu)
        {
            int userChoice = 0;
            while (userChoice != 8)
            {
                Console.WriteLine("Welcome " + Therapist.name + "!");
                PrintTherapistMenu();
                userChoice = Convert.ToInt32(Console.ReadLine());
                switch (userChoice)
                {
                    case 1:
                        Punch(Therapist);
                        break;
                    case 2:
                        AddAppointment(Therapist, Menu);
                        break;
                    case 3:
                        //Get New Patient
                        //Menu.program.mainDirector.
                        break;
                    case 4:
                        CheckProductivity(Therapist);
                        break;
                    case 5:
                        CompleteAppointment(Therapist, Menu);
                        break;
                    case 6:
                        Therapist.PrintSchedule();
                        break;
                    case 7:
                        Therapist.PrintCompletedSchedule();
                        break;
                    default:
                        break;
                }
            }
        }
        public void Punch(TherapyTracker.Therapist Therapist)
        {
            Console.WriteLine("Would you like to (1) live punch or (2) manual punch?");
            if (Convert.ToInt32(Console.ReadLine()) == 1)
            {
                Therapist.AutoPunch();
            }
            else
            {
                ManualPunch(Therapist);
            }
        }
        public void ManualPunch(TherapyTracker.Therapist Therapist)
        {
            Console.WriteLine("Please enter in your time: ");
            DateTime punch = Convert.ToDateTime(Console.ReadLine());
            if (Therapist.punchStatus == true)
            {
                Therapist.ManualPunchOut(punch);
            }
            else
            {
                Therapist.ManualPunchIn(punch);
            }
        }
        public void AddAppointment(TherapyTracker.Therapist Therapist, UserInterface Menu)
        {
            TherapyTracker.Patient holdPatient = Menu.SelectPatient();
            DateTime startTime = GetStartTime();
            DateTime endTime = GetEndTime(startTime);
            Appointment newAppointment = new TherapyTracker.Appointment(startTime, endTime, holdPatient);
            Therapist.AddAppointment(newAppointment);
        }
        public DateTime GetStartTime()
        {
            Console.WriteLine("Appointment start time: ");
            DateTime startTime = Convert.ToDateTime(Console.ReadLine());
            return startTime;
        }
        public DateTime GetEndTime(DateTime StartTime)
        {
            Console.WriteLine("For how many minutes?");
            int timeToSee = Convert.ToInt32(Console.ReadLine());
            DateTime endTime = StartTime.AddMinutes(timeToSee);
            return endTime;
        }
        public void CheckProductivity(TherapyTracker.Therapist Therapist)
        {
            Console.WriteLine("Which date do you want to check your productivity for?");
            DateTime checkDate = Convert.ToDateTime(Console.ReadLine());
            Therapist.CheckProductivity(checkDate.Date);

        }
        public void CompleteAppointment(TherapyTracker.Therapist Therapist, UserInterface Menu)
        {
            TherapyTracker.Patient holdPatient = Menu.SelectPatient();
            Console.WriteLine("\nDid you complete the session as originally scheduled?");
            Console.WriteLine("(1)Yes or (2)No\n");
            int userInput = Convert.ToInt32(Console.ReadLine());
            if (userInput == 1)
            {
                TherapyTracker.CompletedAppointment completed = PullOriginalAppointmentTime(Therapist, holdPatient);
                Therapist.AddCompleteAppointment(completed);
            }
            else
            {
                TherapyTracker.CompletedAppointment completed = GetCompletedAppointmentTime(holdPatient);
                Therapist.AddCompleteAppointment(completed);
            }
        }
        public TherapyTracker.CompletedAppointment PullOriginalAppointmentTime(TherapyTracker.Therapist Therapist, TherapyTracker.Patient Patient)
        {
            foreach (TherapyTracker.Appointment appointment in Therapist.schedule)
            {
                if (appointment.patientIdentifier.uniqueID == Patient.uniqueID)
                {
                    DateTime startTime = appointment.startTime;
                    DateTime endTime = appointment.endTime;
                    TherapyTracker.CompletedAppointment completedAppointment = new TherapyTracker.CompletedAppointment(startTime, endTime, Patient);
                    return completedAppointment;
                }
            }
            Console.WriteLine("No appointments match this therapist and patient.");
            return null;
        }
        public TherapyTracker.CompletedAppointment GetCompletedAppointmentTime(TherapyTracker.Patient Patient)
        {
            DateTime startTime = GetStartTime();
            DateTime endTime = GetEndTime(startTime);
            TherapyTracker.CompletedAppointment completedAppointment = new TherapyTracker.CompletedAppointment(startTime, endTime, Patient);
            return completedAppointment;
        }
    }
}
