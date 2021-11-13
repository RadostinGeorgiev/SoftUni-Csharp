namespace Vehicles.Models
{
    public interface IVehicle
    {
        public double FuelQuantity { get; }
        public double FuelConsumption { get; }
        public double TankCapacity { get; }

        public string Drive(double distance);
        public void Refuel(double liters);
    }
}