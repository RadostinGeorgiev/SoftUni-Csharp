using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            double price = 0.00;

            switch (typeOfGroup)
            {
                case "Students":
                    if (dayOfWeek == "Friday")
                    {
                        price = 8.45;
                    }
                    else if (dayOfWeek == "Saturday")
                    {
                        price = 9.80;
                    }
                    if (dayOfWeek == "Sunday")
                    {
                        price = 10.46;
                    }

                    if (numberOfPeople >= 30)
                    {
                        price -= price * 0.15;
                    }
                    break;
                case "Business":
                    if (dayOfWeek == "Friday")
                    {
                        price = 10.90;
                    }
                    else if (dayOfWeek == "Saturday")
                    {
                        price = 15.60;
                    }
                    if (dayOfWeek == "Sunday")
                    {
                        price = 16;
                    }


                    if (numberOfPeople >= 100)
                    {
                        numberOfPeople -= 10;
                    }
                    break;
                case "Regular":
                    if (dayOfWeek == "Friday")
                    {
                        price = 15;
                    }
                    else if (dayOfWeek == "Saturday")
                    {
                        price = 20;
                    }
                    if (dayOfWeek == "Sunday")
                    {
                        price = 22.5;
                    }

                    if (numberOfPeople >= 10 && numberOfPeople <= 20)
                    {
                        price -= price * 0.05;
                    }
                    break;
            }

            Console.WriteLine($"Total price: {price * numberOfPeople:f2}");
        }
    }
}
