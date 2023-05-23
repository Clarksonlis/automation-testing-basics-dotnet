using DevelopmentAndBuildTools;

namespace DevelopmentAndBuildTools_UnitTests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }


    [TestCase("", "")]
    [TestCase(" ", " ")]
    [TestCase("abc", "abc")]
    [TestCase("abcb", "abc")]
    [TestCase("AabB", "AabB")]
    [TestCase("AbCklOAklfjsp", "Aklfjsp")]
    public void Test1(string input, string expectedResult)
    {
        string result = Program.GetMaxConsecutiveUnequalChars(input);

        Assert.AreEqual(expectedResult, result);
    }
}