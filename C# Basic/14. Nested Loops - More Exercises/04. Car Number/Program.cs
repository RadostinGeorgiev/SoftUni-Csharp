﻿using System;

namespace _04._Car_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNumber = int.Parse(Console.ReadLine());
            int endNumber = int.Parse(Console.ReadLine());

            for (int i = startNumber; i <= endNumber; i++)
            {
                for (int j = startNumber; j <= endNumber; j++)
                {
                    for (int k = startNumber; k <= endNumber; k++)
                    {
                        for (int l = startNumber; l <= endNumber; l++)
                        {
                            if ((i % 2 == 0 && l % 2 != 0 || 
                                 i % 2 != 0 && l % 2 == 0) && 
                                i > l && (j + k) % 2 == 0)
                            {
                                Console.Write($"{i}{j}{k}{l} ");
                            }
                        }
                    }
                }
            }
        }
    }
}