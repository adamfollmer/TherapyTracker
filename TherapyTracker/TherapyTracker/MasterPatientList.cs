using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TherapyTracker
{
    public class MasterPatientList
    {
        public List<Patient> masterPatientList = new List<Patient>();

        public MasterPatientList()
        {
        }

        public void AddPatient(Patient Patient)
        {
            masterPatientList.Add(Patient);
        }
        public void RemovePatient(Patient Patient)
        {
            masterPatientList.Remove(Patient);
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
