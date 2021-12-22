namespace CarRacing.Models.Racers
{
    using Cars.Contracts;

    public class StreetRacer : Racer
    {
        private const int InitialDrivingExperience = 10;
        private const string DefaultRacingBehavior = "aggressive";

        public StreetRacer(string username, ICar car)
            : base(username, 
                DefaultRacingBehavior, 
                InitialDrivingExperience, 
                car)
        {
        }

        public override void Race()
        {
            base.Race();
            DrivingExperience += 5;
        }
    }
}