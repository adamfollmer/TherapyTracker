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
        public CompletedAppointment (DateTime Start, DateTime End, Patient Patient)
            : base(Start,End, Patient)
        {
        }
        public void AddMinutesToPatient()
        {
            double timeSeen = CalculateTimeSeen();
            patientIdentifier.minutesTowardRUG += timeSeen;
        }
        public double CalculateTimeSeen()
        {
            double timeSeen = subtractTimeDifferenceMinutes();
            return timeSeen;
        }
    }
}
