using System;
using System.Linq;

namespace SubsequenceSolver
{
    public class Solver
    {
        public static string GetLongestIncreasingSubsequence(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }

            int[] nums = input.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries)
                              .Select(int.Parse)
                              .ToArray();

            return GetLongestIncreasingContiguousSequence(nums);
        }

        private static string GetLongestIncreasingContiguousSequence(int[] numbers)
        {
            if (numbers.Length == 0)
            {
                return string.Empty;
            }

            int bestStart = 0;
            int bestLength = 1;
            int currentStart = 0;

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] <= numbers[i - 1])
                {
                    currentStart = i;
                    continue;
                }

                int currentLength = i - currentStart + 1;
                if (currentLength > bestLength)
                {
                    bestStart = currentStart;
                    bestLength = currentLength;
                }
            }

            return string.Join(" ", numbers.Skip(bestStart).Take(bestLength));
        }
    }
}
