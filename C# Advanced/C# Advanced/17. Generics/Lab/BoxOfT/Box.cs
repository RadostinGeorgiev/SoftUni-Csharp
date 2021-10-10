using System.Collections.Generic;

namespace BoxOfT
{
    public class Box<T>
    {
        public Stack<T> Elements { get; set; }
        public int Count => Elements.Count;

        public Box()
        {
            Elements = new Stack<T>();
        }

        public void Add(T element)
        {
            Elements.Push(element);
        }
        public T Remove()
        {
            return Elements.Pop();
        }
    }
}
