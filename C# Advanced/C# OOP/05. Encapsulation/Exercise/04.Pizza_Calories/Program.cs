using System;

namespace _04.Pizza_Calories
{
    public class Program
    {
        static void Main(string[] args)
        {
            Pizza pizza = null;

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] items = input.Split();
                string element = items[0];
                try
                {
                    int weight;
                    switch (element)
                    {
                        case "Dough":
                            string flour = items[1];
                            string baking = items[2];
                            weight = int.Parse(items[3]);

                            pizza.Doughs = new Dough(flour, baking, weight);
                            break;

                        case "Topping":
                            string type = items[1];
                            weight = int.Parse(items[2]);

                            Topping topping = new Topping(type, weight);
                            pizza.AddTopping(topping);
                            break;

                        case "Pizza":
                            string name = items[1];

                            pizza = new Pizza(name);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            Console.WriteLine(pizza);
        }
    }
}