namespace PersonsInfo
{
    public class Person
    {
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public int Age { get; }
        public decimal Salary { get; private set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age < 30)
                percentage /= 2;

            this.Salary += percentage * this.Salary / 100;
        }
    }
}