using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> schedule = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();

            while (input != "course start")
            {
                string[] commands = input
                    .Split(':', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string command = commands[0];
                string lessonTitle = commands[1];
                int indexLessonTitle = 0;
                int indexLessonTitle2 = 0;
                string lessonTitle2 = string.Empty;

                switch (command)
                {
                    case "Add":
                        if (!schedule.Contains(lessonTitle))
                        {
                            schedule.Add(lessonTitle);
                        }
                        break;
                    case "Insert":
                        if (!schedule.Contains(lessonTitle))
                        {
                            int index = int.Parse(commands[2]);
                            schedule.Insert(index, lessonTitle);
                        }
                        break;
                    case "Remove":
                        if (schedule.Contains(lessonTitle))
                        {
                            schedule.Remove(lessonTitle);
                            lessonTitle2 = lessonTitle + "-Exercise";
                            if (schedule.Contains(lessonTitle2))
                            {
                                schedule.Remove(lessonTitle2);
                            }
                        }
                        break;
                    case "Swap":
                        indexLessonTitle = schedule.IndexOf(lessonTitle);
                        lessonTitle2 = commands[2];
                        indexLessonTitle2 = schedule.IndexOf(lessonTitle2);

                        if (indexLessonTitle > -1 && indexLessonTitle2 > -1)
                        {
                            schedule[indexLessonTitle] = lessonTitle2;
                            schedule[indexLessonTitle2] = lessonTitle;

                            if (schedule.Contains(lessonTitle + "-Exercise"))
                            {
                                schedule.Insert(indexLessonTitle2 + 1, lessonTitle + "-Exercise");
                                schedule.RemoveAt(indexLessonTitle + 1);
                            }
                            if (schedule.Contains(lessonTitle2 + "-Exercise"))
                            {
                                schedule.Insert(indexLessonTitle + 1, lessonTitle2 + "-Exercise");
                                schedule.RemoveAt(indexLessonTitle2 + 2);
                            }
                        }
                        break;
                    case "Exercise":
                        indexLessonTitle = schedule.IndexOf(lessonTitle);
                        lessonTitle2 = lessonTitle + "-Exercise";
                        indexLessonTitle2 = indexLessonTitle + 1;
                        if (indexLessonTitle > -1)
                        {
                            if (!schedule.Contains(lessonTitle2))
                            {
                                schedule.Insert(indexLessonTitle2, lessonTitle2);
                            }
                        }
                        else
                        {
                            schedule.Add(lessonTitle);
                            schedule.Add(lessonTitle2);
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            for (int i = 0; i < schedule.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{schedule[i]}");
            }
        }
    }
}
