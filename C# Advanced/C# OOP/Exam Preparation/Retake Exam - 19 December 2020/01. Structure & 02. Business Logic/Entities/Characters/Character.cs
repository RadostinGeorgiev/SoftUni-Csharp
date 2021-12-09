using System;

namespace WarCroft.Entities.Characters.Contracts
{
    using Inventory;
    using Items;
    using static WarCroft.Constants.ExceptionMessages;

    public abstract class Character
    {
        private string _name;
        private double _health;
        private double _armor;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.IsAlive = true;
        }

        public string Name
        {
            get => this._name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(CharacterNameInvalid);
                }

                this._name = value;
            }
        }

        public double BaseHealth { get; }

        public double Health
        {
            get => this._health;

            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                else if (value > BaseHealth)
                {
                    value = BaseHealth;
                }

                this._health = value;
            }
        }

        public double BaseArmor { get; }

        public double Armor
        {
            get => this._armor;

            private set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this._armor = value;
            }
        }

        public double AbilityPoints { get; }
        public Bag Bag { get; set; }
        public bool IsAlive { get; set; }

        protected internal void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();

            if (Armor > hitPoints)
            {
                Armor -= hitPoints;
            }
            else
            {
                hitPoints -= Armor;
                Armor = 0;
                Health -= hitPoints;
            }

            if (Health <= 0)
            {
                IsAlive = false;
            }
        }

        public void UseItem(Item item)
        {
            EnsureAlive();
            item.AffectCharacter(this);
        }
    }
}