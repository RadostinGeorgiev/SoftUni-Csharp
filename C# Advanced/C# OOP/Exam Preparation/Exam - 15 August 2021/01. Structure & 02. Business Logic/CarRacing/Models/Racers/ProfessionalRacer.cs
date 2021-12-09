namespace CarRacing.Models.Racers
{
    using Cars.Contracts;

    public class ProfessionalRacer : Racer
    {
        private const int DrivingExperienceDef = 30;
        private const string RacingBehaviorDef = "strict";
        private const int DrivingExpertienceIncreasement = 10;

        public ProfessionalRacer(string username, ICar car)
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