using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TherapyTracker
{
    public class CompletedAppointment:Appointment
        //This class is needed to extend beyond the regular appointment
        //because the parent class is a theoretical/scheduled object
        //Whereas this is used only when an appointment is completed.
    {
        public double timeSeen;
        public CompletedAppointment (DateTime Start, DateTime End, Patient Patient)
            : base(Start,End, Patient)
        {
             timeSeen = subtractTimeDifferenceMinutes();
            //Is the above kosher or should I make a function to do the math?
        }
        public void AddMinutesToPatient()
        {
            patientIdentifier.minutesTowardRUG += timeSeen;
        }
    }
}
