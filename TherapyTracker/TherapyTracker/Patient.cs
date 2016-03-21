using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TherapyTracker
{
    public class Patient
    {
        public String name;
        public ResourceUtilizationGroup currentRUG;
        public double minutesTowardRUG;
        List<PatientTimeConflicts> potentialConflicts = new List<PatientTimeConflicts>();

        public Patient(String Name)
        {
            name = Name;
        }
        public enum ResourceUtilizationGroup
        {
            RU,
            RV,
            RH,
            RM,
            RL,
            NA
        }
        public void AssignRUG()
        {
            if (minutesTowardRUG >= 720)
            {
                currentRUG = ResourceUtilizationGroup.RU;
            } else if (minutesTowardRUG >= 500)
            {
                currentRUG = ResourceUtilizationGroup.RV;
            } else if (minutesTowardRUG >= 325)
            {
                currentRUG = ResourceUtilizationGroup.RH;
            } else if (minutesTowardRUG >= 150)
            {
                currentRUG = ResourceUtilizationGroup.RM;
            } else if (minutesTowardRUG >= 45)
            {
                currentRUG = ResourceUtilizationGroup.RL;
            } else
            {
                currentRUG = ResourceUtilizationGroup.NA;
            }
        }
        public void ChangePatientPrefrences()
        {
            //create new PatientTimeConflict 
            //Add it to potentialConflicts list in the patient
            //Print the new conflict
        }
        public void addTimeConflict(Time Time, PatientTimeConflicts.ConflictType Conflict)
        {
            PatientTimeConflicts conflict = new PatientTimeConflicts(Time.startTime, Time.endTime, Conflict);
        }

        public void printTimeConflicts()
        {

        }
    }
}
