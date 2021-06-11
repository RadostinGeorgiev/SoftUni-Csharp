using System;
using System.Linq;

namespace _10._LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
//------------------ INITIAL INITIALIZATION ----------------------------  
            int fieldSize = int.Parse(Console.ReadLine());
            int[] field = new int[fieldSize];
            int[] initialIndexes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            foreach (var bugPosition in initialIndexes)
            {
                if (bugPosition >= 0 && bugPosition < field.Length)
                {
                    field[bugPosition] = 1;
                }
            }

//------------------ MOVE LADYBUGS ----------------------------  
            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] commands = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int position = int.Parse(commands[0]);
                string direction = commands[1];
                int shift = int.Parse(commands[2]);
                int length = field.Length;

                if ((position >= 0) && (position < field.Length) && (field[position] == 1))
                {
                    field[position] = 0;
                    int newPosition = position;
                    bool isOutside = false;

                    if (direction == "right")
                    {
                        newPosition = position + shift;
                        if (newPosition >= length)
                        {
                            isOutside = true;
                        }
                        else
                        {
                            while (field[newPosition] != 0)
                            {
                                newPosition += shift;
                                if (newPosition >= length)
                                {
                                    isOutside = true;
                                    break;
                                }
                            }
                        }
                    }
                    else if (direction == "left")
                    {
                        newPosition = position - shift;
                        if (newPosition < 0)
                        {
                            isOutside = true;
                        }
                        else
                        {
                            while (field[newPosition] != 0)
                            {
                                newPosition -= shift;
                                if (newPosition < 0)
                                {
                                    isOutside = true;
                                    break;
                                }
                            }
                        }
                    }

                    if (!isOutside)
                    {
                        field[newPosition] = 1;
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(String.Join(' ', field));
        }
    }
}
