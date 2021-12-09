namespace CarRacing.Models.Cars
{
    public class SuperCar : Car
    {
        private const double FuelAvailableDef = 80; 
        private const double FuelConsumptionPerRaceDef = 10; 
        public SuperCar(string make, string model, string vin, int horsePower)
            : base(make, model, vin, horsePower, FuelAvailableDef, FuelConsumptionPerRaceDef)
        {
        }
    }
}