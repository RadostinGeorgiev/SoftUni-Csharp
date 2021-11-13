namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double AirConditionerFuelIncreasing = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override string Drive(double distance)
        {
            FuelConsumption += AirConditionerFuelIncreasing;
            var result = base.Drive(distance);
            FuelConsumption -= AirConditionerFuelIncreasing;
            return result;
        }
        public string DriveEmpty(double distance)
        {
            return base.Drive(distance);
        }
    }
}