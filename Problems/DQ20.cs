/*
LeetCode daily question #20 https://leetcode.com/problems/valid-parentheses/description/
*/

namespace Problems.DQ20;

public class Solution
{
    public bool IsValid(string s)
    {
        if (s.Length % 2 != 0) return false;   // Must have even number of brackets to form pairs

        Stack<char> stack = new Stack<char>();  // Allows us to save all open brackets to check for matches

        foreach (char c in s)
        {
            if (stack.Count > 0 && IsCorrespondingBrackets(stack.Peek(), c))
            {
                stack.Pop();
            }
            else
            {
                stack.Push(c);
            }
        }
        return stack.Count == 0;
    }

    public bool IsCorrespondingBrackets(char b1, char b2)
    {
        switch (b1)
        {
            case '(':
                return b2 == ')';
            case '{':
                return b2 == '}';
            case '[':
                return b2 == ']';
            default:
                return false;
        }
    }
}