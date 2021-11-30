namespace CarRacing.Models.Racers
{
    using Cars.Contracts;

    public class StreetRacer : Racer
    {
        private const int DrivingExperienceDef = 10;
        private const string RacingBehaviorDef = "aggressive";
        private const int DrivingExpertienceIncreasement = 5;

        public StreetRacer(string username, ICar car)
            : base(username, RacingBehaviorDef, DrivingExperienceDef, car)
        {
        }

        public override void Race()
        {
            base.Race();
            this.DrivingExperience += DrivingExpertienceIncreasement;
        }
    }
}