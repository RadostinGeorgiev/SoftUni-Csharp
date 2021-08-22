using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Students
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
                Student student = new Student(currentStudent[0], currentStudent[1], int.Parse(currentStudent[2]),
                    currentStudent[3]);
                students.Add(student);

                input = Console.ReadLine();
            }

            string searchedCity = Console.ReadLine();

            Console.WriteLine(string.Join(Environment.NewLine, students.Where(s => s.HomeTown == searchedCity)));
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

        public override string ToString()
        {
            return $"{FirstName} {LastName} is {Age} years old.";
        }
    }

}
