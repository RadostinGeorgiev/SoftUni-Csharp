using System.IO;

namespace _1._Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = Path.Combine("data", "input.txt");
            using StreamReader sr = new StreamReader(inputFile);
            var outputFile = Path.Combine("data", "output.txt");
            using StreamWriter sw = new StreamWriter(outputFile);
            int lineCounter = 0;

            string input;
            while ((input = sr.ReadLine()) != null)
            {
                if (lineCounter % 2 != 0)
                {
                    sw.WriteLine(input);
                }

                lineCounter++;
            }
        }
    }
}