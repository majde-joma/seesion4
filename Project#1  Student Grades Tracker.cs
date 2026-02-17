using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Define an enum for grade levels
enum GradeLevel { Freshman, Sophomore, Junior, Senior }

class Program
{
    static void Main()
    {
        // 1. Store student names in a list (max 5 students)
        List<string> studentNames = new List<string> { "Alice", "Bob", "Charlie", "Diana", "Ethan" };

        // 2. Use a dictionary to map names to a list of grades
        Dictionary<string, List<int>> studentGrades = new Dictionary<string, List<int>>();
        Random rand = new Random();

        foreach (var name in studentNames)
        {
            // Assigning 3 random grades between 0 and 100 for each student
            studentGrades[name] = new List<int> { rand.Next(0, 101), rand.Next(0, 101), rand.Next(0, 101) };
        }

        // 3. Generate a formatted report using StringBuilder
        StringBuilder report = new StringBuilder();
        report.AppendLine("------------------------------------------------------------");
        report.AppendLine(string.Format("{0,-10} | {1,-15} | {2,-10} | {3,-10}", "Name", "Avg Grade", "Level", "Grades"));
        report.AppendLine("------------------------------------------------------------");

        foreach (var student in studentGrades)
        {
            // Calculate average
            double average = student.Value.Average();

            // 4. Assign grade level based on average rules
            GradeLevel level;
            if (average < 20) level = GradeLevel.Freshman;
            else if (average < 40) level = GradeLevel.Sophomore;
            else if (average < 60) level = GradeLevel.Junior;
            else level = GradeLevel.Senior;

            string gradesStr = string.Join(", ", student.Value);
            report.AppendLine(string.Format("{0,-10} | {1,-15:F2} | {2,-10} | {3,-10}", student.Key, average, level, gradesStr));
        }

        // 5. Display the final report
        Console.WriteLine(report.ToString());
    }
}
