using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TherapyTracker;


namespace UserInput
{
    class Therapist
    {
        TherapyTracker.Therapist therapist = new TherapyTracker.Therapist("Adam", TherapyTracker.Therapist.Discipline.speechTherapist);
        //With the above, ideally there will be a list of therapists that the user selects to act as
        
        public static void TherapistMenu()
        {
            Console.WriteLine("Please select an option: ");
            Console.WriteLine("1. Punch in or out");
            Console.WriteLine("2. Add an appointment");
            Console.WriteLine("3. Assign a new patient");
            Console.WriteLine("4. Change a patient's preference for schedule");
            Console.WriteLine("5. Check productivity from a previous day");
            Console.WriteLine("6. Complete an appointment");
        }
        public void MakeMenuSelection()
        {
            int userChoice = Convert.ToInt32(Console.ReadLine());
            switch (userChoice)
            {
                case 1:
                    Punch();
                    break;
                case 2:
                    //Add Appointment
                    break;
                case 3:
                    //Get New Patient
                    break;
                case 4:
                    //Change Patient Pref.
                    break;
                case 5:
                    //Check Productivity
                    break;
                case 6:
                    //Complete appointment
                    break;
                default:
                    break;
            }
        }
        public void Punch()
        {
            Console.WriteLine("Would you like to (1) live punch or (2) manual punch?");
            if (Convert.ToInt32(Console.ReadLine()) == 1)
            {
                therapist.AutoPunch();
            }
            else
            {
                ManualPunch();
            }
        }
        public void ManualPunch()
        {
            Console.WriteLine("Please enter in your time: ");
            DateTime punch = Convert.ToDateTime(Console.ReadLine());
            if (therapist.punchStatus == true)
            {
                therapist.ManualPunchOut(punch);
                therapist.punchStatus = false;
            }
            else
            {
                therapist.ManualPunchIn(punch);
                therapist.punchStatus = true;
            }
        }
        public void CheckOutPatient()
        {
            Console.WriteLine("Which patient would you like to use?");
            int patientIdentifier = Convert.ToInt32(Console.ReadLine());
        }
        public void ChangePatientPreferences()
        {
            CheckOutPatient();
            Console.WriteLine("When will the patient first be unavailable?");
            DateTime startTime = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("When will the patient be available again?");
            DateTime endTime = Convert.ToDateTime(Console.ReadLine());
            //kick over the TIME and PATIENT to therapist.ChangePatientPrefernces();
        }
        public void AddAppointment()
        {
            CheckOutPatient();
            Console.WriteLine("When do you want to see the patient?");
            DateTime startTime = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("How many minutes do you want to see the patient?");
            int timeToSee = Convert.ToInt32(Console.ReadLine());
            DateTime endTime = startTime.AddMinutes(timeToSee);
            //kick over an APPOINTMENT to therapist.AddAppointment();
        }
        public void CheckProductivity()
        {
            Console.WriteLine("Which date do you want to check your productivity for?");
            DateTime checkDate = Convert.ToDateTime(Console.ReadLine());
            //Kick over a DATE to therapist.CheckProductivity();
        }
    }
}
