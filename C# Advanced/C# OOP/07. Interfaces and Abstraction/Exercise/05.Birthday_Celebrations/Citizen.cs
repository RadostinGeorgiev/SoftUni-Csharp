namespace BirthdayCelebrations
{
    public class Citizen : IInhabitant, IBurthable
    {
        public Citizen(string name, int age, string id, string birthday)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthday = birthday;
        }

        public string Id { get; }
        public string Name { get; protected set; }
        public int Age { get; protected set; }
        public string Birthday { get; protected set; }
    }
}