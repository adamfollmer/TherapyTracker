using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TherapyTracker
{
    public class Appointment:Time
    {
        public Random random = new Random(Guid.NewGuid().GetHashCode());
        public int appointmentID;
        public Patient patientIdentifier;
        public Appointment(DateTime Start, DateTime End, Patient Patient)
            : base(Start, End)
        {
            patientIdentifier = Patient;
            appointmentID = GenerateRandomID();
        }

        private int GenerateRandomID()
        {
            return random.Next(1000, 9999);
        }
    }
}
