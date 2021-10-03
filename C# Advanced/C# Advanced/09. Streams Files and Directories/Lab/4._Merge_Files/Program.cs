using System;
using System.IO;

namespace _4._Merge_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstFile = Path.Combine("data", "input1.txt");
            using StreamReader sr1 = new StreamReader(firstFile);
            string secondFile = Path.Combine("data", "input2.txt");
            using StreamReader sr2 = new StreamReader(secondFile);
            string outputFile = Path.Combine("data", "output.txt");
            using StreamWriter sw = new StreamWriter(outputFile);

            string input1;
            string input2;
            while (((input1 = sr1.ReadLine()) != null) && 
                   ((input2 = sr2.ReadLine()) != null))
            {
                if (input1 != null)
                {
                   sw.WriteLine(input1); 
                }
                if (input2 != null)
                {
                   sw.WriteLine(input2); 
                }
            }
        }
    }
}