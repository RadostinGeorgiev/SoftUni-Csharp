using System;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private static string ErrorMessage { get; } = "Invalid input!";
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ErrorMessage);
                }

                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ErrorMessage);
                }

                this.age = value;
            }
        }

        public string Gender
        {
            get
            {
                return this.gender;
            }
            private set
            {
                if (value != "Male" && value != "Female")
                {
                    throw new ArgumentException(ErrorMessage);
                }

                this.gender = value;
            }
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}");
            sb.AppendLine($"{this.name} {this.age} {this.gender}");
            sb.AppendLine($"{this.ProduceSound()}");

            return sb.ToString().Trim();
        }
    }
}