using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();

            list.AddFirst("3");
            list.AddFirst("2");
            list.AddFirst("1");
            list.AddFirst("0");
            list.AddLast("4");
            list.AddLast("5");
            list.AddLast("100");
            Console.WriteLine(list.Count);
            Console.WriteLine(list.RemoveFirst());
            Console.WriteLine(list.RemoveLast());
            Console.WriteLine(list.Count);

            Console.WriteLine(string.Join(", ", list.ToArray()));
            list.ForEach(Console.WriteLine);
        }
    }
}