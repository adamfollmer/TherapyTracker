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
        public Director mainDirector; 
        public RunProgram()
        {
            mainDirector = new Director("Director", therapistList, patientList);
            therapistList = new MasterTherapistList();
            patientList = new MasterPatientList();
        }

        public void PrePopulate()
        {
            Building buildingOne = new Building();
            buildingOne.AddToTherapistList(therapistList);
            buildingOne.AddToPatientList(patientList);
            buildingOne.AddAppointmentsToSchedule();
            buildingOne.AddToScheduleList(mainDirector);

        }
        
    }
}
