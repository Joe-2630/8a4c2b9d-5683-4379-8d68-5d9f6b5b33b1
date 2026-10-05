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

            int[] lis = new int[n];
            int[] parent = new int[n];

            for (int i = 0; i < n; i++)
            {
                lis[i] = 1;
                parent[i] = -1;
            }

            int maxLength = 1;
            int bestEndIndex = 0;

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j] && lis[j] + 1 > lis[i])
                    {
                        lis[i] = lis[j] + 1;
                        parent[i] = j;
                    }
                }

                if (lis[i] > maxLength)
                {
                    maxLength = lis[i];
                    bestEndIndex = i;
                }
            }

            List<int> resultPath = new List<int>();
            int curr = bestEndIndex;
            while (curr != -1)
            {
                resultPath.Add(nums[curr]);
                curr = parent[curr];
            }

            resultPath.Reverse();

            return string.Join(" ", resultPath);
        }
    }
}
