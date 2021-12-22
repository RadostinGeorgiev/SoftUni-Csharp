namespace Easter.Models.Dyes
{
    using Contracts;

    public class Dye : IDye
    {
        private int _power;

        public Dye(int power)
        {
            this.Power = power;
        }

        public int Power
        {
            get => this._power;

            private set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this._power = value;
            }
        }

        public void Use()
        {
            Power -= 10;

            if (Power < 0)
            {
                Power = 0;
            }
        }

        public bool IsFinished() =>  Power == 0;
    }
}