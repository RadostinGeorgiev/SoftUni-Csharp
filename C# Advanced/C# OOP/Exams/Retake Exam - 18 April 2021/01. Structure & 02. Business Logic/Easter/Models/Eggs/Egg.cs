namespace Easter.Models.Eggs
{
    using System;
    using Contracts;
    using static Utilities.Messages.ExceptionMessages;

    public class Egg : IEgg
    {
        private string _name;

        public Egg(string name, int energyRequired)
        {
            this._name = name;
            this.EnergyRequired = energyRequired;
        }

        public string Name
        {
            get => this._name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(InvalidEggName);
                }

                this._name = value;
            }
        }

        public int EnergyRequired { get; private set; }

        public void GetColored()
        {
            EnergyRequired -= 10;

            if (EnergyRequired < 0)
            {
                EnergyRequired = 0;
            }
        }

        public bool IsDone() => EnergyRequired <= 0;
    }
}