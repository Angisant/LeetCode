/*
LeetCode daily question #1021 https://leetcode.com/problems/remove-outermost-parentheses/description/
*/

using System.Text;

namespace Problems.DQ1021;

public class Solution
{
    public string RemoveOuterParentheses(string s)
    {
        StringBuilder sb = new StringBuilder();
        int depth = 0;
        foreach (char c in s)
        {
            if (c == '(')
            {
                depth++;
                if (depth > 1) sb.Append(c);
            }
            else
            {
                if (depth > 1) sb.Append(c);
                depth--;
            }
        }
        return sb.ToString();
    }
}