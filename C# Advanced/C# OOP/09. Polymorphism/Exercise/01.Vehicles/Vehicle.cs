using System;

namespace Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private const string MissingFuelMessage = "{0} needs refueling";
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; protected set; }
        public virtual double FuelConsumption { get; protected set; }

        public string Drive(double distance)
        {
            double consumption = FuelConsumption * distance;
            if (consumption > FuelQuantity)
            {
                throw new InvalidOperationException(String.Format(MissingFuelMessage, this.GetType().Name));
            }

            FuelQuantity -= consumption;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double liters)
        {
            FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:F2}";
        }
    }
}