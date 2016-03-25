using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace TherapyTracker
{
    public class Director
    {
        public string name;
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
            foreach (Therapist therapist in masterTherapistList)
            {
                foreach (Appointment appointment in therapist.schedule)
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
            foreach(Therapist therapist in masterTherapistList)
            {
                foreach(Appointment appointment in therapist.schedule)
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
            foreach (Therapist therapist in masterTherapistList)
            {
                foreach (Appointment appointment in therapist.schedule)
                {
                    if (appointment.appointmentID == AppointmentID)
                    {
                        therapist.schedule.Remove(appointment);
                        therapist.schedule.Add(NewAppointment);
                        break;
                    }
                }
            }
        }
        public void PrintTherapistSchedules()
        {
            foreach (Therapist therapist in masterTherapistList)
            {
                Console.WriteLine(therapist.name + "'s schedule:");
                foreach (Appointment appointment in therapist.schedule)
                {
                    Console.WriteLine("ID: " + appointment.appointmentID);
                    Console.WriteLine("Patient name: " + appointment.patientIdentifier.name);
                    Console.WriteLine("From " + appointment.startTime + " to " + appointment.endTime);
                    Console.WriteLine();
                }
            }
        }
        public void PrintPatientList()
        {
            foreach (Patient patient in masterPatientList)
            {
                Console.WriteLine("Name: " + patient.name + " ID: " + patient.uniqueID);
                Console.WriteLine("Goal RUG: " + patient.goalRUG + " Current RUG: " + patient.currentRUG + " Current Minutes: " + patient.minutesTowardRUG);
                Console.WriteLine("Current conflicts: ");
                patient.printTimeConflicts();
                Console.WriteLine();
            }
        }
    }
}
