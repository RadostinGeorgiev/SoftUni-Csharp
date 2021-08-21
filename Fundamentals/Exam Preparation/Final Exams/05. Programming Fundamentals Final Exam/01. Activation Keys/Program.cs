using System;

namespace _01._Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Generate")
            {
                string[] commands = input.Split(">>>");
                string command = commands[0];
                int startIndex = 0;
                int endIndex = 0;
                string substring = String.Empty;

                switch (command)
                {
                    case "Contains":
                        substring = commands[1];
                        if (activationKey.Contains(substring))
                        {
                            Console.WriteLine($"{activationKey} contains {substring}");
                        }
                        else
                        {
                            Console.WriteLine("Substring not found!");
                        }
                        break;
                    case "Flip":
                        string upperOrLower = commands[1];
                        startIndex = int.Parse(commands[2]);
                        endIndex = int.Parse(commands[3]);
                        substring = activationKey.Substring(startIndex, endIndex - startIndex);
                        activationKey = activationKey.Replace(substring,
                            upperOrLower == "Upper" ? substring.ToUpper() : substring.ToLower());
                        Console.WriteLine(activationKey);
                        break;
                    case "Slice":
                        startIndex = int.Parse(commands[1]);
                        endIndex = int.Parse(commands[2]);
                        activationKey = activationKey.Remove(startIndex, endIndex-startIndex);
                        Console.WriteLine(activationKey);
                        break;
                }
            }

            Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}
