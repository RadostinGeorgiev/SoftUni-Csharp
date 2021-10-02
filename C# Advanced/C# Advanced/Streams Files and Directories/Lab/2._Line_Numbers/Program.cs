using System.IO;

namespace _2._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = Path.Combine("data", "input.txt");
            using StreamReader sr = new StreamReader(inputFile);
            var outputFile = Path.Combine("data", "output.txt");
            using StreamWriter sw = new StreamWriter(outputFile);
            int lineCounter = 1;

            string input;
            while ((input = sr.ReadLine()) != null)
            {
                sw.WriteLine($"{lineCounter}. {input}");
                lineCounter++;
            }
        }
    }
}
