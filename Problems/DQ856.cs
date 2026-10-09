/*
LeetCode daily question #856 https://leetcode.com/problems/score-of-parentheses/description/
*/

namespace Problems.DQ856;

public class Solution
{
    public int ScoreOfParentheses(string s)
    {
        // Save all info pertaining opening brackets
        int[] scores = new int[s.Length / 2];
        int[] depths = new int[s.Length / 2];
        List<int> opBracketsIdxs = new List<int>();

        int depth = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
            {
                if (i + 1 < s.Length && s[i + 1] == ')')    // ()
                {
                    scores[opBracketsIdxs.Count] = 1;
                }

                depths[opBracketsIdxs.Count] = depth++;
                opBracketsIdxs.Add(i);
            }
            else
            {
                depth--;
            }
        }

        for (int j = opBracketsIdxs.Count - 1; j > 0; j--)
        {
            if (scores[j] > 0)
            {
                for (int p = j - 1; p >= 0; p--)
                {
                    if (depths[p] == depths[j] - 1)     // ((
                    {
                        scores[p] += 2 * scores[j];
                        scores[j] = 0;
                        break;
                    }
                }
            }
        }

        int score = 0;
        for (int i = 0; i < scores.Length; i++)     // ()()
        {
            score += scores[i];
        }
        return score;
    }
}