using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TherapyTracker
{
    public class RunProgram
    {
        public MasterTherapistList therapistList;
        public MasterPatientList patientList;
        public MasterSchedule scheduleList;
        public Director mainDirector; 
        public RunProgram()
        {
            therapistList = new MasterTherapistList();
            patientList = new MasterPatientList();
            scheduleList = new MasterSchedule();
            mainDirector = new Director("Steve", Therapist.Discipline.occupationalTherapist);
        }

        public void PrePopulate()
        {
            Building buildingOne = new Building();
            buildingOne.AddToTherapistList(therapistList);
            buildingOne.AddToPatientList(patientList);
            buildingOne.AddAppointmentsToSchedule();
            buildingOne.AddToScheduleList(scheduleList);
        }
        
    }
}
