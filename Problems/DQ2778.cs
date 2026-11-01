/*
LeetCode daily question #2778 https://leetcode.com/problems/sum-of-squares-of-special-elements/description/
*/

namespace Problems.DQ2778;

public class Solution
{
    public int SumOfSquares(int[] nums)
    {
        int sum = 0, n = nums.Length;
        for (int i = 0; i < n; i++)
        {
            if (n % (i + 1) == 0)      // Remember that its a 1-indexed array!!
            {
                sum += nums[i] * nums[i];
            }
        }
        return sum;
    }
}