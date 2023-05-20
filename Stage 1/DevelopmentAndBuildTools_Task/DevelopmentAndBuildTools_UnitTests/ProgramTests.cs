using DevelopmentAndBuildTools;

namespace DevelopmentAndBuildTools_UnitTests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("", 0)]
    [TestCase(" ", 1)]
    [TestCase("abc", 3)]
    [TestCase("abcd", 4)]
    [TestCase("AabB", 4)]
    public void GetMaxConsecutiveUnequalChars_StringInput_CharactersLength(string input, int expectedResult)
    {
        int result = Program.GetMaxConsecutiveUnequalChars(input);

        Assert.AreEqual(expectedResult, result);
    }
}