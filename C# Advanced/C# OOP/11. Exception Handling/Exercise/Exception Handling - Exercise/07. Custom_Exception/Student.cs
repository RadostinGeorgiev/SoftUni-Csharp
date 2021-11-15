using System;

namespace _07._Custom_Exception
{
    public class Student
    {
        private const string InvalidEmailMessage = "The e-mail can't be null or empty.";

        private string name;
        private string email;

        public Student(string firstName, string email)
        {
            Name = firstName;
            Email = email;
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidPersonNameException();
                }

                name = value;
            }
        }
        public string Email
        {
            get => email;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException($"{value}", InvalidEmailMessage);
                }

                email = value;
            }
        }
    }
}