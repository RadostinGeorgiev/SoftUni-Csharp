using System;
using System.Text;
using CollectionHierarchy.Interfaces;

namespace CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var myAddCollection = new AddCollection();
            var myAddRemoveCollection = new AddRemoveCollection();
            var myListCollection = new MyList();
            string[] inputString = Console.ReadLine().Split();
            int removeOperations = int.Parse(Console.ReadLine());

            Console.WriteLine(AddInMyCollection(inputString, myAddCollection));
            Console.WriteLine(AddInMyCollection(inputString, myAddRemoveCollection));
            Console.WriteLine(AddInMyCollection(inputString, myListCollection));
            Console.WriteLine(RemoveFromMyCollection(removeOperations, myAddRemoveCollection));
            Console.WriteLine(RemoveFromMyCollection(removeOperations, myListCollection));
        }

        private static string AddInMyCollection(string[] inputString, IAddCollection collection)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var @string in inputString)
            {
                sb.Append(collection.Add(@string) + " ");
            }

            return sb.ToString().Trim();
        }
        private static string RemoveFromMyCollection(int removeOperations, IAddRemoveCollection collection)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < removeOperations; i++)
            {
                sb.Append(collection.Remove() + " ");
            }

            return sb.ToString().Trim();
        }
    }
}