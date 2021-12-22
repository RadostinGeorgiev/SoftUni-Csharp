namespace CarRacing.Models.Maps
{
    using Contracts;
    using Racers.Contracts;
    using static Utilities.Messages.OutputMessages;

    public class Map : IMap
    {
        private IRacer winner;

        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return RaceCannotBeCompleted;
            }

            if (!racerOne.IsAvailable())
            {
                this.winner = racerTwo;
                return string.Format(OneRacerIsNotAvailable, 
                    this.winner.Username, racerOne.Username);
            }

            if (!racerTwo.IsAvailable())
            {
                this.winner = racerOne;
                return string.Format(OneRacerIsNotAvailable, 
                    this.winner.Username, racerTwo.Username);
            }

            this.winner = CalculateChanceOfWinning(racerOne) > CalculateChanceOfWinning(racerTwo) ? racerOne : racerTwo;

            return string.Format(RacerWinsRace, racerOne.Username, racerTwo.Username, this.winner.Username);
        }

        private static double CalculateChanceOfWinning(IRacer racer)
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