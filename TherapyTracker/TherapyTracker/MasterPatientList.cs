using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TherapyTracker
{
    class MasterPatientList
    {
        List<Patient> masterPatientList = new List<Patient>();

        public MasterPatientList()
        {
        }

        public void AddPatient(Patient Patient)
        {
            masterPatientList.Add(Patient);
            Console.WriteLine(Patient.name + " has been added.");
        }
        public void RemovePatient(Patient Patient)
        {
            masterPatientList.Remove(Patient);
            Console.WriteLine(Patient.name + " has been removed.");
        }
        public void PrintPatientList()
        {
            foreach (Patient patient in masterPatientList)
            {
                Console.WriteLine("Name: " + patient.name );
            }
        }
    }
}
