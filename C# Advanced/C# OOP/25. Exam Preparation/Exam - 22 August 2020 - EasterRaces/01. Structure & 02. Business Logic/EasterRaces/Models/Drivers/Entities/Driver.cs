namespace EasterRaces.Models.Drivers.Entities
{
    using System;
    using Cars.Contracts;
    using Contracts;
    using static Utilities.Messages.ExceptionMessages;

    public class Driver : IDriver
    {
        private string name;

        public Driver(string name)
        {
            Name = name;
            NumberOfWins = 0;
            CanParticipate = false;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(InvalidName, value, 5));
                }

                this.name = value;
            }
        }

        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate { get; private set; }

        public void WinRace() => NumberOfWins++;

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(CarInvalid);
            }

            Car = car;
            CanParticipate = true;
        }
    }
}