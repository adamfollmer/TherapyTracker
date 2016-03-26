using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInput
{
    public class Patient
    {
        TherapyTracker.Director mainDirector;
        TherapyTracker.Patient patient;
        public Patient (MainMenu Menu)
        {
            mainDirector = Menu.program.mainDirector;
        }
        public void AssignPatient(TherapyTracker.Patient Patient)
        {
            patient = Patient;
            PatientMenu();
        }
        public void PatientMenu()
        {
            Console.WriteLine("Hello "+ patient.name + "!\n");
            patient.CheckTherapyTime(mainDirector);
        }
    }
}
