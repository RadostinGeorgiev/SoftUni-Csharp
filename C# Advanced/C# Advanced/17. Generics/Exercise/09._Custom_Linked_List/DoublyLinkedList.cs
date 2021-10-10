using System;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        private ListNode<T> head;
        private ListNode<T> tail;
        public int Count
        {
            get
            {
                int counter = 0;
                var currentItem = head;

                while (currentItem != null)
                {
                    counter++;
                    currentItem = currentItem.Next;
                }

                return counter;
            }

            private set { }
        }

        public void AddFirst(T element)
        {
            ListNode<T> newItem = new ListNode<T>(element);

            if (head == null)
            {
                head = newItem;
                tail = newItem;
            }
            else
            {
                newItem.Next = head;
                head.Previous = newItem;
                head = newItem;
            }
        }
        public void AddLast(T element)
        {
            ListNode<T> newItem = new ListNode<T>(element);

            if (tail == null)
            {
                head = newItem;
                tail = newItem;
            }
            else
            {
                newItem.Previous = tail;
                tail.Next = newItem;
                tail = newItem;
            }
        }
        public T RemoveFirst()
        {
            if (head == null) //0 items
            {
                throw new InvalidOperationException("The list is empty");
            }

            T item = head.Value;
            if (head == tail) //1 item
            {
                head = null;
                tail = null;
            }
            else //more than 1 items
            {
                head = head.Next;
                head.Previous = null;
            }

            return item;
        }
        public T RemoveLast()
        {
            if (tail == null)  //0 items
            {
                throw new InvalidOperationException("The list is empty");
            }

            T item = tail.Value;
            if (head == tail) //1 item
            {
                head = null;
                tail = null;
            }
            else
            {
                tail = tail.Previous;
                tail.Next = null;
            }

            return item;
        }

        public void ForEach(Action<T> action)
        {
            var currentItem = head;

            while (currentItem != null)
            {
                action(currentItem.Value);
                currentItem = currentItem.Next;
            }

        }

        public T[] ToArray()
        {
            T[] array = new T[Count];
            int index = 0;
            var currentItem = head;

            while (currentItem != null)
            {
                array[index] = currentItem.Value;
                index++;
                currentItem = currentItem.Next;
            }

            return array;
        }
    }
}