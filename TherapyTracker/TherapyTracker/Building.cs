using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This entire class is used to pre-populate a building
namespace TherapyTracker
{
    public class Building
    {
        //Creating Staff
        public Therapist speechTherapist = new Therapist("John", Therapist.Discipline.speechTherapist);
        public Therapist physicalTherapist = new Therapist("Bob", Therapist.Discipline.physicalTherapist);
        public Therapist occupationalTherapist = new Therapist("Roger", Therapist.Discipline.occupationalTherapist);

        //Creating Patients
        public Patient one = new Patient("Mary", 1234);
        public Patient two = new Patient("Henry", 1235);
        public Patient three = new Patient("Sally", 1236);
        public Patient four = new Patient("Warren", 1237);
        public Patient five = new Patient("Randy", 1238);
        public Patient six = new Patient("Cletus", 1239);
        public Patient seven = new Patient("Robert", 1240);
        public Patient eight = new Patient("Barbara", 1241);

        //Creating DateTimes for Times
        public  DateTime start1 = new DateTime(2016, 3, 25, 6, 0, 0);
        public static DateTime end1 = new DateTime(2016, 3, 25, 6, 30, 0);
        public static DateTime start2 = new DateTime(2016, 3, 25, 7, 0, 0);
        public static DateTime end2 = new DateTime(2016, 3, 25, 7, 30, 0);
        public static DateTime start3 = new DateTime(2016, 3, 25, 8, 0, 0);
        public static DateTime end3 = new DateTime(2016, 3, 25, 8, 30, 0);
        public static DateTime start4 = new DateTime(2016, 3, 25, 9, 0, 0);
        public static DateTime end4 = new DateTime(2016, 3, 25, 9, 30, 0);
        public static DateTime start5 = new DateTime(2016, 3, 25, 10, 0, 0);
        public static DateTime end5 = new DateTime(2016, 3, 25, 10, 30, 0);
        public static DateTime start6 = new DateTime(2016, 3, 25, 11, 0, 0);
        public static DateTime end6 = new DateTime(2016, 3, 25, 11, 30, 0);
        public static DateTime start7 = new DateTime(2016, 3, 25, 12, 0, 0);
        public static DateTime end7 = new DateTime(2016, 3, 25, 12, 30, 0);
        public static DateTime start8 = new DateTime(2016, 3, 25, 13, 0, 0);
        public static DateTime end8 = new DateTime(2016, 3, 25, 13, 30, 0);
        public static DateTime start9 = new DateTime(2016, 3, 25, 14, 0, 0);
        public static DateTime end9 = new DateTime(2016, 3, 25, 14, 30, 0);
        public static DateTime start10 = new DateTime(2016, 3, 25, 15, 0, 0);
        public static DateTime end10 = new DateTime(2016, 3, 25, 15, 30, 0);

        //Creating Times for Appointments
        public Time time1;
        public Time time2;
        public Time time3;
        public Time time4;
        public Time time5;
        public Time time6;
        public Time time7;
        public Time time8;
        public Time time9;
        public Time time10;

        //Creating Appointments for Schedules
        public Appointment appointment1;
        public Appointment appointment2;
        public Appointment appointment3;
        public Appointment appointment4;
        public Appointment appointment5;
        public Appointment appointment6;
        public Appointment appointment7;
        public Appointment appointment8;
        public Appointment appointment9;
        public Appointment appointment10;

        ////Creating Therapist's Schedules
        //public Schedule slpSchedule;
        //public Schedule ptSchedule;
        //public Schedule otSchedule;

        public Building()
        {
            time1 = new Time(start1, end1);
            time2 = new Time(start2, end2);
            time3 = new Time(start3, end3);
            time4 = new Time(start4, end4);
            time5 = new Time(start5, end5);
            time6 = new Time(start6, end6);
            time7 = new Time(start7, end7);
            time8 = new Time(start8, end8);
            time9 = new Time(start9, end9);
            time10 = new Time(start10, end10);

            appointment1 = new Appointment(start1, end1, one); 
            appointment2 = new Appointment(start2, end2, two); 
            appointment3 = new Appointment(start3, end3, three); 
            appointment4 = new Appointment(start4, end4, four); 
            appointment5 = new Appointment(start5, end5, five); 
            appointment6 = new Appointment(start6, end6, six); 
            appointment7 = new Appointment(start7, end7, seven); 
            appointment8 = new Appointment(start8, end8, eight); 
            appointment9 = new Appointment(start9, end9, seven); 
            appointment10 = new Appointment(start10, end10, eight); 
        }
        public void AddToTherapistList(Director Director)
        {
            Director.masterTherapistList.Add(speechTherapist);
            Director.masterTherapistList.Add(physicalTherapist);
            Director.masterTherapistList.Add(occupationalTherapist);
        }
        public void AddToPatientList (Director Director)
        {
            Director.masterPatientList.Add(one);
            Director.masterPatientList.Add(two);
            Director.masterPatientList.Add(three);
            Director.masterPatientList.Add(four);
            Director.masterPatientList.Add(five);
            Director.masterPatientList.Add(six);
            Director.masterPatientList.Add(seven);
            Director.masterPatientList.Add(eight);
        }
        public void AddAppointmentsToSchedule()
        {
            speechTherapist.schedule.Add(appointment1);
            speechTherapist.schedule.Add(appointment2);
            speechTherapist.schedule.Add(appointment3);
            physicalTherapist.schedule.Add(appointment4);
            physicalTherapist.schedule.Add(appointment5);
            physicalTherapist.schedule.Add(appointment6);
            physicalTherapist.schedule.Add(appointment7);
            occupationalTherapist.schedule.Add(appointment8);
            occupationalTherapist.schedule.Add(appointment9);
            occupationalTherapist.schedule.Add(appointment10);
        }
        public void AddToScheduleList(Director Director)
        {
            Director.masterSchedule.Add(speechTherapist.schedule);
            Director.masterSchedule.Add(occupationalTherapist.schedule);
            Director.masterSchedule.Add(physicalTherapist.schedule);
        }
    }
}
