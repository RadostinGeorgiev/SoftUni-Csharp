namespace Easter.Models.Bunnies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Dyes.Contracts;
    using static Utilities.Messages.ExceptionMessages;

    public abstract class Bunny : IBunny
    {
        private string _name;
        private int _energy;

        protected Bunny(string name, int energy)
        {
            this._name = name;
            this.Energy = energy;
            this.Dyes = new List<IDye>();
        }

        public string Name
        {
            get => this._name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(InvalidBunnyName);
                }

                this._name = value;
            }
        }

        public int Energy
        {
            get => this._energy;

            protected set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this._energy = value;
            }
        }

        public ICollection<IDye> Dyes { get; }

        public virtual void Work()
        {
            Energy -= 10;

            if (Energy < 0)
            {
                Energy = 0;
            }

            var dye = Dyes.First();
            dye.Use();

            if (dye.IsFinished())
            {
                Dyes.Remove(dye);
            }
        }

        public void AddDye(IDye dye)
        {
            this.Dyes.Add(dye);
        }
    }
}