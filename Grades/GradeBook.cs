using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook
    {
        private List<float> grades;
        private string _name;
        public event NameChangedDelegate ncd;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("Name cannot be null or empty");

                //if (!String.IsNullOrEmpty(value))
                //{
                if (_name != value && ncd != null)
                {
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.existingName = _name;
                    args.newName = value;
                    ncd(this, args);
                    _name = value;
                }
                //}
            }
        }

        public void WriteGrades(TextWriter destination)
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

        public void AddGrade(float g)
        {
            grades.Add(g);
        }

        public Statistics GetStatistics()
        {
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
