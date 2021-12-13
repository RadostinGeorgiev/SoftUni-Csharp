namespace WarCroft.Entities.Characters.Contracts
{
    using Inventory;

    public class Priest : Character, IHealer
    {
        private const double InitialBaseHealth = 50;
        private const double InitialBaseArmor = 25;
        private const double InitialAbilityPoints = 40;

        public Priest(string name)
            : base(name, InitialBaseHealth, InitialBaseArmor, InitialAbilityPoints, new Backpack())
        {
        }

        public void Heal(Character character)
        {
            this.EnsureAlive();
            character.EnsureAlive();

            character.Health += this.AbilityPoints;
        }
    }
}