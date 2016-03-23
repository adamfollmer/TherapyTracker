using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TherapyTracker
{
     public class Schedule
    {
        public Therapist therapist;
        public List<Appointment> therapistSchedule = new List<Appointment>();
        public Schedule(Therapist Therapist)
        {
            therapist = Therapist;
        }
         public void addAppointment (Appointment appointment)
        {
            therapistSchedule.Add(appointment);
        }
        public void removeAppointment (Appointment appointment)
        {
            therapistSchedule.Remove(appointment);
        }
    }
}
