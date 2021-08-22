using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] info = input.Split(" : ");
                string courseName = info[0];
                string studentName = info[1];

                if (courses.ContainsKey(courseName))
                {
                    courses[courseName].Add(studentName);
                }
                else
                {
                    courses.Add(courseName, new List<string>() {studentName});
                }


                input = Console.ReadLine();
            }

            foreach (var keyValuePair in courses.OrderByDescending(x=>x.Value.Count))
            {
                Console.WriteLine($"{keyValuePair.Key}: {keyValuePair.Value.Count}");
                foreach (var s in keyValuePair.Value.OrderBy(x=>x))
                {
                    Console.WriteLine($"-- {s}");
                }
            }
        }
    }
}
