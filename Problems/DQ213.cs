/*
LeetCode daily question #213 https://leetcode.com/problems/house-robber-ii/description/
*/

namespace Problems.DQ213;

public class Solution
{
    public int Rob(int[] nums)
    {
        if (nums.Length < 2) return nums[0];

        int firstRob = RobI(nums[0..(nums.Length - 1)]);  // Rob H(1) until H(n-1)
        int lastRob = RobI(nums[1..]);  // Rob H(2) until H(n)
        return (firstRob > lastRob) ? firstRob : lastRob;
    }

    private int RobI(int[] nums)
    {
        int[] rob = new int[nums.Length];
        rob[0] = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            int yRob = nums[i] + (i > 1 ? rob[i - 2] : 0);  // Rob H(i) + H(i-2)
            int nRob = rob[i - 1];    // Rob previous house
            rob[i] = (yRob > nRob) ? yRob : nRob;
        }
        return rob[nums.Length - 1];
    }
}
