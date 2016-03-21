using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TherapyTracker
{
    public class Time
    {
        public DateTime startTime;
        public DateTime endTime;
        public Time (DateTime Start, DateTime End)
        {
            startTime = Start;
            endTime = End;
        }
        public double subtractTimeDifferenceMinutes()
        {
            TimeSpan timeDiff = endTime - startTime;
            return timeDiff.TotalMinutes;
        }

        public double subtractTimeDifferenceHours()
        {
            TimeSpan timeDiff = endTime - startTime;
            return timeDiff.TotalHours;
        }
    }
}
