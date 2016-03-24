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
        public int uniqueID;
        public ResourceUtilizationGroup currentRUG;
        public ResourceUtilizationGroup goalRUG;
        public double minutesTowardRUG;
        public List<PatientTimeConflicts> potentialConflicts = new List<PatientTimeConflicts>();

        public Patient(String Name, int UniqueID)
        {
            name = Name;
            uniqueID = UniqueID;
        }
        public enum ResourceUtilizationGroup
        {
            RU = 1,
            RV = 2,
            RH = 3,
            RM = 4,
            RL = 5,
            NA
        }
        public void DetermineRUG()
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
        public void printTimeConflicts()
        {
            foreach (PatientTimeConflicts conflict in potentialConflicts)
            {
                Console.WriteLine(conflict.conflictIdentifier);
                Console.WriteLine("From " + conflict.startTime + " to " + conflict.endTime);
            }
        }
        public void CheckTherapyTime(Director Director)
        {
            foreach (Therapist therapist in Director.masterTherapistList)
            {
                foreach (Appointment appointment in therapist.schedule)
                {
                    if (appointment.patientIdentifier.uniqueID == this.uniqueID)
                    {
                        Console.WriteLine("You have " + therapist.discipline + " therapy" + " at ");
                        Console.Write(appointment.startTime + " with " + therapist.name + ".");
                    }
                }
            }
        }
    }
}
