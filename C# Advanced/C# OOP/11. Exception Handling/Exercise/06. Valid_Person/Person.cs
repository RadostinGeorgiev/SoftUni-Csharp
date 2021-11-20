using System;

namespace _06._Valid_Person
{
    public class Person
    {
        private const string InvalidFirstNameMessage = "The first name cannot be null or empty.";
        private const string InvalidLastNameMessage = "The last name cannot be null or empty.";
        private const string InvalidAgeMessage = "Age should be in the range [{0} .. {1}]";

        private const int MinAge = 0;
        private const int MaxAge = 120;

        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string FirstName
        {
            get => firstName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException($"{value}", InvalidFirstNameMessage);
                }

                firstName = value;
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException($"{value}", InvalidLastNameMessage);
                }

                lastName = value;
            }
        }

        public int Age
        {
            get => age;
            set
            {
                if (value < MinAge || value > MaxAge)
                {
                    throw new ArgumentOutOfRangeException($"{value}", string.Format(InvalidAgeMessage, MinAge, MaxAge));
                }

                age = value;
            }
        }
    }
}