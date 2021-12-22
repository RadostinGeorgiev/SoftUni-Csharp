namespace EasterRaces.Core.Entities
{
    using System;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Models.Cars.Contracts;
    using Models.Cars.Entities;
    using Models.Drivers.Contracts;
    using Models.Drivers.Entities;
    using Models.Races.Contracts;
    using Models.Races.Entities;
    using Repositories.Entities;
    using static Utilities.Messages.ExceptionMessages;
    using static Utilities.Messages.OutputMessages;

    public class ChampionshipController : IChampionshipController
    {
        private DriverRepository driverRepository;
        private CarRepository carRepository;
        private RaceRepository raceRepository;

        public ChampionshipController()
        {
            this.driverRepository = new DriverRepository();
            this.carRepository = new CarRepository();
            this.raceRepository = new RaceRepository();
        }

        public string CreateDriver(string driverName)
        {
            IDriver driver = new Driver(driverName);

            if (this.driverRepository.GetByName(driverName) != null)
            {
                throw new ArgumentException(string.Format(DriversExists, driverName));
            }

            this.driverRepository.Add(driver);

            return string.Format(DriverCreated, driverName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = type switch
            {
                "Muscle" => new MuscleCar(model, horsePower),
                "Sports" => new SportsCar(model, horsePower),
                _ => null
            };

            if (this.carRepository.GetByName(model) != null)
            {
                throw new ArgumentException(string.Format(CarExists, model));
            }

            this.carRepository.Add(car);

            return string.Format(CarCreated, car.GetType().Name, model);
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = new Race(name, laps);

            if (this.raceRepository.GetByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(RaceExists, name));
            }

            this.raceRepository.Add(race);

            return string.Format(RaceCreated, name);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IDriver driver = this.driverRepository.GetByName(driverName);
            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(DriverNotFound, driverName));
            }

            IRace race = this.raceRepository.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException(string.Format(RaceNotFound, raceName));
            }

            race.AddDriver(driver);

            return string.Format(DriverAdded, driverName, raceName);
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            ICar car = this.carRepository.GetByName(carModel);
            if (car == null)
            {
                throw new InvalidOperationException(string.Format(CarNotFound, carModel));
            }

            IDriver driver = this.driverRepository.GetByName(driverName);
            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(DriverNotFound, driverName));
            }

            driver.AddCar(car);

            return string.Format(CarAdded, driverName, carModel);
        }

        public string StartRace(string raceName)
        {
            IRace race = this.raceRepository.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException(string.Format(RaceNotFound, raceName));
            }

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(RaceInvalid, raceName, 3));
            }

            var winners = race.Drivers.OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps)).Take(3).ToArray();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(DriverFirstPosition, winners[0].Name, raceName))
              .AppendLine(string.Format(DriverSecondPosition, winners[1].Name, raceName))
              .AppendLine(string.Format(DriverThirdPosition, winners[2].Name, raceName));

            this.raceRepository.Remove(race);

            return sb.ToString().TrimEnd();
        }
    }
}