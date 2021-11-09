using System;
using System.Linq;

namespace Telephony
{
    public class SmartPhone : StationaryPhone, IBrowsable
    {
        public const string InvalidURLMessage = "Invalid URL!";

        public void Call(string phoneNumber)
        {
            CheckPhoneNumber(phoneNumber);

            Console.WriteLine($"Calling... {phoneNumber}");
        }

        public void Browse(string site)
        {
            CheckSite(site);

            Console.WriteLine($"Browsing: {site}!");
        }

        protected static void CheckSite(string site)
        {
            if (site.Any(char.IsDigit))
            {
                throw new ArgumentException(InvalidURLMessage);
            }
        }

    }
}