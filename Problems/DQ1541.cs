/*
LeetCode daily question #1541 https://leetcode.com/problems/minimum-insertions-to-balance-a-parentheses-string/description/
*/

namespace Problems.DQ1541;

public class Solution
{
    // TODO: FIX
    public int MinInsertions(string s)
    {
        Stack<char> stack = new Stack<char>();  // Allows us to save all open brackets to check for matches
        bool isPartialParentheses = false;  // Check if last characters from ()
        bool hadClosed = false;     // Check if last character was (
        int res = 0;
        foreach (char c in s)
        {
            if (c == '(')
            {
                if (isPartialParentheses)   // ()(
                {
                    res++;
                    isPartialParentheses = false;
                }
                stack.Push(c);
            }
            else
            {
                if (isPartialParentheses)   // ())
                {
                    isPartialParentheses = false;
                }
                else if (stack.Count > 0)   // ()
                {
                    isPartialParentheses = true;
                    stack.Pop();    // Remove corresponding (
                }
                else if (stack.Count == 0 && hadClosed)     // ))
                {
                    res++;
                    hadClosed = false;
                }
                else
                {
                    hadClosed = true;   // Save that ) was the last character
                }
            }
        }

        if (isPartialParentheses) res++;    // For the final (), there should be )

        if (hadClosed) res += 2;   // For the final ), there should be ()

        res += stack.Count * 2;   // For every (, there should be ))

        return res;
    }
}