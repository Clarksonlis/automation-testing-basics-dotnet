using System;
using EpamApp1;
using Unit_test_frameworks_Task.Algorithms;

namespace EpamApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Input symbols: ");
            string input = Console.ReadLine();

            MaxConsecutiveUnequalChars maxConsecutiveUnequalChars = new MaxConsecutiveUnequalChars(input);
            MaxConsecutiveLatinChars maxConsecutiveLatinChars = new MaxConsecutiveLatinChars(input);
            MaxConsecutiveDigits maxConsecutiveDigits = new MaxConsecutiveDigits(input);

            string maxConsecutiveUnequalCharsResult = maxConsecutiveUnequalChars.Execute();
            string maxConsecutiveLatinCharsResult = maxConsecutiveLatinChars.Execute();
            string maxConsecutiveDigitsResult = maxConsecutiveDigits.Execute();

            Console.WriteLine($"The maximum number of unequal consecutive characters is: {maxConsecutiveUnequalCharsResult.Length}");
            Console.WriteLine($"The characters are: {maxConsecutiveUnequalCharsResult}");
            Console.WriteLine($"The maximum number of consecutive identical Latin letters is: {maxConsecutiveLatinCharsResult}");
            Console.WriteLine($"The maximum number of consecutive identical digits is: {maxConsecutiveDigitsResult}");
        }
    }
}