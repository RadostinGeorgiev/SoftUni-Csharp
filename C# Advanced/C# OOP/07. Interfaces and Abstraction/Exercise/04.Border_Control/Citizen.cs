namespace BorderControl
{
    public class Citizen : IInhabitant
    {
        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }

        public string Id { get; }
        public string Name { get; protected set; }
        public int Age { get; protected set; }
    }
}