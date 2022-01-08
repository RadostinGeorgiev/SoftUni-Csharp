namespace _02._Recursive_Drawing
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            DrawRecursively(n);
        }

        private static void DrawRecursively(int i)
        {
            if (i == 0)
            {
                return;
            }

            Console.WriteLine(new string('*', i));
            DrawRecursively(i-1);
            Console.WriteLine(new string('#', i));
        }
    }
}
