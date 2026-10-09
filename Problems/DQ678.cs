/*
LeetCode daily question #678 https://leetcode.com/problems/valid-parenthesis-string/description/
*/

namespace Problems.DQ678;

public class Solution
{
    public bool CheckValidString(string s)
    {
        Stack<char> symStack = new Stack<char>();  // Allows us to save all open brackets to check for matches
        Stack<int> idxStack = new Stack<int>();  // Allows us to track all invalid symbols indexes
        List<int> missSymsIdxs = new List<int>();    // Save all * indexes
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (c != '*')
            {
                if (symStack.Count > 0 && IsCorrespondingBrackets(symStack.Peek(), c))
                {
                    symStack.Pop();
                    idxStack.Pop();     // remove valid symbol index
                }
                else
                {
                    symStack.Push(c);
                    idxStack.Push(i);
                }
            }
            else
            {
                missSymsIdxs.Add(i);
            }
        }

        if (symStack.Count == 0) return true;   // string is already valid so all * could turn into "

        if (missSymsIdxs.Count < symStack.Count) return false;     // Amount of * should atleast be the same as remaining symbols

        while (symStack.Count > 0)
        {
            char sym = symStack.Pop();
            int symIdx = idxStack.Pop();

            if (sym == ')')
            {
                int starIdx = missSymsIdxs.FindLastIndex(s => s < symIdx);
                if (starIdx == -1) return false;

                missSymsIdxs.RemoveAt(starIdx);
            }
            else
            {
                int starIdx = missSymsIdxs.FindLastIndex(s => s > symIdx);
                if (starIdx == -1) return false;

                missSymsIdxs.RemoveAt(starIdx);
            }
        }
        return true;
    }

    // Copied from DQ20
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