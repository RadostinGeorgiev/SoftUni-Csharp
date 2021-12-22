namespace CarRacing.Models.Cars
{
    using System;

    public class TunedCar : Car
    {
        private const double InitialFuelAvailable = 65;
        private const double InitialFuelConsumptionPerRace = 7.5;

        public TunedCar(string make, string model, string vin, int horsePower)
            : base(make, 
                model, 
                vin, 
                horsePower, 
                InitialFuelAvailable, 
                InitialFuelConsumptionPerRace)
        {
        }

        public override void Drive()
        {
            base.Drive();
            HorsePower = (int)Math.Round(HorsePower * 0.97);
        }
    }
}