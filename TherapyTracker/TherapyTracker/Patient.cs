using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TherapyTracker
{
    public class Patient
    {
        public String name;
        //ResourceUtilizationGrouping currentRUG;
        int minutesTowardRUG;
        List<PatientTimeConflicts> potentialConflicts = new List<PatientTimeConflicts>();

        public Patient()
        {

        }

        public void addTimeConflict(Time Time, PatientTimeConflicts.ConflictType Conflict)
        {
            PatientTimeConflicts conflict = new PatientTimeConflicts(Time.startTime, Time.endTime, Conflict);
        }

        public void printTimeConflicts()
        {

        }
    }
}
