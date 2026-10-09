/*
LeetCode daily question #3498 https://leetcode.com/problems/reverse-degree-of-a-string/description/
*/

namespace Problems.DQ3498;

public class Solution
{
    public int ReverseDegree(string s)
    {
        int total = 0;
        for (int i = 0; i < s.Length; i++)
        {
            total += (26 - (s[i] - 'a')) * (i + 1);
        }
        return total;
    }
}