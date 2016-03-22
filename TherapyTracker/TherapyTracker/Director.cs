using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TherapyTracker
{
    public class Director:Therapist
    {
        public Director(String Name, Discipline Discipline) :
            base(Name, Discipline)
        {

        }
        public void UpdatePatientRUGLevel(Patient Patient, int Rug)
        {
            Patient.goalRUG = (Patient.ResourceUtilizationGroup)Rug;
        }
        public void IncreasePatientTimeSeen(Patient Patient, Therapist Therapist, int IncreasedTime)//Will be difficult to verify that this is okay
        {
            //Ask which patient
            //Ask which discipline to increase
            //If it can push the schedule, do that
            //If not, rearrange schedule to fit everything with no conflicts
        }
        public void DecreasePatientTimeSeen(Patient Patient, Therapist Therapist, int DecreasedTime)
        {

        }
    }
}
