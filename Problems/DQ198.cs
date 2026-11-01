/*
LeetCode daily question #198 https://leetcode.com/problems/house-robber/description/
*/

namespace Problems.DQ198;

public class Solution
{
    // [1,2,3,1]
    // H1+H3 or H1+H4 or H2+H4
    public int Rob(int[] nums)
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
