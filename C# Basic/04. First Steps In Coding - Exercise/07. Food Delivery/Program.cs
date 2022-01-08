namespace FoodDelivery
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            const double chickenPrice = 10.35;
            const double fishPrice = 12.40;
            const double vegetarianPrice = 8.15;
            const double supplyPrice = 2.50;

            int chicken = int.Parse(Console.ReadLine());
            int fish = int.Parse(Console.ReadLine());
            int vegetarian = int.Parse(Console.ReadLine());

            double orderPrice = chicken * chickenPrice + fish * fishPrice + vegetarian * vegetarianPrice;
            double dessertPrice = orderPrice * 0.2;
            orderPrice += dessertPrice + supplyPrice; 

            Console.WriteLine($"{orderPrice}");
        }
    }
}