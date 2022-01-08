namespace _07._Trekking_Mania
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int groups = int.Parse(Console.ReadLine());

            int peoplesMusala = 0;
            int peoplesMontBlanc = 0;
            int peoplesKilimanjaro = 0;
            int peoplesK2 = 0;
            int peoplesEverest = 0;
            double totalPeoples = 0;

            for (int i = 0; i < groups; i++)
            {
                int peoples = int.Parse(Console.ReadLine());

                if (peoples <= 5)
                {
                    peoplesMusala += peoples;
                }
                else if (peoples <= 12)
                {
                    peoplesMontBlanc += peoples;
                }
                else if (peoples <= 25)
                {
                    peoplesKilimanjaro += peoples;
                }
                else if (peoples <= 40)
                {
                    peoplesK2 += peoples;
                }
                else 
                {
                    peoplesEverest += peoples;
                }

                totalPeoples += peoples;
            }

            Console.WriteLine($"{peoplesMusala / totalPeoples * 100.0:F2}%");
            Console.WriteLine($"{peoplesMontBlanc / totalPeoples * 100.0:F2}%");
            Console.WriteLine($"{peoplesKilimanjaro / totalPeoples * 100.0:F2}%");
            Console.WriteLine($"{peoplesK2 / totalPeoples * 100.0:F2}%");
            Console.WriteLine($"{peoplesEverest / totalPeoples * 100.0:F2}%");
        }
    }
}