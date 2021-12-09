namespace CarRacing.Models.Racers
{
    using System;
    using System.Text;
    using Cars.Contracts;
    using Contracts;
    using static Utilities.Messages.ExceptionMessages;

    public abstract class Racer : IRacer
    {
        private string _username;
        private string _racingBehavior;
        private int _drivingExperience;
        private ICar _car;

        protected Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            Username = username;
            RacingBehavior = racingBehavior;
            DrivingExperience = drivingExperience;
            Car = car;
        }

        public string Username
        {
            get => this._username;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(InvalidRacerName);
                }

                this._username = value;
            }
        }

        public string RacingBehavior
        {
            get => this._racingBehavior;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(InvalidRacerBehavior);
                }

                this._racingBehavior = value;
            }
        }

        public int DrivingExperience
        {
            get => this._drivingExperience;

            protected set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(InvalidRacerDrivingExperience);
                }

                this._drivingExperience = value;
            }
        }

        public ICar Car
        {
            get => this._car;

            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(InvalidRacerCar);
                }

                this._car = value;
            }
        }
        public bool IsAvailable() => 
            Car.FuelAvailable > Car.FuelConsumptionPerRace;

        public virtual void Race()
        {
            Car.Drive();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}: {Username}")
                .AppendLine($"--Driving behavior: {RacingBehavior}")
                .AppendLine($"--Driving experience: { DrivingExperience}")
                .AppendLine($"--Car: {Car.Make} {Car.Model} ({Car.VIN})");

            return sb.ToString().Trim();
        }
    }
}