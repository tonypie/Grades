using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class ThrowAwayGradeBook : GradeBook
    {
        public override Statistics GetStatistics()
        {
            Console.WriteLine("ThrowAwayGradeBook::ComputeStatistics");
            float lowest = float.MaxValue;

            foreach (int grade in base.grades)
            {
                
                lowest = Math.Min(lowest, grade);
            }

            base.grades.Remove(lowest);

            return base.GetStatistics();
        }
    }
}
