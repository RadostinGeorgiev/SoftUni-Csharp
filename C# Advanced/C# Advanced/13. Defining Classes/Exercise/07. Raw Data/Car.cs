namespace RawData
{
    public class Car
    {
        public Car()
        {
            Tires = new Tire[4];
        }

        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
            : this()
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
            Tires = tires;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires { get; set; }

        public override string ToString()
        {
            return $"{this.Model}";
        }
    }
}
