using System;
using Grades;
using System.Speech.Synthesis;

namespace Grades
{
    class Program
    {
        public static void Main(string[] args)
        {
            SpeechSynthesizer ss = new SpeechSynthesizer();
            ss.Speak("Hello! This is the grade book program!");

            GradeBook gb1 = new GradeBook();

            //gb1.ncd += new NameChangedDelegate(NameChanged);
            //Don't have to have new NameChangedDelegate
            //gb1.ncd += NameChanged2;
            //gb1.ncd += NameChanged2;
            //gb1.ncd -= NameChanged2;

            gb1.AddGrade(91);
            gb1.AddGrade(85.2f);
            gb1.AddGrade(75);
            gb1.WriteGrades(Console.Out);

            try
            {
                Console.WriteLine("Enter a name:");
                gb1.Name = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            //catch (NullReferenceException ex)
            //{
            //    Console.WriteLine("Something went wrong");
            //}
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong");
            }

            Statistics s = gb1.GetStatistics();

            Console.WriteLine("Highest Grade = {0}, Lowest Grade = {1}, and your average grade is {2}", s.Max, s.Min, s.Average);
        }

        public static void NameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"1st subscriber : Name changed from {args.existingName} to {args.newName}!");
        }

        public static void NameChanged2(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"2nd subscriber : Name changed from {args.existingName} to {args.newName}!");
        }
    }
}
