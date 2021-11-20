using System;

namespace _06._Valid_Person
{
    class Program
    {
        static void Main(string[] args)
        {
            Person firstPerson = new Person("Peter", "Johnson", 24);

            //Invalid First Name
            try
            {
                Person personWithoutFirstName = new Person(string.Empty, "Peterson", 31);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}");
            }

            //Invalid Last Name
            try
            {
                Person personWithoutLastName = new Person("Jordon", string.Empty, 25);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}");
            }

            //Invalid Age - negative number
            try
            {
                Person personWithNegativeAge = new Person("Peter", "Miller", -1);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}");
            }

            //Invalid Age - out of range
            try
            {
                Person personWithTooBigAge = new Person("Sam", "Bundy", 122);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}");
            }
        }
    }
}