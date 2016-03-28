using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TherapyTracker
{
    public class Nurse
    {
        public void AddPatient(Patient Patient, Director Director)
        {
            Director.masterPatientList.Add(Patient);
            Console.WriteLine("\nNew patient " + Patient.name + " added to the system.\n");
        }
        public void RemovePatient(Patient Patient, Director Director)
        {
            Director.masterPatientList.Remove(Patient);
        }
        public void AddPatientPrefrences(Patient Patient, PatientTimeConflicts Conflict)
        {
            Patient.potentialConflicts.Add(Conflict);
            Console.WriteLine("Conflict added for " + Patient.name + ".");
            Console.Clear();
        }
        public void RemovePatientPreference(Patient Patient, int ConflictTypeNumber)
        {
            foreach (PatientTimeConflicts conflicts in Patient.potentialConflicts)
            {
                if ((int)conflicts.conflictIdentifier == ConflictTypeNumber)
                {
                    Patient.potentialConflicts.Remove(conflicts);
                    Console.Clear();
                    Console.WriteLine("Conflict removed");
                    return;
                }
            }
            Console.Clear();
            Console.WriteLine("[ERROR]: No conflict exists matching this critera");
        }
    }
}
