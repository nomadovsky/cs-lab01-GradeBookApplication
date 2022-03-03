using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {

            if (Students.Count < 5) throw new InvalidOperationException("Must be at least 5 students");
            var top20percent = (int)( Students.Count * 0.2);
            var orderedStudents = Students.OrderByDescending(e => e.AverageGrade);
            var grades = orderedStudents.Select(e => e.AverageGrade).ToArray();

            if (averageGrade >= grades[top20percent-1])
                return 'A';
            else if (averageGrade >= grades[top20percent*2 - 1])
                return 'B';
            else if (averageGrade >= grades[top20percent*3 - 1])
                return 'C';
            else if (averageGrade >= grades[top20percent*4 - 1])
                return 'D';
            else
                return 'F';

        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5) Console.WriteLine("Ranked Grading requires at least 5 students.");
            else base.CalculateStatistics();
        }
    }
}
