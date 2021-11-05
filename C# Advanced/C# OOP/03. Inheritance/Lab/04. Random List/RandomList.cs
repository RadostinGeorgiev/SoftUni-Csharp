using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    class RandomList : List<string>
    {
        private readonly Random random = new Random();

        public string RandomString()
        {
            int index = random.Next(0, Count);
            string item = this[index];
            this.RemoveAt(index);
            return item;
        }
    }
}