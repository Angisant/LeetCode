/*
LeetCode daily question #3736 https://leetcode.com/problems/minimum-moves-to-equal-array-elements-iii/description/
*/

namespace Problems.DQ3736;

public class Solution
{
    // Approach: Since you can only increment we want to turn all the numbers into the biggest number in the original array
    // Time: O(n)   Space: O(1)
    public int MinMoves(int[] nums)
    {
        int max = nums[0];
        foreach (int num in nums)
        {
            if (num > max)
            {
                max = num;
            }
        }

        int moves = 0;
        foreach (int num in nums)
        {
            moves += max - num;
        }
        return moves;
    }
}
