using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TherapyTracker.Test
{
    [TestClass]
    public class TimeTest
    {
        public DateTime start = new DateTime(2016,3,28,7,0,0);
        public DateTime end = new DateTime(2016, 3, 28, 8, 0, 0);
        public Time timeTest;

        public TimeTest()
        {
            timeTest = new Time(start, end);
        }
        [TestMethod]
        public void TestSubtractTime()
        {
            //Arrange
            TimeSpan timeDiff = end - start;
            double target = timeDiff.TotalMinutes;
            double toTest;
            //Act
                toTest = timeTest.subtractTimeDifferenceMinutes();
            //Assert
            Assert.AreEqual(target, toTest);
        }
        //public void TestSubtractTimeWrongStartEndOrder()
        //{
        //    //Arrange
        //    DateTime newStartTime = new DateTime(2016, 3, 28, 8, 0, 0);
        //    DateTime newEndTime = new DateTime(2016, 3, 28, 7, 0, 0);
        //    timeTest.startTime = newStartTime;
        //    timeTest.endTime = newEndTime;
        //    //Act
        //    timeTest.subtractTimeDifferenceMinutes();
        //    //Assert
        //}
    }
}
