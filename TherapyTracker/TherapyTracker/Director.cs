﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TherapyTracker
{
    class Director:Therapist
    {
        public Director(String Name, Discipline Discipline) :
            base(Name, Discipline)
        {

        }
        public void UpdatePatientRUGLevel()
        {
            //Pull patient
            //Change goal RUG level
            //
        }
        public void ModifyTimeSeen(Appointment appointment)//Will be difficult
        {
            //Ask which patient
            //Ask which discipline to increase
            //If it can push the schedule, do that
            //If not, rearrange schedule to fit everything with no conflicts
        }
    }
}
