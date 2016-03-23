using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TherapyTracker
{
    public class RunProgram
    {
        public Director mainDirector; 
        public RunProgram()
        {
            mainDirector = new Director("Director");
        }
        public void PrePopulate()
        {
            Building buildingOne = new Building();
            buildingOne.AddToTherapistList(mainDirector);
            buildingOne.AddToPatientList(mainDirector);
            buildingOne.AddAppointmentsToSchedule();
            buildingOne.AddToScheduleList(mainDirector);
        }
        
    }
}
