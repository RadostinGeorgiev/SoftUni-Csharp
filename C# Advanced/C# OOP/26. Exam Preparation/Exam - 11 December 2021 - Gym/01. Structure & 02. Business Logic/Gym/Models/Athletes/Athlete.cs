namespace Gym.Models.Athletes
{
    using System;
    using Contracts;
    using static Utilities.Messages.ExceptionMessages;

    public abstract class Athlete : IAthlete
    {
        private string fullName;
        private string motivation;
        private int numberOfMedals;
        private int stamina;

        protected Athlete(string fullName, string motivation,  int numberOfMedals, int stamina)
        {
            FullName = fullName;
            Motivation = motivation;
            NumberOfMedals = numberOfMedals;
            Stamina = stamina;
        }

        public string FullName
        {
            get => this.fullName;

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(InvalidAthleteName);
                }

                this.fullName = value;
            }
        }

        public string Motivation
        {
            get => this.motivation;

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(InvalidAthleteMotivation);
                }

                this.motivation = value;
            }
        }

        public int Stamina
        {
            get => this.stamina;

            protected set
            {
                if (value > 100)
                {
                    value = 100;

                    throw new ArgumentException(InvalidStamina);
                }   

                this.stamina = value;
            }
        }

        public int NumberOfMedals
        {
            get => this.numberOfMedals;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(InvalidAthleteMedals);
                }

                this.numberOfMedals = value;
            }
        }

        public abstract void Exercise();

        public override string ToString()
        {
            return FullName;
        }
    }
}