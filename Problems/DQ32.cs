/*
LeetCode daily question #32 https://leetcode.com/problems/longest-valid-parentheses/description/
*/

namespace Problems.DQ32;

public class Solution
{
    // HINT: Save all invalid symbols' indexes
    public int LongestValidParentheses(string s)
    {
        int maxCount = 0;
        Stack<char> symStack = new Stack<char>();  // Allows us to save all open brackets to check for matches
        Stack<int> idxStack = new Stack<int>();  // Allows us to track all invalid symbols indexes

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (symStack.Count > 0 && symStack.Peek() == '(' && c == ')')
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

        if (idxStack.Count > 0)
        {
            // Since all we have left now on the stacks are evidence of invalid symbols, we will measure the distance between each index
            int lastInvalidIdx = -1;
            while (idxStack.Count > 0)
            {
                int count = (lastInvalidIdx >= 0) ? lastInvalidIdx - idxStack.Peek() - 1 : s.Length - idxStack.Peek() - 1;
                if (count > maxCount)
                {
                    maxCount = count;
                }
                lastInvalidIdx = idxStack.Pop();
            }

            // Account for when string starts with valid substring
            if (lastInvalidIdx > 0 && lastInvalidIdx > maxCount)
            {
                maxCount = lastInvalidIdx;
            }
        }
        else
        {
            maxCount = s.Length;    // There's no invalid symbols
        }
        return maxCount;
    }

    public int LongestValidParentheses_BruteForce(string s)
    {
        int maxCount = 0;
        int startLim = 0, endLim = s.Length - 1;
        DQ20.Solution validator = new DQ20.Solution();

        while (startLim < s.Length && s[startLim] == ')') // Skip all invalid start symbols
        {
            startLim++;
        }

        while (endLim > 0 && s[endLim] == '(') // Skip all invalid end symbols
        {
            endLim--;
        }

        while (endLim - startLim > maxCount)
        {
            for (int n = 0; n <= endLim - startLim; n++)
            {
                for (int i = startLim + n; i <= endLim; i++)
                {
                    string subStr = s.Substring(i, endLim - i + 1);
                    if (subStr.Length > maxCount && validator.IsValid(subStr))
                    {
                        maxCount = subStr.Length;
                    }
                }
            }
            endLim--;
        }
        return maxCount;
    }
}