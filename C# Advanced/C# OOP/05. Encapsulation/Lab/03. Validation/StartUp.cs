using System;
using System.Collections.Generic;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();
            for (int i = 0; i < lines; i++)
            {
                try
                {
                    var cmdArgs = Console.ReadLine().Split();
                    var firstName = cmdArgs[0];
                    var lastName = cmdArgs[1];
                    var age = int.Parse(cmdArgs[2]);
                    var salary = decimal.Parse(cmdArgs[3]);

                    var person = new Person(firstName, lastName, age, salary);
                    persons.Add(person);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            var percentage = decimal.Parse(Console.ReadLine());
            persons.ForEach(p => p.IncreaseSalary(percentage));
            persons.ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}