using System;
using System.Collections;
using System.Collections.Generic;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
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

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _collection)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}