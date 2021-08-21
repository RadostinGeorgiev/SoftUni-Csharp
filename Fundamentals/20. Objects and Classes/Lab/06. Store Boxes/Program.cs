using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Store_Boxes
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Box> boxes = new List<Box>();

            while (input != "end")
            {
                string[] info = input.Split().ToArray();
                string serialNumber = info[0];
                string itemName = info[1];
                int itemQuantity = int.Parse(info[2]);
                double itemPrice = double.Parse(info[3]);

                Box currentBox = new Box(serialNumber, itemQuantity, itemQuantity * itemPrice);
                currentBox.Item = new Item(itemName, itemPrice);

                boxes.Add(currentBox);
                
                input = Console.ReadLine();
            }

            List<Box> orderedList = boxes.OrderByDescending(x => x.BoxPrice).ToList();

            foreach (var box in orderedList)
            {
                Console.WriteLine($"{box.SerialNumber}");
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:F2}: {box.Quantity}");
                Console.WriteLine($"-- ${box.BoxPrice:F2}");
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Item()
        {
        }

        public Item(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }
    }

    public class Box
    {
        //Serial Number, Item, Item Quantity and Price for a Box
        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public double BoxPrice { get; set; }

        public Box(string serial, int quantity, double price)
        {
            Item = new Item();

            this.SerialNumber = serial;
            this.Quantity = quantity;
            this.BoxPrice = price;
        }
    }
}
