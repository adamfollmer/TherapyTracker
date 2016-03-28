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
                holdAppointment.endTime = holdAppointment.endTime.AddMinutes(IncreasedTime);
                if (CheckTimeConflict(holdAppointment) == true)
                {
                    Console.WriteLine("[ERROR]: There is a time conflict with this");
                }
                else
                {
                    SwitchTimeOfAppointment(AppointmentID, holdAppointment);
                }
            }
        }
        public void DecreasePatientTimeSeen(int AppointmentID, double DecreasedTime)
        {
            if (GetAppointmentFromID(AppointmentID) != null)
            {
                Appointment holdAppointment = GetAppointmentFromID(AppointmentID);
                holdAppointment.endTime = holdAppointment.endTime.AddMinutes(-DecreasedTime);
                if (CheckTimeConflict(holdAppointment) == true)
                {
                    Console.WriteLine("[ERROR}: There is a time conflict with this");
                }
                else
                {
                    SwitchTimeOfAppointment(AppointmentID, holdAppointment);
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
                        if (appointment.appointmentID == ProposedAppointment.appointmentID)
                        {
                            
                        } else if (appointment.endTime.Ticks >= ProposedAppointment.startTime.Ticks ||
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
            Console.WriteLine("[ERROR]: Appointment not found, returning to main menu");
            return null;
        }
        public void SwitchTimeOfAppointment(int AppointmentID, Appointment NewAppointment)
        {
            foreach (Therapist therapist in masterTherapistList)
            {
                foreach (Appointment appointment in therapist.schedule)
                {
                    if (appointment.appointmentID == AppointmentID)
                    {
                        appointment.endTime = NewAppointment.endTime;
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
