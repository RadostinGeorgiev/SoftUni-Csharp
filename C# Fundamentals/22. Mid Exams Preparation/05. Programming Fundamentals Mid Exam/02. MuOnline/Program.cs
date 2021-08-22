using System;
using System.Globalization;
using System.Linq;

namespace _02._MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] dungeonsRooms = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            int initialHealth = 100;
            int health = initialHealth;
            int bitcoins = 0;

            for (int room = 0; room < dungeonsRooms.Length; room++)
            {
                string[] currentRoom = dungeonsRooms[room].Split().ToArray();
                string command = currentRoom[0];
                int number = int.Parse(currentRoom[1]);

                switch (command)
                {
                    case "potion":
                        int amount = number;
                        if (health + number > initialHealth)
                        {
                            amount = initialHealth - health;
                        }
                        health += amount;
                        Console.WriteLine($"You healed for {amount} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                        break;
                    case "chest":
                        bitcoins += number;
                        Console.WriteLine($"You found {number} bitcoins.");
                        break;
                    default:
                        health -= number;
                        if (health > 0)
                        {
                            Console.WriteLine($"You slayed {command}.");
                        }
                        else
                        {
                            Console.WriteLine($"You died! Killed by {command}.");
                            Console.WriteLine($"Best room: {room + 1}");
                            return;
                        }
                        break;
                }
            }

            Console.WriteLine($"You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {health}");
        }
    }
}
