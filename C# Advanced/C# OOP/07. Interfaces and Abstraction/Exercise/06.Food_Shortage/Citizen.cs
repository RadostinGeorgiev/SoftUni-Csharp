namespace FoodShortage
{
    public class Citizen : IInhabitant, IBurthable, IPerson, IBuyer
    {
        public Citizen(string name, int age, string id, string birthday)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthday = birthday;
        }

        public string Id { get; }
        public int Food { get; protected set; } = 0;
        public string Name { get; protected set; }
        public int Age { get; protected set; }
        public string Birthday { get; protected set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}