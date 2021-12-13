namespace CarRacing.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Models.Cars;
    using Models.Cars.Contracts;
    using Models.Maps;
    using Models.Maps.Contracts;
    using Models.Racers;
    using Models.Racers.Contracts;
    using Repositories;
    using static Utilities.Messages.ExceptionMessages;
    using static Utilities.Messages.OutputMessages;

    public class Controller : IController
    {
        private CarRepository _cars;
        private RacerRepository _racers;
        private IMap map;

        public Controller()
        {
            this._cars = new CarRepository();
            this._racers = new RacerRepository();
            this.map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car = type switch
            {
                "SuperCar" => new SuperCar(make, model, VIN, horsePower),
                "TunedCar" => new TunedCar(make, model, VIN, horsePower),
                _ => throw new ArgumentException(InvalidCarType)
            };

            this._cars.Add(car);

            return string.Format(SuccessfullyAddedCar,
                car.Make, car.Model, car.VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar car = this._cars.FindBy(carVIN);

            if (car == null)
            {
                throw new ArgumentException(CarCannotBeFound);
            }

            IRacer racer = type switch
            {
                "ProfessionalRacer" => new ProfessionalRacer(username, car),
                "StreetRacer" => new StreetRacer(username, car),
                _ => throw new ArgumentException(InvalidRacerType)
            };

            this._racers.Add(racer);

            return string.Format(SuccessfullyAddedRacer, racer.Username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = this._racers.FindBy(racerOneUsername);

            if (racerOne == null)
            {
                throw new ArgumentException(
                    string.Format(RacerCannotBeFound, racerOneUsername));
            }

            IRacer racerTwo = this._racers.FindBy(racerTwoUsername);
            if (racerTwo == null)
            {
                throw new ArgumentException(
                    string.Format(RacerCannotBeFound, racerTwoUsername));
            }

            return this.map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var racer in this._racers.Models
                         .OrderByDescending(r => r.DrivingExperience)
                         .ThenBy(r => r.Username))
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}