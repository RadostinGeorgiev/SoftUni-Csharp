using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> students = new Dictionary<string, int>();
            Dictionary<string, int> languages = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "exam finished")
            {
                string[] info = input
                    .Split('-', StringSplitOptions.RemoveEmptyEntries);
                string username = info[0];
                string language = info[1];

                if (language != "banned")
                {
                    int points = int.Parse(info[2]);
                    if (students.ContainsKey(username))
                    {
                        if (students[username] < points)
                        {
                            students[username] = points;
                        }
                    }
                    else
                    {
                        students.Add(username, points);
                    }

                    if (languages.ContainsKey(language))
                    {
                        languages[language]++;
                    }
                    else
                    {
                        languages.Add(language, 1);
                    }
                }
                else
                {
                    students.Remove(username);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Results:");
            foreach (var keyValuePair in students
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{keyValuePair.Key} | {keyValuePair.Value}");
            }

            Console.WriteLine("Submissions:");
            foreach (var keyValuePair in languages
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{keyValuePair.Key} - {keyValuePair.Value}");
            }
        }
    }
}
