using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TherapyTracker;

namespace PopulatedInformation
{
    public class PopulateTherapist
    {
        public TherapyTracker.MasterTherapistList therapistList = new TherapyTracker.MasterTherapistList();
        public TherapyTracker.Therapist one = new TherapyTracker.Therapist("Steve", Therapist.Discipline.speechTherapist);
        public TherapyTracker.Therapist two = new TherapyTracker.Therapist("Amy", Therapist.Discipline.occupationalTherapist);
        public TherapyTracker.Therapist three = new TherapyTracker.Therapist("Roger", Therapist.Discipline.physicalTherapist);
        public TherapyTracker.Therapist four = new TherapyTracker.Therapist("Tina", Therapist.Discipline.physicalTherapist);

        public PopulateTherapist()
        {
            therapistList.AddTherapist(one);
            therapistList.AddTherapist(two);
            therapistList.AddTherapist(three);
            therapistList.AddTherapist(four);

        }
    }
}
