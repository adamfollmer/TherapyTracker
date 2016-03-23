using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInput
{
    public class Patient
    {
        public void PatientMenu(TherapyTracker.Patient Patient, TherapyTracker.RunProgram Program)
        {
            Console.WriteLine("Hello "+ Patient.name + "!\n");
            Patient.CheckTherapyTime(Program.mainDirector);
            Console.ReadLine();
        }
    }
}
