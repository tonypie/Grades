using System.IO;

namespace Grades
{
    internal interface IGradeTracker
    {
        string Name { get; set; }

        void AddGrade(float grade);

        void WriteGrades(TextWriter destination);

        Statistics GetStatistics();
    }
}