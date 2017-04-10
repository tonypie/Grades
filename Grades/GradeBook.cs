using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook : GradeTracker
    {
        //Had to change for ThrowAwayGradeBook to be able to have access
        //private List<float> grades;
        
        //Moved to abstract class GradeTracker
        //protected List<float> grades;
        //private string _name;
        //public event NameChangedDelegate ncd;

        public override void WriteGrades(TextWriter destination)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                destination.WriteLine(grades[i]);
            }
        }

        public GradeBook()
        {
            grades = new List<float>();
            _name = "Empty";
        }

        public override void AddGrade(float g)
        {
            grades.Add(g);
        }

        public override Statistics GetStatistics()
        {
            Console.WriteLine("GradeBook::ComputeStatistics");
            Statistics s = new Statistics();

            foreach (float f in grades)
            {
                s.Max = Math.Max(s.Max, f);
                s.Min = Math.Min(s.Min, f);
                s.Average += f;
            }

            s.Average = s.Average / grades.Count;

            return s;
        }
    }
}
