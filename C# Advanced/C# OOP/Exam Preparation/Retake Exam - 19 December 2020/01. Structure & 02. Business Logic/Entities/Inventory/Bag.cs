using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Items;
    using static Constants.ExceptionMessages;

    public abstract class Bag : IBag
    {
        private readonly ICollection<Item> items;

        protected Bag(int capacity)
        {
            Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity { get; set; } = 100;

        public int Load =>
            this.items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items => 
            (IReadOnlyCollection<Item>)this.items;

        public void AddItem(Item item)
        {
            if (Load + item.Weight > Capacity)
            {
                throw new InvalidOperationException(ExceedMaximumBagCapacity);
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException(EmptyBag);
            }

            Item item = this.items.FirstOrDefault(i => i.GetType().Name == name);

            if (item == null)
            {
                throw new ArgumentException(string.Format(ItemNotFoundInBag, name));
            }

            this.items.Remove(item);
            return item;
        }
    }
}