using System;
using System.IO;

namespace _5._Slice_a_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = Path.Combine("data", "input.txt");
            using FileStream fs = new FileStream(inputFile, FileMode.Open);

            int newFilesLength = (int)Math.Ceiling(fs.Length / 4.0);
            for (int i = 1; i <= 4; i++)
            {
                byte[] buffer = new byte[newFilesLength];
                fs.Read(buffer, 0, buffer.Length);

                string outputFile = Path.Combine("data", $"Part-{i}.txt");
                using FileStream fw = new FileStream(outputFile, FileMode.OpenOrCreate);
                fw.Write(buffer);
            }
        }
    }
}