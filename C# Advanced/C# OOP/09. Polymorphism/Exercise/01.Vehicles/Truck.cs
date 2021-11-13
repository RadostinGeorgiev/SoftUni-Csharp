namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double  AirConditionerFuelIncreasing = 1.6;
        
        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
        }

        public override double FuelConsumption
        {
            get => base.FuelConsumption;
            protected set => base.FuelConsumption = value + AirConditionerFuelIncreasing;
        }

        public override void Refuel(double liters)
        {
            base.Refuel(liters * 0.95);
        }
    }
}