/*
LeetCode daily question #70 https://leetcode.com/problems/climbing-stairs/description/
*/

namespace Problems.DQ70;

public class Solution
{
    // S1: 1 => 1 ways
    // S2: 1 + 1 or 2 <=> S1 + 1 or 2 => 2 ways
    // S3: (1 + 1) + 1 or (2) + 1 or 1 + 2 <=> S2 + 1 or 1 + 2 => 3 ways
    // S4: 1 + 1 + 1 + 1 or 1 + 1 + 2 or 1 + 2 + 1 or 2 + 1 + 1 or 2 + 2 => 5 ways
    public int ClimbStairs(int n)
    {
        int[] ways = new int[n + 1];
        ways[0] = 1;
        ways[1] = 1;

        for (int i = 2; i <= n; i++)
        {
            ways[i] = ways[i - 1] + ways[i - 2];
        }
        return ways[n];
    }
}
