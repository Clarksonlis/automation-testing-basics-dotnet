using NUnit.Framework;
using Unit_test_frameworks_Task.Algorithms;

namespace EpamApp1.Tests
{
    public class ProgramTests
    {
        [TestCase("1abbccdefgggg222", ExpectedResult = "cdefg")]
        [TestCase("abcccCDefG222", ExpectedResult = "cCDefG2")]
        [TestCase("AAAaaA222a2", ExpectedResult = "aA2")]
        [TestCase("ABC", ExpectedResult = "ABC")]
        [TestCase("A2", ExpectedResult = "A2")]
        [TestCase("abcc", ExpectedResult = "abc")]
        [TestCase("1234566", ExpectedResult = "123456")]
        [TestCase("", ExpectedResult = "")]
        [TestCase(" ", ExpectedResult = " ")]
        [TestCase(".", ExpectedResult = ".")]

        public string GetMaxConsecutiveUnequalChars_ShouldReturnMaxConsecutiveUnequalChars(string input)
        {
            // Arrange
            MaxConsecutiveUnequalChars maxConsecutiveUnequalChars = new MaxConsecutiveUnequalChars(input);

            // Act
            string result = maxConsecutiveUnequalChars.Execute();

            // Assert
            return result;
        }

        [TestCase("1abbccdefgggg222", ExpectedResult = 4)]
        [TestCase("abcccCDefG222", ExpectedResult = 3)]
        [TestCase("AAAaaA222aa2", ExpectedResult = 3)]
        [TestCase("ABC", ExpectedResult = 1)]
        [TestCase("A2", ExpectedResult = 1)]
        [TestCase("abcc", ExpectedResult = 2)]
        [TestCase("1234566", ExpectedResult = 0)]
        [TestCase("", ExpectedResult = 0)]
        [TestCase(" ", ExpectedResult = 0)]
        [TestCase(".", ExpectedResult = 0)]
        public int GetMaxConsecutiveLatinChars_ShouldReturnMaxConsecutiveLatinChars(string input)
        {
            // Arrange
            MaxConsecutiveLatinChars maxConsecutiveLatinChars = new MaxConsecutiveLatinChars(input);

            // Act
            string result = maxConsecutiveLatinChars.Execute();

            // Assert
            return int.Parse(result);
        }

        [TestCase("1abbccdefgggg222", ExpectedResult = 3)]
        [TestCase("abcccCDefG222", ExpectedResult = 3)]
        [TestCase("AAAaaA222aa2", ExpectedResult = 3)]
        [TestCase("ABC", ExpectedResult = 0)]
        [TestCase("A2", ExpectedResult = 1)]
        [TestCase("abcc", ExpectedResult = 0)]
        [TestCase("1234566", ExpectedResult = 2)]
        [TestCase("", ExpectedResult = 0)]
        [TestCase(" ", ExpectedResult = 0)]
        [TestCase(".", ExpectedResult = 0)]
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