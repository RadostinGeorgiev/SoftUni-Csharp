namespace CarRacing.Models.Racers
{
    using System;
    using System.Text;
    using Cars.Contracts;
    using Contracts;
    using static Utilities.Messages.ExceptionMessages;

    public abstract class Racer : IRacer
    {
        private string username;
        private string racingBehavior;
        private int drivingExperience;
        private ICar car;

        protected Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            Username = username;
            RacingBehavior = racingBehavior;
            DrivingExperience = drivingExperience;
            Car = car;
        }

        public string Username
        {
            get => this.username;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(InvalidRacerName);
                }   

                this.username = value;
            }
        }

        public string RacingBehavior
        {
            get => this.racingBehavior;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(InvalidRacerBehavior);
                }

                this.racingBehavior = value;
            }
        }

        public int DrivingExperience
        {
            get => this.drivingExperience;

            protected set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(InvalidRacerDrivingExperience);
                }

                this.drivingExperience = value;
            }
        }

        public ICar Car
        {
            get => this.car;

            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(InvalidRacerCar);
                }

                this.car = value;
            }
        }

        public virtual void Race()
        {
            Car.Drive();
        }

        public bool IsAvailable() =>
           Car.FuelAvailable >= Car.FuelConsumptionPerRace;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}: {Username}")
                .AppendLine($"--Driving behavior: {RacingBehavior}")
                .AppendLine($"--Driving experience: {DrivingExperience}")
                .AppendLine($"--Car: {Car.Make} {Car.Model} ({Car.VIN})");

            return sb.ToString().TrimEnd();
        }
    }
}