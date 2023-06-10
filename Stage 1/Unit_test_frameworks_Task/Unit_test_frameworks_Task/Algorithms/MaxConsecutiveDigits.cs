using System;

namespace Unit_test_frameworks_Task.Algorithms
{
    public class MaxConsecutiveDigits : BaseAlgorithm
    {
        public MaxConsecutiveDigits(string input)
            : base(input)
        {
        }

        public override string Execute()
        {
            int maxNumber = 0;
            int currentNumber = 0;
            char previousChar = '\0';

            foreach (char currentChar in _input)
            {
                if (char.IsDigit(currentChar))
                {
                    if (currentChar == previousChar)
                    {
                        currentNumber++;
                    }
                    else
                    {
                        currentNumber = 1;
                        previousChar = currentChar;
                    }

                    maxNumber = Math.Max(maxNumber, currentNumber);
                }
            }

            return maxNumber.ToString();
        }
    }
}