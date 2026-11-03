/*
LeetCode daily question #462 https://leetcode.com/problems/minimum-moves-to-equal-array-elements-ii/description/
*/

namespace Problems.DQ462;

public class Solution
{
    // Approach: Nº moves to increase/decrease one element until they are all equal. Find the halfway value
    // Time: O(nlogn)   Space: O(1) when not counting input
    public int MinMoves2(int[] nums)
    {
        Array.Sort(nums);   // O(nlogn)
        int inc = 0, mid = nums[nums.Length / 2];

        for (int i = 0; i < nums.Length / 2; i++)   // O(n/2)
        {
            inc += mid - nums[i];
            inc += nums[nums.Length - 1 - i] - mid;
        }
        return inc;
    }
}
