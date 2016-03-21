using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TherapyTracker
{
    class Appointment:Time
    {
        Patient patientIdentifier;
        public Appointment(DateTime Start, DateTime End, Patient Patient)
            : base(Start, End)
        {
            patientIdentifier = Patient;
        }
    }
}
