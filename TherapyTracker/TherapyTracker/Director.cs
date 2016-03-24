using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TherapyTracker
{
    public class Director
    {
        public string name;
        public List<List<Appointment>> masterSchedule = new List<List<Appointment>>();
        public List<Patient> masterPatientList = new List<Patient>();
        public List<Therapist> masterTherapistList = new List<Therapist>();
        public Director(string Name)
        {
            name = Name;
        }
        public void UpdatePatientRUGLevel(Patient Patient, int Rug)
        {
            Patient.goalRUG = (Patient.ResourceUtilizationGroup)Rug;
        }
        public void IncreasePatientTimeSeen(int AppointmentID, double IncreasedTime)
        {
            if (GetAppointmentFromID(AppointmentID) != null)
            {
                Appointment holdAppointment = GetAppointmentFromID(AppointmentID);
                holdAppointment.endTime.AddMinutes(IncreasedTime);
                if (CheckTimeConflict(holdAppointment) == true)
                {
                    Console.WriteLine("There is a time conflict with this");
                }
                else
                {
                    SwitchAppointments(AppointmentID, holdAppointment);
                }
            }
            //If not, rearrange schedule to fit everything with no conflicts - LOL YEAH RIGHT
        }
        public void DecreasePatientTimeSeen(int AppointmentID, double IncreasedTime)
        {
            if (GetAppointmentFromID(AppointmentID) != null)
            {
                Appointment holdAppointment = GetAppointmentFromID(AppointmentID);
                holdAppointment.endTime.AddMinutes(-IncreasedTime);
                if (CheckTimeConflict(holdAppointment) == true)
                {
                    Console.WriteLine("There is a time conflict with this");
                }
                else
                {
                    SwitchAppointments(AppointmentID, holdAppointment);
                }
            }
        }
        public bool CheckTimeConflict(Appointment ProposedAppointment)
        {
            foreach (List<Appointment> therapistSchedule in masterSchedule)
            {
                foreach (Appointment appointment in therapistSchedule)
                {
                    if (appointment.patientIdentifier.uniqueID == ProposedAppointment.patientIdentifier.uniqueID)
                    {
                        if (appointment.endTime.Ticks >= ProposedAppointment.startTime.Ticks ||
                             ProposedAppointment.endTime.Ticks >= appointment.startTime.Ticks)
                        {
                            return true;
                        }
                    }

                }
            }
            return false;
        }
        public Appointment GetAppointmentFromID (int AppointmentID)
        {
            foreach(List<Appointment> therapistSchedule in masterSchedule)
            {
                foreach(Appointment appointment in therapistSchedule)
                {
                    if (appointment.appointmentID == AppointmentID)
                    {
                        return appointment;
                    }
                }
            }
            Console.WriteLine("Appointment not found, returning to main menu");
            return null;
        }
        public void SwitchAppointments(int AppointmentID, Appointment NewAppointment)
        {
            foreach (List<Appointment> therapistSchedule in masterSchedule)
            {
                foreach (Appointment appointment in therapistSchedule)
                {
                    if (appointment.appointmentID == AppointmentID)
                    {
                        therapistSchedule.Remove(appointment);
                        therapistSchedule.Add(NewAppointment);
                        break;
                    }
                }
            }
        }
        public void PrintTherapistSchedules()
        {
            foreach (List<Appointment> therapistSchedule in masterSchedule)
            {
                //Console.WriteLine(therapistSchedule.therapist.name + "'s schedule:");
                foreach (Appointment appointment in therapistSchedule)
                {
                    Console.WriteLine("ID: " + appointment.appointmentID);
                    Console.WriteLine("Patient name: " + appointment.patientIdentifier.name);
                    Console.WriteLine("From " + appointment.startTime + " to " + appointment.endTime);
                    Console.WriteLine();
                }
            }
        }
    }
}
