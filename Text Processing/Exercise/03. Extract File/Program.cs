using System;

namespace _03._Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split('\\');
            string[] filename = input[input.Length - 1].Split('.');
            Console.WriteLine($"File name: {filename[0]}");
            Console.WriteLine($"File extension: {filename[1]}");
        }
    }
}
