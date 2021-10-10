using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var scale = new EqualityScale<int>('a', 'c');
            Console.WriteLine(scale.AreEqual());
        }
    }
}