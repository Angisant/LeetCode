/*
LeetCode daily question #301 https://leetcode.com/problems/remove-invalid-parentheses/description/
*/

namespace Problems.DQ301;

public class Solution
{
    public IList<string> RemoveInvalidParentheses(string s)
    {
        IList<string> res = new List<string>();
        int minRemovals = MinRemToMakeValid(s);

        if (minRemovals == 0)
        {
            return new List<string> { s };
        }
        else if (minRemovals == s.Length)
        {
            return new List<string> { "" };
        }

        List<string> strings = new List<string> { s };
        for (int r = 1; r <= minRemovals; r++)
        {
            HashSet<string> tmp = new HashSet<string>();
            foreach (string str in strings)
            {
                foreach (string t in RemoveOneParentheses(str))
                {
                    tmp.Add(t);
                }
            }
            strings = tmp.ToList();
        }

        // See if there are any valid strings after r removals
        foreach (string str in strings)
        {
            if (MinRemToMakeValid(str) == 0)    // Is it valid?
            {
                res.Add(str);
            }
        }
        return res;
    }

    private IList<string> RemoveOneParentheses(string s)
    {
        IList<string> res = new List<string>();
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(' || s[i] == ')')
            {
                res.Add(s.Remove(i, 1));
            }
        }
        return res;
    }

    private int MinRemToMakeValid(string s)
    {
        Stack<char> stack = new Stack<char>();  // Allows us to save all open brackets to check for matches
        foreach (char c in s)
        {
            if (c == '(' || c == ')')
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
        }
        return stack.Count;
    }
}