using Xunit;

namespace SubsequenceSolver.Tests
{
    public class SolverTests
    {
        [Fact]
        public void Test_ProvidedTestCase_ReturnsCorrectSequence()
        {
            string input = "6 1 5 9 2";
            string expected = "1 5 9";

            string result = Solver.GetLongestIncreasingSubsequence(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("case-2.txt", "case-2-output.txt")]
        [InlineData("case-3.txt", "case-3-output.txt")]
        [InlineData("case-4.txt", "case-4-output.txt")]
        [InlineData("case-5.txt", "case-5-output.txt")]
        [InlineData("case-6.txt", "case-6-output.txt")]
        [InlineData("case-7.txt", "case-7-output.txt")]
        [InlineData("case-8.txt", "case-8-output.txt")]
        [InlineData("case-9.txt", "case-9-output.txt")]
        public void Test_LargeProvidedInput_ReturnsExpectedSequence(string inputFile, string expectedFile)
        {
            string testDataPath = Path.Combine(AppContext.BaseDirectory, "TestData");
            string input = File.ReadAllText(Path.Combine(testDataPath, inputFile));
            string expected = File.ReadAllText(Path.Combine(testDataPath, expectedFile)).Trim();

            string result = Solver.GetLongestIncreasingSubsequence(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("6 2 4 6 1 5 9 2", "2 4 6")]
        [InlineData("6 2 4 3 1 5 9", "1 5 9")]
        public void Test_AdditionalProvidedCases_ReturnExpectedSequence(string input, string expected)
        {
            string result = Solver.GetLongestIncreasingSubsequence(input);

            Assert.Equal(expected, result);
        }
    }
}
