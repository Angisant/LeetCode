/*
LeetCode daily question #3903 https://leetcode.com/problems/smallest-stable-index-i/description/
*/

namespace Problems.DQ3903;

public class Solution
{

    public int FirstStableIndex(int[] nums, int k)
    {
        var sortedIdxs = nums.Select((el, i) => new { Index = i, Value = el }).OrderBy(e => e.Value).ToList();
        int max = -1;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > max) max = nums[i];   // max from 0 to i

            int min = 0;
            foreach (var el in sortedIdxs)      // min from i to n-1
            {
                if (el.Index >= i)              // Values are already sorted so we have to look for the first with the right idx
                {
                    min = el.Value;
                    if (max - min <= k) return i;
                    break;
                }
            }
        }
        return -1;
    }

    // Faster solution. Precompute the maxs and mins first
    public int FirstStableIndex2(int[] nums, int k)
    {
        int[] maxs = new int[nums.Length];
        int[] mins = new int[nums.Length];
        int min = nums[nums.Length - 1], max = nums[0];
        for (int i = 0; i < nums.Length; i++)
        {
            int possibleMax = nums[i];
            int possibleMin = nums[nums.Length - 1 - i];

            if (possibleMax > max)
            {
                max = possibleMax;
            }
            maxs[i] = max;

            if (possibleMin < min)
            {
                min = possibleMin;
            }
            mins[nums.Length - 1 - i] = min;
        }
        for (int i = 0; i < nums.Length; i++)
        {
            if (maxs[i] - mins[i] <= k) return i;
        }
        return -1;
    }
}