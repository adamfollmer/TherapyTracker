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
        public Director mainDirector; 
        public RunProgram()
        {
            mainDirector = new Director("Director", therapistList);
            therapistList = new MasterTherapistList();
        }

        public void PrePopulate()
        {
            Building buildingOne = new Building();
            buildingOne.AddToTherapistList(therapistList);
            buildingOne.AddToPatientList(mainDirector);
            buildingOne.AddAppointmentsToSchedule();
            buildingOne.AddToScheduleList(mainDirector);

        }
        
    }
}
