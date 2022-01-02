namespace _02._Nested_Loops
{
    using System;

    class Program
    {
        private static int[] vectors;
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            vectors = new int[number];

            GetVectors(0);
        }

        private static void GetVectors(int index)
        {
            if (index == vectors.Length)
            {
                Console.WriteLine(string.Join(' ', vectors));
                return;
            }

            for (int i = 1; i <= vectors.Length; i++)
            {
                vectors[index] = i;
                GetVectors(index + 1);
            }
        }
    }
}