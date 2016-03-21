using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TherapyTracker
{
    class Appointment:Time
    {
        public Patient patientIdentifier;
        //Considering a static variable to function as a counter to provide a unique ID
        //May do the same for patients?
        public Appointment(DateTime Start, DateTime End, Patient Patient)
            : base(Start, End)
        {
            patientIdentifier = Patient;
        }
    }
}
