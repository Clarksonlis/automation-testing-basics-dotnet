using NUnit.Framework;
using Unit_test_frameworks_Task.Algorithms;

namespace EpamApp1.Tests
{
    public class ProgramTests
    {
        [TestCase("abbccdefggg", ExpectedResult = "cdefg")]
        [TestCase("abccdefg", ExpectedResult = "cdefg")]
        [TestCase("a", ExpectedResult = "a")]
        [TestCase("ab", ExpectedResult = "ab")]
        [TestCase("abc", ExpectedResult = "abc")]
        [TestCase("", ExpectedResult = "")]
        [TestCase(" ", ExpectedResult = " ")]
        public string GetMaxConsecutiveUnequalChars_ShouldReturnMaxConsecutiveUnequalChars(string input)
        {
            // Arrange
            MaxConsecutiveUnequalChars maxConsecutiveUnequalChars = new MaxConsecutiveUnequalChars(input);

            // Act
            string result = maxConsecutiveUnequalChars.Execute();

            // Assert
            return result;
        }

        [TestCase("aBbcCcDdefgggg", ExpectedResult = 4)]
        [TestCase("abcccCDefG", ExpectedResult = 3)]
        [TestCase("AbbB", ExpectedResult = 2)]
        [TestCase("ABb", ExpectedResult = 1)]
        [TestCase("A", ExpectedResult = 1)]
        [TestCase("", ExpectedResult = 0)]
        [TestCase(" ", ExpectedResult = 0)]
        public int GetMaxConsecutiveLatinChars_ShouldReturnMaxConsecutiveLatinChars(string input)
        {
            // Arrange
            MaxConsecutiveLatinChars maxConsecutiveLatinChars = new MaxConsecutiveLatinChars(input);

            // Act
            string result = maxConsecutiveLatinChars.Execute();

            // Assert
            return int.Parse(result);
        }

        [TestCase("12234445", ExpectedResult = 3)]
        [TestCase("111", ExpectedResult = 3)]
        [TestCase("11111", ExpectedResult = 5)]
        [TestCase("0123456789", ExpectedResult = 1)]
        [TestCase("1", ExpectedResult = 1)]
        [TestCase("a", ExpectedResult = 0)]
        [TestCase("", ExpectedResult = 0)]
        [TestCase(" ", ExpectedResult = 0)]
        public int GetMaxConsecutiveDigits_ShouldReturnMaxConsecutiveDigits(string input)
        {
            // Arrange
            MaxConsecutiveDigits maxConsecutiveDigits = new MaxConsecutiveDigits(input);

            // Act
            string result = maxConsecutiveDigits.Execute();

            // Assert
            return int.Parse(result);
        }
    }
}