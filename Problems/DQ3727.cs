/*
LeetCode daily question #3727 https://leetcode.com/problems/maximum-alternating-sum-of-squares/description/
*/

namespace Problems.DQ3727;

public class Solution
{
    public long MaxAlternatingSum(int[] nums)
    {
        long max = 0;
        int i = 0, j = nums.Length - 1;
        var ordSqrs = nums.Select(n => (long)n * n).Order().ToList();

        while (i < j)
        {
            max += ordSqrs[j];
            max -= ordSqrs[i];
            j--;
            i++;
        }
        if (i == j) max += ordSqrs[j];

        return max;
    }
}