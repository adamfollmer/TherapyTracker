using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TherapyTracker
{
    public class Nurse
    {
        public void AddPatient(Patient Patient, MasterPatientList PatientList)
        {
            PatientList.AddPatient(Patient);
            Console.WriteLine("\nNew patient " + Patient.name + " added to the system.\n");
        }
        public void RemovePatient(Patient Patient, MasterPatientList PatientList)
        {
            PatientList.RemovePatient(Patient);
        }
        public void AddPatientPrefrences(Patient Patient, PatientTimeConflicts Conflict)
        {
            Patient.potentialConflicts.Add(Conflict);
        }
        public void RemovePatientPreference(Patient Patient, int ConflictTypeNumber)
        {
            foreach (PatientTimeConflicts conflicts in Patient.potentialConflicts)
            {
                if ((int)conflicts.conflictIdentifier == ConflictTypeNumber)
                {
                    Patient.potentialConflicts.Remove(conflicts);
                }
            }
        }
    }
}
