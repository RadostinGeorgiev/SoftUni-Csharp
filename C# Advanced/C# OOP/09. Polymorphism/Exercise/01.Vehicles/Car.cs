﻿namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double AirConditionerFuelIncreasing = 0.9;

        public Car(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
        }

        public override double FuelConsumption
        {
            get => base.FuelConsumption;
            protected set => base.FuelConsumption = value + AirConditionerFuelIncreasing;
        }
    }
}