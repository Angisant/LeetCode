/*
LeetCode daily question #1758 https://leetcode.com/problems/minimum-changes-to-make-alternating-binary-string/description/
*/

namespace Problems.DQ1758;

public class Solution
{
    public int MinOperations(string s)
    {
        int minOperations = 0;
        if (s.Length > 1 && (s.Contains("00") || s.Contains("11")))
        {
            // final string will either start with 0 or 1
            string finalString1 = string.Concat(Enumerable.Repeat("01", s.Length / 2));
            string finalString2 = string.Concat(Enumerable.Repeat("10", s.Length / 2));
            if (s.Length % 2 != 0)
            {
                finalString1 += "0";
                finalString2 += "1";
            }

            int minOperations1 = 0, minOperations2 = 0;
            for (int i = 0; i < s.Length; i++)
            {
                minOperations1 = (s[i] != finalString1[i]) ? minOperations1 + 1 : minOperations1;
                minOperations2 = (s[i] != finalString2[i]) ? minOperations2 + 1 : minOperations2;
            }
            minOperations = (minOperations1 <= minOperations2) ? minOperations1 : minOperations2;
        }
        return minOperations;
    }
}