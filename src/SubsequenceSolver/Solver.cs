using System;
using System.Collections.Generic;
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

            int n = nums.Length;
            if (n == 0) return string.Empty;

            int[] sortedValues = nums.Distinct().Order().ToArray();
            int[] suffixLengths = new int[n];
            int[] fenwickTree = new int[sortedValues.Length + 1];

            for (int i = n - 1; i >= 0; i--)
            {
                int rank = Array.BinarySearch(sortedValues, nums[i]);
                int reversedRank = sortedValues.Length - rank;
                suffixLengths[i] = 1 + Query(fenwickTree, reversedRank - 1);
                Update(fenwickTree, reversedRank, suffixLengths[i]);
            }

            int remaining = suffixLengths.Max();
            List<int> resultPath = new List<int>(remaining);
            int lastValue = 0;
            bool hasLastValue = false;

            for (int i = 0; i < n && remaining > 0; i++)
            {
                if ((!hasLastValue || nums[i] > lastValue) && suffixLengths[i] >= remaining)
                {
                    resultPath.Add(nums[i]);
                    lastValue = nums[i];
                    hasLastValue = true;
                    remaining--;
                }
            }

            return string.Join(" ", resultPath);
        }

        private static int Query(int[] tree, int index)
        {
            int maxLength = 0;

            while (index > 0)
            {
                maxLength = Math.Max(maxLength, tree[index]);
                index -= index & -index;
            }

            return maxLength;
        }

        private static void Update(int[] tree, int index, int value)
        {
            while (index < tree.Length)
            {
                tree[index] = Math.Max(tree[index], value);
                index += index & -index;
            }
        }
    }
}
