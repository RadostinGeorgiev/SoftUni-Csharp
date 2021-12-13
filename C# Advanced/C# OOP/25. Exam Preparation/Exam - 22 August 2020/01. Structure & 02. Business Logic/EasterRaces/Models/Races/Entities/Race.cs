namespace EasterRaces.Models.Races.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Drivers.Contracts;
    using static Utilities.Messages.ExceptionMessages;


    public class Race : IRace
    {
        private string name;
        private int laps;
        private ICollection<IDriver> drivers;

        public Race(string name, int laps)
        {
            Name = name;
            Laps = laps;
            this.drivers = new List<IDriver>();
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

        public int Laps
        {
            get => this.laps;

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(InvalidNumberOfLaps, 1));
                }

                this.laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => 
            (IReadOnlyCollection<IDriver>)this.drivers;

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(DriverInvalid);
            }

            if (driver.CanParticipate == false)
            {
                throw new ArgumentException(string.Format(DriverNotParticipate, driver.Name));
            }

            if (Drivers.Contains(driver))
            {
                throw new ArgumentNullException(string.Format(DriverAlreadyAdded, driver.Name, Name));
            }

            this.drivers.Add(driver);
        }
    }
}