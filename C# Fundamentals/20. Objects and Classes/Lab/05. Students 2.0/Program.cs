using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Students_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] currentStudent = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                int index = students.FindIndex(x => x.FirstName == currentStudent[0] && x.LastName == currentStudent[1]);
                if (index >= 0)
                {
                    students[index].Age = int.Parse(currentStudent[2]);
                    students[index].HomeTown = currentStudent[3];
                }
                else
                {
                    Student student = new Student(currentStudent[0], currentStudent[1], int.Parse(currentStudent[2]),
                        currentStudent[3]);
                    students.Add(student);
                }

                input = Console.ReadLine();
            }

            string searchedCity = Console.ReadLine();

            foreach (var student in students)
            {
                if (student.HomeTown == searchedCity)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }

        class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string HomeTown { get; set; }

            public Student(string firstName, string lastName, int age, string hometown)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
                this.Age = age;
                this.HomeTown = hometown;
            }
        }
    }
}
