/*
LeetCode daily question #921 https://leetcode.com/problems/minimum-add-to-make-parentheses-valid/description/
*/

namespace Problems.DQ921;

public class Solution
{
    public int MinAddToMakeValid(string s)
    {
        Stack<char> stack = new Stack<char>();  // Allows us to save all open brackets to check for matches
        foreach (char c in s)
        {
            if (stack.Count > 0 && stack.Peek() == '(' && c == ')')
            {
                stack.Pop();
            }
            else
            {
                stack.Push(c);
            }
        }
        return stack.Count;
    }
}