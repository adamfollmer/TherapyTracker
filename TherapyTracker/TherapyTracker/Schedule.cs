using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TherapyTracker
{
    public class Schedule
    {
         List<Appointment> therapistSchedule = new List<Appointment>();
        public Schedule()
        {
        }

         void addAppointment (Appointment appointment)
        {
            therapistSchedule.Add(appointment);
        }
    }
}
