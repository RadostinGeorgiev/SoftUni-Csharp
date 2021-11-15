using System;

namespace _02._Enter_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = 1;
            for (int i = 1; i <= 10; i++)
            {
                try
                {
                    start = Readers.ReadNumber(start, 100);
                }
                catch (Exception ex)
                {
                    i = 0;
                    start = 1;
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}