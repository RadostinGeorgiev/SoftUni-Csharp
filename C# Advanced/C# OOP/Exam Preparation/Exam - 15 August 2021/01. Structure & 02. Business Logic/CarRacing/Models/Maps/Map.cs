namespace CarRacing.Models.Maps
{
    using Contracts;
    using Racers.Contracts;
    using static Utilities.Messages.OutputMessages;

    public class Map : IMap
    {
        private IRacer _winner;
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return RaceCannotBeCompleted;
            }

            if (!racerOne.IsAvailable())
            {
                this._winner = racerTwo;
                return string.Format(OneRacerIsNotAvailable, 
                    racerTwo.Username, racerOne.Username);
            }

            if (!racerTwo.IsAvailable())
            {
                this._winner = racerOne;
                return string.Format(OneRacerIsNotAvailable, 
                    racerOne.Username, racerTwo.Username);
            }

            this._winner = RaceOnMap(racerOne) > RaceOnMap(racerTwo) ? racerOne : racerTwo;

            return string.Format(RacerWinsRace, 
                racerOne.Username, racerTwo.Username, this._winner.Username);
        }

        private static double RaceOnMap(IRacer racer)
        {
            var racingBehaviorMultiplier = racer.RacingBehavior switch
            {
                "strict" => 1.2,
                "aggressive" => 1.1,
                _ => 1
            };

            racer.Race();
            var chanceOfWinning = racer.Car.HorsePower * racer.DrivingExperience * racingBehaviorMultiplier;

            return chanceOfWinning;
        }
    }
}