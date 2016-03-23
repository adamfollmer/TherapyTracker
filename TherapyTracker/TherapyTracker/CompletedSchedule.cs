using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TherapyTracker
{
    public class CompletedSchedule
    {
        public Therapist therapist;
        public List<CompletedAppointment> completedTherapistSchedule = new List<CompletedAppointment>();
        public CompletedSchedule (Therapist Therapist)
        {
            therapist = Therapist;
        }

        public void addCompletedAppointment (CompletedAppointment appointment)
        {
            completedTherapistSchedule.Add(appointment);
        }

        public void removeCompletedAppointment (CompletedAppointment appointment)
        {
            completedTherapistSchedule.Remove(appointment);
        }
        public double calculatePatientContactMinutes()
        {
            double patientContactMinutes = 0;
            foreach (CompletedAppointment appointment in completedTherapistSchedule)
            {
                patientContactMinutes += appointment.CalculateTimeSeen();
            }
            return patientContactMinutes;
        }
    }
}
