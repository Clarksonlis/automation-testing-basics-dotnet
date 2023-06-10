using System;

public class MaxConsecutiveUnequalChars : BaseAlgorithm
{
    public MaxConsecutiveUnequalChars(string input) : base(input)
    {
    }

    public override string Execute()
    {
        char[] inputArray = _input;

        if (inputArray.Length == 0)
        {
            return string.Empty;
        }

        int currentNumber = 1;
        string currentSequence = inputArray[0].ToString();
        string maxSequence = inputArray[0].ToString();
        int startIndex = 0;

        for (int i = 1; i < inputArray.Length; i++)
        {
            for (int j = i - 1; j >= startIndex; j--)
            {
                if (AreEqual(inputArray[j], inputArray[i]))
                {
                    maxSequence = maxSequence.Length > currentSequence.Length ? maxSequence : currentSequence;
                    currentSequence = string.Empty;
                    currentNumber = 0;
                    startIndex = i;
                    break;
                }
            }

            currentSequence += inputArray[i].ToString();
            maxSequence = maxSequence.Length > currentSequence.Length ? maxSequence : currentSequence;
            currentNumber++;
        }

        return maxSequence;
    }

    public override bool AreEqual(char symbol1, char symbol2)
    {
        return symbol1 == symbol2;
    }
}