using System;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        protected const string NegativeFuelMessage = "Fuel must be a positive number";
        protected const string MoreFuelMessage = "Cannot fit {0} fuel in the tank";
        protected const string MoreThanTankCapacityMessage = "Cannot fit {0} fuel in the tank";

        private double fuelQuantity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }


        public double FuelQuantity
        {
            get => fuelQuantity;
            protected set
            {
                if (value > TankCapacity)
                {
                    value = 0;
                }

                fuelQuantity = value;
            }
        }

        public virtual double FuelConsumption { get; protected set; }
        public double TankCapacity { get; private set; }

        public virtual string Drive(double distance)
        {
            double consumption = FuelConsumption * distance;
            if (consumption > FuelQuantity)
            {
                return $"{GetType().Name} needs refueling";
            }

            FuelQuantity -= consumption;
            return $"{GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new InvalidOperationException(NegativeFuelMessage);
            }

            if ((liters + FuelQuantity) > TankCapacity)
            {
                throw new InvalidOperationException(String.Format(MoreFuelMessage, liters));
            }

            FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:F2}";
        }
    }
}