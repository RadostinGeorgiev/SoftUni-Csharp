namespace CarRacing.Models.Cars
{
    using System;

    using Contracts;
    using static Utilities.Messages.ExceptionMessages;

    public abstract class Car : ICar
    {
        private string _make;
        private string _model;
        private string _vin;
        private int _horsePower;
        private double _fuelAvailable;
        private double _fuelConsumptionPerRace;

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
            get => this._make;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(InvalidCarMake);
                }

                this._make = value;
            }
        }

        public string Model
        {
            get => this._model;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(InvalidCarModel);
                }

                this._model = value;
            }
        }

        public string VIN
        {
            get => this._vin;

            private set
            {
                if (value.Length != 17)
                {
                    throw new ArgumentException(InvalidCarVIN);
                }

                this._vin = value;
            }
        }

        public int HorsePower
        {
            get => this._horsePower;

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(InvalidCarHorsePower);
                }


                this._horsePower = value;
            }
        }

        public double FuelAvailable
        {
            get => this._fuelAvailable;

            private set => this._fuelAvailable = value < 0 ? 0 : value;
        }

        public double FuelConsumptionPerRace
        {
            get => this._fuelConsumptionPerRace;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(InvalidCarFuelConsumption);
                }
                
                this._fuelConsumptionPerRace = value;
            }
        }

        public virtual void Drive()
        {
            FuelAvailable -= FuelConsumptionPerRace;
        }
    }
}