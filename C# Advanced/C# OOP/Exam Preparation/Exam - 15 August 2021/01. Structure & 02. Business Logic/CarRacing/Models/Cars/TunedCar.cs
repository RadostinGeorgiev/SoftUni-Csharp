namespace CarRacing.Models.Cars
{
    using System;

    public class TunedCar : Car
    {
        private const double FuelAvailableDef = 65;
        private const double FuelConsumptionPerRaceDef = 7.5;

        public TunedCar(string make, string model, string vin, int horsePower)
            : base(make, model, vin, horsePower, FuelAvailableDef, FuelConsumptionPerRaceDef)
        {
        }

        public override void Drive()
        {
            base.Drive();
            this.HorsePower = (int)Math.Round(this.HorsePower * 0.97);
        }
    }
}