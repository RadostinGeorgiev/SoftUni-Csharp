using System;

namespace WarCroft.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Constants;
    using Entities.Items;
    using Entities.Characters.Contracts;
    using static WarCroft.Constants.ExceptionMessages;

    public class WarController
    {
        private ICollection<Character> party;
        private Stack<Item> pool;

        public WarController()
        {
            this.party = new List<Character>();
            this.pool = new Stack<Item>();
        }

        public string JoinParty(string[] args)
        {
            var characterType = args[0];
            var name = args[1];

            Character character = characterType switch
            {
                "Warrior" => new Warrior(name),
                "Priest" => new Priest(name),
                _ => throw new ArgumentException(string.Format(InvalidCharacterType, characterType))
            };

            this.party.Add(character);
            return string.Format(SuccessMessages.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            var itemName = args[0];

            Item item = itemName switch
            {
                nameof(FirePotion) => new FirePotion(),
                nameof(HealthPotion) => new HealthPotion(),
                _ => throw new ArgumentException(string.Format(InvalidItem, itemName))
            };

            this.pool.Push(item);
            return string.Format(SuccessMessages.AddItemToPool, itemName);
        }

        public string PickUpItem(string[] args)
        {
            var characterName = args[0];

            var character = this.party.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException(string.Format(CharacterNotInParty, characterName));
            }

            if (this.pool.Count == 0)
            {
                throw new InvalidOperationException(ItemPoolEmpty);
            }

            var item = this.pool.Pop();
            character.Bag.AddItem(item);

            return (string.Format(SuccessMessages.PickUpItem, characterName, item.GetType().Name));
        }

        public string UseItem(string[] args)
        {
            var characterName = args[0];
            var itemName = args[1];

            Character character = this.party.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException(string.Format(CharacterNotInParty, characterName));
            }

            Item item = character.Bag.GetItem(itemName);
            character.UseItem(item);

            return string.Format(SuccessMessages.UsedItem, characterName, itemName);
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var character in this.party
                         .OrderByDescending(c => c.IsAlive)
                         .ThenByDescending(c => c.Health))
            {
                var isAlive = character.IsAlive == true ? "Alive" : "Dead";

                sb.AppendLine(string.Format(SuccessMessages.CharacterStats, 
                    character.Name, 
                    character.Health,
                    character.BaseHealth, 
                    character.Armor, 
                    character.BaseArmor, 
                    isAlive));
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            var attackerName = args[0];
            var receiverName = args[1];

            Character attacker = this.party.FirstOrDefault(c => c.Name == attackerName);

            if (attacker == null)
            {
                throw new ArgumentException(string.Format(CharacterNotInParty, attackerName));
            }

            Character receiver = this.party.FirstOrDefault(c => c.Name == receiverName);

            if (receiver == null)
            {
                throw new ArgumentException(string.Format(CharacterNotInParty, receiverName));
            }

            if (attacker.GetType() != typeof(Warrior))
            {
                throw new ArgumentException(string.Format(AttackFail, attackerName));
            }

            (attacker as Warrior).Attack(receiver);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(SuccessMessages.AttackCharacter, 
                attacker.Name, 
                receiver.Name, 
                attacker.AbilityPoints,
                receiver.Name, 
                receiver.Health, 
                receiver.BaseHealth, 
                receiver.Armor, 
                receiver.BaseArmor));

            if (!receiver.IsAlive)
            {
                sb.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter, receiverName));
            }

            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            var healerName = args[0];
            var receiverName = args[1];

            Character healer = this.party.FirstOrDefault(c => c.Name == healerName);

            if (healer == null)
            {
                throw new ArgumentException(string.Format(CharacterNotInParty, healerName));
            }

            Character receiver = this.party.FirstOrDefault(c => c.Name == receiverName);

            if (receiver == null)
            {
                throw new ArgumentException(string.Format(CharacterNotInParty, receiverName));
            }

            if (healer.GetType() != typeof(Priest))
            {
                throw new ArgumentException(string.Format(HealerCannotHeal, healerName));
            }

            (healer as Priest).Heal(receiver);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(SuccessMessages.HealCharacter, 
                healer.Name, 
                receiver.Name, 
                healer.AbilityPoints,
                receiver.Name, 
                receiver.Health));

            return sb.ToString().TrimEnd();
        }
    }
}