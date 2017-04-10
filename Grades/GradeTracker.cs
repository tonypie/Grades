using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public abstract class GradeTracker : IGradeTracker
    {
        protected List<float> grades;
        protected string _name;
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

        public abstract void AddGrade(float grade);

        public abstract void WriteGrades(TextWriter destination);

        public abstract Statistics GetStatistics();
    }
}
