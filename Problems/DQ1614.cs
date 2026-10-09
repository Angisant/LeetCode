/*
LeetCode daily question #1614 https://leetcode.com/problems/maximum-nesting-depth-of-the-parentheses/description/
*/

namespace Problems.DQ1614;

public class Solution
{
    public int MaxDepth(string s)
    {
        int currDepth = 0, maxDepth = 0;
        foreach (char c in s)
        {
            if (c == '(')   // Enter level
            {
                currDepth++;
                if (currDepth > maxDepth)
                {
                    maxDepth = currDepth;
                }
            }
            else if (c == ')')  // Exit level
            {
                currDepth--;
            }
        }
        return maxDepth;
    }
}