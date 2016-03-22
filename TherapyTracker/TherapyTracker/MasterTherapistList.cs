using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TherapyTracker
{
    public class MasterTherapistList
    {
        public List<Therapist> masterList = new List<Therapist>();

        public void AddTherapist(Therapist Therapist)
        {
            masterList.Add(Therapist);
        }

        public void RemoveTherapist(Therapist Therapist)
        {
            masterList.Remove(Therapist);
        }

        public void PrintTherapistList()
        {
            int i = 0;
            foreach (Therapist therapist in masterList)
            {
                //not sure if discipline is going to print the way I want it to
                Console.WriteLine(i + ". " + therapist.name + ", " + therapist.discipline);
                i++;
            }
        }
    }
}
