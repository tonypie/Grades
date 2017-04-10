using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Test.Types
{
    [TestClass]
    public class ReferenceTypeTests
    {
        [TestMethod]
        public void IntVariablesHoldValue()
        {
            int x1 = 100;
            int x2 = x1;

            //x1 = 4;
            Assert.AreEqual(x1, x2);
        }

        [TestMethod]
        public void StringVariablesHoldValue()
        {
            string s1 = "test";
            string s2 = s1;

            //s1 = "testing";
            Assert.AreEqual(s1, s2);
        }

        [TestMethod]
        public void VariablesHoldReference()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1.Name = "Tony's grade book";

            Assert.AreEqual(g1.Name, g2.Name);
        }

        [TestMethod]
        public void VariablesHoldReferenceTest()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            //g1 = new GradeBook();
            g1.Name = "Tony's grade book";

            Assert.AreEqual(g1.Name, g2.Name);
        }

        [TestMethod]
        public void ReferenceTypePassByValue()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            GiveBookAName(g2);

            Assert.AreEqual("Grade book", g2.Name);
        }

        [TestMethod]
        private void GiveBookAName(GradeBook gb)
        {
            //Will fail as new object is created and that name is set
            //gb = new GradeBook();
            gb.Name = "Grade book";
        }

        [TestMethod]
        public void ValueTypePassByValue()
        {
            int a = 45;
            int b = a;

            IncrementNumber(a);

            Assert.AreEqual(45, a);
        }

        [TestMethod]
        private void IncrementNumber(int i)
        {
            i += 1;
        }

        [TestMethod]
        public void ValueTypePassByRef()
        {
            int a = 45;
            int b = a;

            IncrementNumber(ref a);

            Assert.AreEqual(46, a);
        }

        [TestMethod]
        private void IncrementNumber(ref int i)
        {
            i += 1;
        }

        [TestMethod]
        public void UsingArrays()
        {
            float[] grades;
            grades = new float[3];

            AddGrades(grades);

            Assert.AreEqual(89.4f, grades[1]);
        }

        private void AddGrades(float[] grades)
        {
            //Will fail as new grades object is created and the previously referenced object is not updated
            //grades = new float[5];
            grades[1] = 89.4f;
        }

    }
}
