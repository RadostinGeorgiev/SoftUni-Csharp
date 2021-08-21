using System;

namespace _02._From_Left_to_The_Right
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowNumbers = int.Parse(Console.ReadLine());

            for (int i = 0; i < rowNumbers; i++)
            {
                string row = Console.ReadLine();
                //int[] numbers = row.Split(' ').Select(int.Parse).ToArray();

                bool isLeft = true;
                string leftSide = "";
                string rightSide = "";

                for (int j = 0; j < row.Length; j++)
                {
                    if (row[j] == ' ')
                    {
                        isLeft = false;
                        continue;
                    }

                    if (isLeft)
                    {
                        leftSide += row[j];
                    }
                    else
                    {
                        rightSide += row[j];
                    }

                }

                long leftNumber = long.Parse(leftSide);
                long rightNumber = long.Parse(rightSide);
                long selectedNumber = Math.Abs(Math.Max(leftNumber, rightNumber));

                long sum = 0;
                while (selectedNumber != 0)
                {
                    sum += selectedNumber % 10;
                    selectedNumber /= 10;
                }

                Console.WriteLine(sum);
            }
        }
    }
}
