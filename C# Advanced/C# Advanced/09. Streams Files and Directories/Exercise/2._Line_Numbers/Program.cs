using System;
using System.IO;
using System.Threading.Tasks;

namespace _2._Line_Numbers
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var path = Path.Combine("data", "text.txt");

            string[] lines = await File.ReadAllLinesAsync(path);

            for (var i = 0; i < lines.Length; i++)
            {
                int letterCounter = 0;
                int punctuationCounter = 0;

                foreach (var c in lines[i].ToCharArray())
                {
                    if (char.IsLetter(c))
                    {
                        letterCounter++;
                    }
                    else if (char.IsPunctuation(c))
                    {
                        punctuationCounter++;
                    }
                }
                
                path = Path.Combine("data", "output.txt");
                await File.AppendAllTextAsync(path, $"Line {i+1}:{lines[i]} ({letterCounter})({punctuationCounter}){Environment.NewLine}");
            }
        }
    }
}