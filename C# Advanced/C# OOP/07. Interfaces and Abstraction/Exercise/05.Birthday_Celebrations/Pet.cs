namespace BirthdayCelebrations
{
    public class Pet : IBurthable
    {
        public Pet(string name, string birthday)
        {
            Name = name;
            Birthday = birthday;
        }

        public string Birthday { get; protected set; }
        public string Name { get; set; }
    }
}