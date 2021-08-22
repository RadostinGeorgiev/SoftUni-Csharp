using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Company_Roster
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberEmployees = int.Parse(Console.ReadLine());
            List<Employee> employees = new List<Employee>();

            for (int i = 1; i <= numberEmployees; i++)
            {
                string[] info = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                Employee employee = new Employee(info[0], decimal.Parse(info[1]), info[2]);
                employees.Add(employee);
            }

            List<string> departments = new List<string>();
            foreach (var item in employees)
            {
                if (!departments.Contains(item.Department))
                {
                    departments.Add(item.Department);
                }
            }

            decimal maxAverige = 0;
            string bestDepartment = string.Empty;
            foreach (var item in departments)
            {
                decimal currentAverage = employees.Where(x => x.Department == item).Average(x => x.Salary);
                if (currentAverage > maxAverige)
                {
                    maxAverige = currentAverage;
                    bestDepartment = item;
                }
            }

            Console.WriteLine($"Highest Average Salary: {bestDepartment}");
            Console.WriteLine(string.Join(Environment.NewLine, employees.Where(x=>x.Department == bestDepartment).OrderByDescending(X=>X.Salary)));
        }
    }

    class Employee
    {
        public Employee(string name, decimal salary, string department)
        {
            Name = name;
            Salary = salary;
            Department = department;
        }

        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Department { get; set; }

        public override string ToString()
        {
            return $"{Name} {Salary:f2}";
        }
    }
}
