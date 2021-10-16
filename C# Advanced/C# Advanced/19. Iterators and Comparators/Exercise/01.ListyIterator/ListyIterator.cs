using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace _01.ListyIterator
{
    public class ListyIterator<T>
    {
        private readonly List<T> _collection;
        private int _internalIndex;
        public ListyIterator(params T[] data)
        {
            this._collection = new List<T>(data);
            _internalIndex = 0;
        }

        public bool Move()
        {
            if (!HasNext()) return false;
            _internalIndex++;
            return true;
        }

        public bool HasNext()
        {
            return _internalIndex != _collection.Count - 1;
        }

        public void Print()
        {
            if (_collection.Count == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }

            Console.WriteLine(_collection[_internalIndex]);
        }
    }
}