using System;

namespace _01._Encrypt_Sort_and_Print_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[] outputs = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                string input = Console.ReadLine();
                int length = input.Length;
                int output = 0;

                foreach (var ch in input)
                {
                    if (ch == 'A' || ch == 'E' || ch == 'I' || ch == 'O' || ch == 'U' || ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
                        output += ch * length;
                    else
                        output += ch / length;
                }

                outputs[i] = output;
            }

            Array.Sort(outputs);
            foreach (var item in outputs)
            {
                Console.WriteLine(item);
            }
        }
    }
}
