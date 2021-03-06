﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TherapyTracker
{
    public class Therapist
    {
        public string name;
        public Discipline discipline;
        public List<Appointment> schedule;
        public List<CompletedAppointment> completedSchedule;
        public DateTime punchIn = new DateTime(2016, 1, 1);
        public DateTime punchOut = new DateTime(2016, 1, 1);
        public Dictionary<DateTime, double> productivityLog = new Dictionary<DateTime, double>();
        public bool punchStatus = false;

        public Therapist(string Name, Discipline Discipline)
        {
            name = Name;
            schedule = new List<Appointment>();
            completedSchedule = new List<CompletedAppointment>();
            discipline = Discipline;
        }
        public enum Discipline
        {
            Speech,
            Physical,
            Occupational,
        }
        public void AddAppointment(Appointment Appointment)
        {
            schedule.Add(Appointment);
            Console.WriteLine("\nAn appointment with patient " + Appointment.patientIdentifier.name + " has been added to " + name + "'s schedule.");
            Console.WriteLine("Starting at " + Appointment.startTime + " and ending at " + Appointment.endTime + ".\n");
        }
        public void MoveCurrentPatientToEndOfDay()
        {
            Appointment conflictedAppointment = schedule[0];
            schedule.RemoveAt(0);
            schedule.Add(conflictedAppointment);
            double appointmentLength = conflictedAppointment.subtractTimeDifferenceMinutes();
            AdjustTimeForMovedPatient(appointmentLength);
            Console.WriteLine("Move successful. Printing new Schedule:");
            PrintSchedule();
        }
        public void AdjustTimeForMovedPatient(double AppointmentLength)
        {
            DateTime newStartTime = schedule[schedule.Count - 2].endTime;
            newStartTime = newStartTime.AddMinutes(5);
            schedule[schedule.Count - 1].startTime = newStartTime;
            DateTime newEndTime = newStartTime.AddMinutes(AppointmentLength);
            schedule[schedule.Count - 1].endTime = newEndTime;
        }
        public void AutoPunch()
        {
            if (punchStatus == false)
            {
                punchIn = DateTime.Now;
                punchStatus = true;
                Console.WriteLine("\nPunch IN accepted at " + punchIn.ToShortTimeString());
            }
            else
            {
                punchOut = DateTime.Now;
                AddProductivity();
                punchStatus = false;
                Console.WriteLine("\nPunch OUT accepted at " + punchOut.ToShortTimeString());
            }
        }
        public void ManualPunchIn(DateTime time)
        {
            punchIn = time;
            punchStatus = true;
            Console.WriteLine("\nPunch IN accepted at " + punchIn.ToShortTimeString() + " for " + punchIn.ToString("d"));
        }
        public void ManualPunchOut(DateTime time)
        {
            punchOut = time;
            punchStatus = false;
            Console.WriteLine("\nPunch OUT accepted at " + punchOut.ToShortTimeString() + " for " + punchOut.ToString("d"));
            Console.WriteLine();
            AddProductivity();
        }
        public void CheckProductivity(DateTime CheckDate)
        {
            double productivitiy;
            if (productivityLog.TryGetValue(CheckDate, out productivitiy))
            {
                Console.WriteLine(productivitiy);
            }
            else
            {
                Console.WriteLine("No productivity information logged for that day");
            }
        }
        public void AddProductivity()
        {
            Time punchInPunchOut = new Time(punchIn, punchOut);
            double hoursWorked = punchInPunchOut.subtractTimeDifferenceMinutes();
            double patientContact = CalculatePatientContactMinutes();
            double productivity = (patientContact / hoursWorked) * 100;
            productivityLog.Add(punchIn.Date, productivity);

        }
        public double CalculatePatientContactMinutes()
        {
            double patientContactMinutes = 0;
            foreach (CompletedAppointment appointment in completedSchedule)
            {
                patientContactMinutes += appointment.CalculateTimeSeen();
            }
            return patientContactMinutes;

        }
        public void AddCompleteAppointment(CompletedAppointment CompletedAppointment)
        {
            completedSchedule.Add(CompletedAppointment);
            CompletedAppointment.AddMinutesToPatient();
            CompletedAppointment.patientIdentifier.DetermineRUG();
            Console.WriteLine("\nAn appointment has been COMPLETED with " + CompletedAppointment.patientIdentifier.name);
            Console.WriteLine("Starting at " + CompletedAppointment.startTime + " and ending at " + CompletedAppointment.endTime + ".\n");
            RemovePreviousAppointment(CompletedAppointment);
        }
        public void PrintSchedule()
        {
            Console.WriteLine(name + "'s Schedule");
            foreach (Appointment appointment in schedule)
            {
                Console.WriteLine();
                Console.WriteLine("Patient name: " + appointment.patientIdentifier.name);
                Console.WriteLine("Appointment ID: " + appointment.appointmentID);
                Console.WriteLine("From " + appointment.startTime + " to " + appointment.endTime);
                Console.WriteLine();
            }
        }
        public void PrintCompletedSchedule()
        {
            Console.WriteLine(name + "'s Completed Schedule");
            foreach (CompletedAppointment appointment in completedSchedule)
            {
                Console.WriteLine();
                Console.WriteLine(appointment.patientIdentifier.name);
                Console.WriteLine("Was seen from " + appointment.startTime + " to " + appointment.endTime);
            }
            Console.WriteLine();
        }
        public void RemovePreviousAppointment(CompletedAppointment Appointment)
        {
            foreach (Appointment appointment in schedule)
            {
                if (appointment.appointmentID == Appointment.appointmentID)
                {
                    schedule.Remove(appointment);
                    break;
                }
            }
        }
    }
}
