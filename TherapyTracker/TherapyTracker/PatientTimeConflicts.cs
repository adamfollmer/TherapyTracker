using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TherapyTracker
{
    public class PatientTimeConflicts:Time
    {
        public ConflictType conflictIdentifier;
        public PatientTimeConflicts (DateTime Start, DateTime End, ConflictType Conflict)
            : base(Start, End)
        {
            conflictIdentifier = Conflict;
        }

        public enum ConflictType
        {
            Meal = 1,
            Appointment = 2,
            Preference = 3,
        };
    }
}
