namespace Rabbits
{
    public class Rabbit
    {
        public Rabbit(string name, string species)
        {
            Name = name;
            Species = species;
        }

        public string Name { get; set; }
        public string Species { get; set; }
        public bool Available { get; set; } = true;
        public override string ToString()
        {
            return $"Rabbit ({Species}): {Name}";
        }
    }
}