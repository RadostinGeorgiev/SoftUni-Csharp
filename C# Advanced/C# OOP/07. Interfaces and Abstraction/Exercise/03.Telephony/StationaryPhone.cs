using System;
using System.Linq;

namespace Telephony
{
    public class StationaryPhone : ICalable
    {
        public const string InvalidPhoneMessage = "Invalid number!";
        public void Call(string phoneNumber)
        {
            CheckPhoneNumber(phoneNumber);

            Console.WriteLine($"Dialing... {phoneNumber}");
        }

        protected static void CheckPhoneNumber(string phoneNumber)
        {
            if (!phoneNumber.All(char.IsDigit) || 
                (phoneNumber.Length != 7 && 
                phoneNumber.Length != 10))
            {
                throw new ArgumentException(InvalidPhoneMessage);
            }
        }
    }
}