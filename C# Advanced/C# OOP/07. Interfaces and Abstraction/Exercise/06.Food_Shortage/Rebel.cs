namespace FoodShortage
{
    public class Rebel : IPerson, IBuyer
    {
        public Rebel(string name, int age, string @group)
        {
            Name = name;
            Age = age;
            Group = @group;
        }

        public int Food { get; protected set; } = 0;
        public string Name { get; protected set; }
        public int Age { get; protected set; }
        public string Group { get; protected set; }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}