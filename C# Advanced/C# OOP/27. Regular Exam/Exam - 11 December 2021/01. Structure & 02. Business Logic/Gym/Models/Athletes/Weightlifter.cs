namespace Gym.Models.Athletes
{
    using System;
    using static Utilities.Messages.ExceptionMessages;

    public class Weightlifter : Athlete
    {
        private const int InitialStamina = 50;

        public Weightlifter(string fullName, string motivation, int numberOfMedals)
            : base(fullName, motivation, numberOfMedals, InitialStamina)
        {
        }

        public override void Exercise()
        {
            Stamina += 10;
        }
    }
}