using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                string[] student = Console.ReadLine().Split();
                string name = student[0];
                decimal grade = decimal.Parse(student[1]);

                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<decimal>());
                }
                students[name].Add(grade);
            }

            foreach (var kVP in students)
            {
                Console.WriteLine($"{kVP.Key} -> {string.Join(' ', kVP.Value.Select(x=> $"{x:F2}"))} (avg: {kVP.Value.Average():F2})");
            }
        }
    }
}
