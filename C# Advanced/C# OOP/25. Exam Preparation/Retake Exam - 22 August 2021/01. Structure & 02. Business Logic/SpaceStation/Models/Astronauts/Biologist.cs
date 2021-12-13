namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const int OxygenDecreasement = 5;
        private const double InitialOxygen = 70;

        public Biologist(string name) 
            : base(name, InitialOxygen)
        {
        }

        public override void Breath()
        {
            Oxygen -= OxygenDecreasement;

            if (Oxygen < 0)
            {
                Oxygen = 0;
            }
        }
    }
}