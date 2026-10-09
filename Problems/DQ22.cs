/*
LeetCode daily question #22 https://leetcode.com/problems/generate-parentheses/description/
*/

namespace Problems.DQ22;

public class Solution
{
    public IList<string> GenerateParenthesis(int n)
    {
        List<char[]> combinations = new List<char[]>();

        char[] comb = new char[n * 2];
        comb[0] = '(';  // First position will always have (
        comb[n * 2 - 1] = ')';  // Last position will always have )
        combinations.Add(comb);

        for (int i = 1; i < n * 2 - 1; i++)
        {
            int count = combinations.Count;
            for (int j = 0; j < count; j++)
            {
                char[] c = combinations[j];
                char[] c2 = new char[c.Length];
                Array.Copy(c, c2, c.Length);

                // We can only ever add ( or )
                c[i] = '(';
                c2[i] = ')';

                combinations.Add(c2);
            }
        }
        return combinations.Select(c => new string(c)).Where(c => IsValid(c)).ToList(); // Turn each one to string and validate
    }

    // TO DO: Use recursion with backtracking
    public IList<string> GenerateParenthesis2(int n)
    {
        List<char[]> combinations = new List<char[]>();

        char[] comb = new char[n * 2];
        comb[0] = '(';  // First position will always have (
        comb[n * 2 - 1] = ')';  // Last position will always have )
        combinations.Add(comb);

        for (int i = 1; i < n * 2 - 1; i++)
        {
            int count = combinations.Count;
            for (int j = 0; j < count; j++)
            {
                char[] c = combinations[j];
                char[] c2 = new char[c.Length];
                Array.Copy(c, c2, c.Length);

                // We can only ever add ( or )
                c[i] = '(';
                c2[i] = ')';

                combinations.Add(c2);
            }
        }
        return combinations.Select(c => new string(c)).ToList(); // Turn each one to string and validate
    }

    // Copied from DQ20
    private bool IsValid(string s)
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

    private bool IsCorrespondingBrackets(char b1, char b2)
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