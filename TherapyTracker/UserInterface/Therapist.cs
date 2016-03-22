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
        UserInterface menu = new UserInterface();
        public Therapist()
        {
        }
        public void TherapistMenu()
        {
            Console.WriteLine("\nPlease select an option: \n");
            Console.WriteLine("1. Punch in or out");
            Console.WriteLine("2. Add an appointment");
            Console.WriteLine("3. Assign a new patient");
            Console.WriteLine("4. Check productivity from a previous day");
            Console.WriteLine("5. Complete an appointment\n");
        }
        public void MakeMenuSelection(TherapyTracker.Therapist Therapist)
        {
            TherapistMenu();
            int userChoice = Convert.ToInt32(Console.ReadLine());
            switch (userChoice)
            {
                case 1:
                    Punch(Therapist);
                    break;
                case 2:
                    AddAppointment(Therapist);
                    break;
                case 3:
                    //Get New Patient
                    break;
                case 4:
                    CheckProductivity(Therapist);
                    break;
                case 5:
                    //Complete appointment
                    break;
                default:
                    break;
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
                Therapist.punchStatus = false;
            }
            else
            {
                Therapist.ManualPunchIn(punch);
                Therapist.punchStatus = true;
            }
        }
        public void ChangePatientPreferences()
        {
            menu.SelectPatient();
            Console.WriteLine("When will the patient first be unavailable?");
            DateTime startTime = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("When will the patient be available again?");
            DateTime endTime = Convert.ToDateTime(Console.ReadLine());
            //kick over the TIME and PATIENT to therapist.ChangePatientPrefernces();
        }
        public Appointment AddAppointment(TherapyTracker.Therapist Therapist)
        {
            TherapyTracker.Patient holdPatient = menu.SelectPatient();
            Console.WriteLine("When do you want to see the patient?");
            DateTime startTime = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("How many minutes do you want to see the patient?");
            int timeToSee = Convert.ToInt32(Console.ReadLine());
            DateTime endTime = startTime.AddMinutes(timeToSee);
            Appointment newAppointment = new TherapyTracker.Appointment(startTime, endTime, holdPatient);
            return newAppointment;
        }
        public void CheckProductivity(TherapyTracker.Therapist Therapist)
        {
            Console.WriteLine("Which date do you want to check your productivity for?");
            DateTime checkDate = Convert.ToDateTime(Console.ReadLine());
            Therapist.CheckProductivity(checkDate.Date);
            
        }
    }
}
