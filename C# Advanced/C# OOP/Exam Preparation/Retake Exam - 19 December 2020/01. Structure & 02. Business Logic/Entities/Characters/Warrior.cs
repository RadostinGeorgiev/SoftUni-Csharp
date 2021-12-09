namespace WarCroft.Entities.Characters.Contracts
{
    using System;
    using Inventory;
    using static WarCroft.Constants.ExceptionMessages;


    public class Warrior : Character, IAttacker
    {
        private const double InitialBaseHealth = 100;
        private const double InitialBaseArmor = 50;
        private const double InitialAbilityPoints = 40;

        public Warrior(string name)
            : base(name, InitialBaseHealth, InitialBaseArmor, InitialAbilityPoints, new Satchel())
        {
        }

        public void Attack(Character character)
        {
            this.EnsureAlive();

            if (this.Equals(character))
            {
                throw new InvalidOperationException(CharacterAttacksSelf);
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}