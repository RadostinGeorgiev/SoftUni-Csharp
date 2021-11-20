using ValidationAttributes.Attribute;

namespace ValidationAttributes.Models
{
    public class Person
    {
        private const int MinAge = 1;
        private const int MaxAge = 100;
        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }

        [MyRequired]
        public string FullName { get; set; }

        [MyRangeAttribute(MinAge, MaxAge)]
        public int Age { get; set; }
    }
}