using System;
using System.Data;
using System.Linq;

namespace _02._Array_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                int index1 = 0;
                int index2 = 0;

                switch (command[0])
                {
                    case "swap":
                        index1 = int.Parse(command[1]);
                        index2 = int.Parse(command[2]);
                        int temp = numbers[index1];
                        numbers[index1] = numbers[index2];
                        numbers[index2] = temp;
                        break;
                    case "multiply":
                        index1 = int.Parse(command[1]);
                        index2 = int.Parse(command[2]);
                        numbers[index1] *= numbers[index2];
                        break;
                    case "decrease":
                        for (int i = 0; i < numbers.Length; i++)
                        {
                            numbers[i]--;
                        }
                        break;
                }
                
                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
