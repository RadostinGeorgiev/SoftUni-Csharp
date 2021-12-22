namespace Gym.Models.Athletes
{
    public class Boxer : Athlete
    {
        private const int InitialStamina = 60;

        public Boxer(string fullName, string motivation, int numberOfMedals)
            : base(fullName, motivation, numberOfMedals, InitialStamina)
        {
        }

        public override void Exercise()
        {
            Stamina += 15;
        }
    }
}