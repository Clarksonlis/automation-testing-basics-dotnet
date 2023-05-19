using System;

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



