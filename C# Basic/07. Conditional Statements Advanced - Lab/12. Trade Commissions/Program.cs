using System;

namespace _12._Trade_Commissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());

            switch (city)
            {
                case "Sofia":
                    if (sales >= 0 && sales <= 500)
                        Console.WriteLine($"{sales * 0.05:f2}");
                    else if (sales <= 1000)
                        Console.WriteLine($"{sales * 0.07:f2}");
                    else if (sales <= 10000)
                        Console.WriteLine($"{sales * 0.08:f2}");
                    else if (sales > 10000)
                        Console.WriteLine($"{sales * 0.12:f2}");
                    else
                        Console.WriteLine("error");
                    break;
                case "Varna":
                    if (sales >= 0 && sales <= 500)
                        Console.WriteLine($"{sales * 0.045:f2}");
                    else if (sales <= 1000)
                        Console.WriteLine($"{sales * 0.075:f2}");
                    else if (sales <= 10000)
                        Console.WriteLine($"{sales * 0.10:f2}");
                    else if (sales > 10000)
                        Console.WriteLine($"{sales * 0.13:f2}");
                    else
                        Console.WriteLine("error");
                    break;
                case "Plovdiv":
                    if (sales >= 0 && sales <= 500)
                        Console.WriteLine($"{sales * 0.055:f2}");
                    else if (sales <= 1000)
                        Console.WriteLine($"{sales * 0.08:f2}");
                    else if (sales <= 10000)
                        Console.WriteLine($"{sales * 0.12:f2}");
                    else if (sales > 10000)
                        Console.WriteLine($"{sales * 0.145:f2}");
                    else
                        Console.WriteLine("error");
                    break;

                default:
                    Console.WriteLine("error");
                    break;
            }
        }
    }
}
