using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Avg_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> studentAndGrades = new Dictionary<string, List<double>>();

            for (int i = 0; i < studentsCount; i++)
            {
                string[] nameAndGrade = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = nameAndGrade[0];
                double grade = double.Parse(nameAndGrade[1]);

                if (!studentAndGrades.ContainsKey(name))
                {
                    studentAndGrades.Add(name, new List<double>());
                }
                studentAndGrades[name].Add(grade);
            }

            foreach (var student in studentAndGrades)
            {
                Console.WriteLine($"{student.Key} -> {string.Join(" ", student.Value.Select(g => g.ToString("0.00")))} (avg: {student.Value.Average():f2})");
            }
        }
    }
}
