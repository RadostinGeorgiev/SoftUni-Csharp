using System;

using WarCroft.Entities.Characters.Contracts;
using static WarCroft.Constants.ExceptionMessages;

namespace WarCroft.Entities.Items
{
	public abstract class Item
	{
		protected Item(int weight)
		{
			this.Weight = weight;
		}

		public int Weight { get; }

		public virtual void AffectCharacter(Character character)
		{
			if (!character.IsAlive)
			{
				throw new InvalidOperationException(AffectedCharacterDead);
			}
		}
	}
}
