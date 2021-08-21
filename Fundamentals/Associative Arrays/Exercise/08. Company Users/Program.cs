using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<string>> companies = new SortedDictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] info = input.Split(" -> ");
                string companyName = info[0];
                string employeeID = info[1];

                if (companies.ContainsKey(companyName))
                {
                    if (!companies[companyName].Contains(employeeID))
                    {
                        companies[companyName].Add(employeeID);
                    }
                }
                else
                {
                    companies.Add(companyName, new List<string>() {employeeID});
                }
                
                input = Console.ReadLine();
            }

            foreach (var keyValuePair in companies)
            {
                Console.WriteLine(keyValuePair.Key);
                foreach (var companiesValue in keyValuePair.Value)
                {
                    Console.WriteLine($"-- {companiesValue}");
                }
            }
        }
    }
}
