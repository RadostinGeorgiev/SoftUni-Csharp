using System;

namespace _05._Convert.ToDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Console.WriteLine(System.Convert.ToDouble('m'));
                //Console.WriteLine(System.Convert.ToDouble("123456789"));
                //Console.WriteLine(System.Convert.ToDouble("12345.6789"));
                //Console.WriteLine(System.Convert.ToDouble("123,456,789"));

                string input = Console.ReadLine();
                Console.WriteLine(Convert.ToDouble(input));
            }
            catch (InvalidCastException ice)
            {
                Console.Write("Exception Thrown: {0}: {1}", ice.GetType(), ice.Message);
                throw;
            }
            catch (FormatException fe)
            {
                Console.Write("Exception Thrown: {0}: {1}", fe.GetType(), fe.Message);
                throw;
            }
            catch (OverflowException oe)
            {
                Console.Write("Exception Thrown: {0}: {1}", oe.GetType(), oe.Message);
                throw;
            }
        }
    }
}