using System;

namespace _02._Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            int period = int.Parse(Console.ReadLine());
            int doctors = 7;

            int treatedPatients = 0;
            int untreatedPatients = 0;

            for (int i = 1; i <= period; i++)
            {
                int patientsInCurrentDay = int.Parse(Console.ReadLine());

                if ((i % 3 == 0) && (untreatedPatients > treatedPatients))
                    doctors++;

                if (doctors <= patientsInCurrentDay)
                {
                    treatedPatients += doctors;
                    untreatedPatients += patientsInCurrentDay - doctors;
                }
                else
                {
                    treatedPatients += patientsInCurrentDay;
                }
            }

            Console.WriteLine($"Treated patients: {treatedPatients}.");
            Console.WriteLine($"Untreated patients: {untreatedPatients}.");
        }
    }
}