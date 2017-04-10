using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Grades;

namespace Grades.Test
{
    [TestClass]
    public class GradeBookTests
    {
        [TestMethod]
        public void ComputeHighestGrade()
        {
            GradeBook gb = new GradeBook();
            gb.AddGrade(91);
            gb.AddGrade(85.2f);
            gb.AddGrade(75);

            Statistics s = gb.GetStatistics();

            Assert.AreEqual(s.Max, 91);
        }

        [TestMethod]
        public void ComputeLowestGrade()
        {
            GradeBook gb = new GradeBook();
            gb.AddGrade(91);
            gb.AddGrade(85.2f);
            gb.AddGrade(75);

            Statistics s = gb.GetStatistics();

            Assert.AreEqual(s.Min, 75);
        }

        [TestMethod]
        public void ComputeAverageGrade()
        {
            GradeBook gb = new GradeBook();
            gb.AddGrade(91);
            gb.AddGrade(85.2f);
            gb.AddGrade(75);

            Statistics s = gb.GetStatistics();

            Assert.AreEqual(s.Average, 83.73333, 0.01);
        }
    }
}
