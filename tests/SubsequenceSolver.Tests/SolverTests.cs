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

        [Fact]
        public void Test_EmptyOrNullInput_ReturnsEmptyString()
        {
            Assert.Equal(string.Empty, Solver.GetLongestIncreasingSubsequence(""));
            Assert.Equal(string.Empty, Solver.GetLongestIncreasingSubsequence("   "));
        }

        [Fact]
        public void Test_TieBreaker_ReturnsEarliestLongestSequence()
        {
            string input = "1 10 2 20";
            string expected = "1 10 20";

            string result = Solver.GetLongestIncreasingSubsequence(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test_StrictlyDecreasing_ReturnsFirstElementOnly()
        {
            string input = "10 9 8 7";
            string expected = "10";

            string result = Solver.GetLongestIncreasingSubsequence(input);

            Assert.Equal(expected, result);
        }
    }
}
