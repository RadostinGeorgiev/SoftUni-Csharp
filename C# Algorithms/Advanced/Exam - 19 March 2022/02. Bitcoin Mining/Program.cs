namespace _02._Bitcoin_Mining
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Transaction                                                        //Item
    {
        public string Hash { get; set; }
        public int Size { get; set; }                                               //Weight
        public int Fees { get; set; }                                               //Value
        public string From { get; set; }
        public string To { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Transaction> transactions = new List<Transaction>();               //items

            int maxCapacity = 1000000;
            int pendingTransactions = int.Parse(Console.ReadLine());

            for (int i = 0; i < pendingTransactions; i++)
            {
                string[] transactionData = Console.ReadLine().Split();

                transactions.Add(new Transaction
                {
                    Hash = transactionData[0],
                    Size = int.Parse(transactionData[1]),
                    Fees = int.Parse(transactionData[2]),
                    From = transactionData[3],
                    To = transactionData[4]
                });
            }

            int[,] matrix = CreateMatrix(transactions, maxCapacity);
            List<Transaction> selectedItems = GetTakenItems(transactions, matrix);

            Console.WriteLine($"Total Size: {selectedItems.Sum(x => x.Size)}");
            Console.WriteLine($"Total Fees: {selectedItems.Sum(x => x.Fees)}");

            foreach (Transaction item in selectedItems)
            {
                Console.WriteLine($"{item.Hash}");
            }
        }

        private static List<Transaction> GetTakenItems(List<Transaction> items, int[,] matrix)
        {
            List<Transaction> selectedItems = new List<Transaction>();

            int index = matrix.GetLength(0) - 1;
            int capacity = matrix.GetLength(1) - 1;

            while (index > 0 && capacity > 0)
            {
                if (matrix[index, capacity] != matrix[index - 1, capacity])
                {
                    Transaction item = items[index - 1];
                    selectedItems.Add(item);

                    capacity -= item.Size;
                }

                index -= 1;
            }

            return selectedItems;
        }

        private static int[,] CreateMatrix(List<Transaction> items, int maxCapacity)
        {
            int[,] dp = new int[items.Count + 1, maxCapacity + 1];

            for (int index = 1; index < dp.GetLength(0); index++)
            {
                Transaction item = items[index - 1];

                for (int capacity = 1; capacity < dp.GetLength(1); capacity++)
                {
                    int excluding = dp[index - 1, capacity];

                    if (item.Size > capacity)
                    {
                        dp[index, capacity] = excluding;
                    }
                    else
                    {
                        int including = item.Fees + dp[index - 1, capacity - item.Size];
                        dp[index, capacity] = Math.Max(excluding, including);
                    }
                }
            }

            return dp;
        }
    }
}