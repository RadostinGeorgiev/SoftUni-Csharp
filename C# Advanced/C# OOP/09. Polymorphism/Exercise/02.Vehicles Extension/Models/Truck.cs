using System;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double  AirConditionerFuelIncreasing = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption
        {
            get => base.FuelConsumption;
            protected set => base.FuelConsumption = value + AirConditionerFuelIncreasing;
        }

        public override void Refuel(double liters)
        {
            if ((liters + this.FuelQuantity) > this.TankCapacity)
            {
                throw new InvalidOperationException(String.Format(MoreFuelMessage, liters));
            }

            base.Refuel(liters * 0.95);
        }
    }
}