namespace CarRacing.Models.Cars
{
    using System;
    using Contracts;
    using static Utilities.Messages.ExceptionMessages;

    public abstract class Car : ICar
    {
        private string make;
        private string model;
        private string vin;
        private int horsePower;
        private double fuelAvailable;
        private double fuelConsumptionPerRace;

        protected Car(string make, string model, string vin, int horsePower, double fuelAvailable, double fuelConsumptionPerRace)
        {
            Make = make;
            Model = model;
            VIN = vin;
            HorsePower = horsePower;
            FuelAvailable = fuelAvailable;
            FuelConsumptionPerRace = fuelConsumptionPerRace;
        }

        public string Make
        {
            get => this.make;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(InvalidCarMake);
                }

                this.make = value;
            }
        }

        public string Model
        {
            get => this.model;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(InvalidCarModel);
                }

                this.model = value;
            }
        }

        public string VIN
        {
            get => this.vin;

            private set
            {
                if (value.Length != 17)
                {
                    throw new ArgumentException(InvalidCarVIN);
                }

                this.vin = value;
            }
        }

        public int HorsePower
        {
            get => this.horsePower;

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(InvalidCarHorsePower);
                }

                this.horsePower = value;
            }
        }

        public double FuelAvailable
        {
            get => this.fuelAvailable;

            private set => this.fuelAvailable = value < 0 ? 0 : value;
        }

        public double FuelConsumptionPerRace
        {
            get => this.fuelConsumptionPerRace;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(InvalidCarFuelConsumption);
                }

                this.fuelConsumptionPerRace = value;
            }
        }

        public virtual void Drive()
        {
            FuelAvailable -= FuelConsumptionPerRace;
        }
    }
}