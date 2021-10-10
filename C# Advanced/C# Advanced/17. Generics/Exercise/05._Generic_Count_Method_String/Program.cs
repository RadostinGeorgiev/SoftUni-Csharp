using System;

namespace GenericBox
{
    public class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            var data = new Box<string>();
            for (int i = 0; i < lines; i++)
            {
                data.Add(Console.ReadLine());
            }
           
            string comparedItem = Console.ReadLine();
            Console.WriteLine(data.Compare(comparedItem));
        }
    }
}