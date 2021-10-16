using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> _collection;
        public Stack(params T[] data)
        {
            _collection = new List<T>(data);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = _collection.Count - 1; i >= 0; i--)
            {
                var item = _collection[i];
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Push(params T[] data)
        {
            foreach (var item in data)
            {
                _collection.Add(item);
            }
        }

        public void Pop()
        {
            if (_collection.Count == 0)
            {
                Console.WriteLine("No elements");
                return;
            }

            T item = _collection[_collection.Count - 1];
            _collection.RemoveAt(_collection.Count - 1);
        }
    }
}