using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split();
            string[] sites = Console.ReadLine().Split();
            StationaryPhone phone = new StationaryPhone();
            SmartPhone smart = new SmartPhone();

            foreach (var phoneNumber in phoneNumbers)
            {

                try
                {
                    if (phoneNumber.Length == 10)
                    {
                        smart.Call(phoneNumber);
                    }
                    else
                    {
                        phone.Call(phoneNumber);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var site in sites)
            {
                try
                {
                    smart.Browse(site);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}