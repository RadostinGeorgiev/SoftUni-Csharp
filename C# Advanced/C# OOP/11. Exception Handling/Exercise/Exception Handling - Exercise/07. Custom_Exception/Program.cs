using System;

namespace _07._Custom_Exception
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Student student = new Student("", "student@abv.bg");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
