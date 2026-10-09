/*
LeetCode daily question #3550 https://leetcode.com/problems/smallest-index-with-digit-sum-equal-to-index/description/
*/

namespace Problems.DQ3550;

public class Solution
{
    public int SmallestIndex(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            int sum = 0, n = nums[i];
            if (n < 10)
            {
                sum = n;
            }
            else
            {
                while (n > 0)
                {
                    sum += n % 10;
                    n /= 10;
                }
            }
            if (sum == i) return i;
        }
        return -1;
    }
}