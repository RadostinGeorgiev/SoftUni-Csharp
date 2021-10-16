using System;
using System.Linq;

namespace _01.ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ListyIterator<string> listy = null;

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] command = input.Split();

                switch (command[0])
                {
                    case "Create":
                        listy = new ListyIterator<string>(command.Skip(1).ToArray());
                        break;

                    case "Print":
                        listy.Print();
                        break;

                    case "HasNext":
                        Console.WriteLine(listy.HasNext());
                        break;

                    case "Move":
                        Console.WriteLine(listy.Move());
                        break;
                }
            }
        }
    }
}