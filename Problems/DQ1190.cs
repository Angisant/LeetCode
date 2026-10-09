/*
LeetCode daily question #1190 https://leetcode.com/problems/reverse-substrings-between-each-pair-of-parentheses/description/
*/

using System.Text;

namespace Problems.DQ1190;

public class Solution
{
    // Efficient ways to reverse string: https://www.reddit.com/r/csharp/comments/gm0uhc/efficient_ways_to_reverse_a_string_or_int_in_c/
    public string ReverseParentheses(string s)
    {
        string str = new string(s);
        Stack<int> opParIdxs = new Stack<int>();
        int i = -1;
        for (int j = 0; j < s.Length; j++)
        {
            if (s[j] == '(')
            {
                opParIdxs.Push(j);     // Save all ( indexes
            }
        }

        if (opParIdxs.Count > 0)
        {
            i = opParIdxs.Peek() + 1;   // Get to last ( 
        }

        while (opParIdxs.Count > 0)
        {
            char c = str[i];
            switch (c)
            {
                case '(':   // String start
                    opParIdxs.Push(i);
                    i++;
                    break;
                case ')':   // String end
                    int startParIdx = opParIdxs.Pop();
                    string revStr = StringCreateReverse(str.Substring(startParIdx + 1, i - startParIdx - 1));
                    string startStr = str.Substring(0, startParIdx);
                    string endStr = str.Substring(i + 1, str.Length - i - 1);
                    str = startStr + revStr + endStr;

                    if (opParIdxs.Count > 0)
                    {
                        i = opParIdxs.Peek() + 1;   // Get to last ( 
                    }
                    break;
                default:
                    i++;
                    break;
            }
        }
        return str;
    }

    private string StringCreateReverse(string s)
    {
        var reversed = string.Create(s.Length, s, (chars, state) =>
        {
            var pos = 0;
            for (int i = state.Length - 1; i >= 0; i--)
            {
                chars[pos++] = state[i];
            }
        });
        return reversed;
    }
}