using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            int numberOfStudents = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberOfStudents; i++)
            {
                string studentName = Console.ReadLine();
                double studentGrade = double.Parse(Console.ReadLine());

                if (students.ContainsKey(studentName))
                {
                    students[studentName].Add(studentGrade);
                }
                else
                {
                    students.Add(studentName, new List<double>() {studentGrade});
                }
            }

            foreach (var keyValuePair in students
                .Where(x=>x.Value.Average() >= 4.5)
                .OrderByDescending(x=>x.Value.Average()))
            {
                Console.WriteLine($"{keyValuePair.Key} -> {keyValuePair.Value.Average():F2}");
            }
        }
    }
}
