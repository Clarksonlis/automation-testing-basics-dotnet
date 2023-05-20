﻿using System;

namespace EpamApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input symbols: \n");
            string input = Console.ReadLine();

            int maxConsecutiveUnequalChars = GetMaxConsecutiveUnequalChars(input);

            Console.WriteLine($"The maximum number of unequal consecutive characters is: {maxConsecutiveUnequalChars}");
        }

        // Method to calculate the maximum number of consecutive unequal characters
        private static int GetMaxConsecutiveUnequalChars(string input)
        {
            char[] inputArray = input.ToCharArray();
            int currentNumber = 1;
            int maxNumber = 0;
            int startIndex = 0;

            for (int i = 1; i < inputArray.Length; i++)
            {
                for (int j = i - 1; j >= startIndex; j--)
                {
                    // If a repeating character is found, update the maximum count and reset the current count
                    if (inputArray[j] == inputArray[i])
                    {
                        maxNumber = currentNumber > maxNumber ? currentNumber : maxNumber;
                        currentNumber = 0;
                        startIndex = i;
                        break;
                    }

                }
                currentNumber++;
                maxNumber = currentNumber > maxNumber ? currentNumber : maxNumber;
            }

            return maxNumber;
        }
    }
}



