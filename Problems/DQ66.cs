/*
LeetCode daily question #66 https://leetcode.com/problems/plus-one/description/
*/

using System.Globalization;

namespace Problems.DQ66;

public class Solution
{
    // Approach: Copy new digits to a array, adding 1 when needed
    // Time: O(n)   Space: O(n)
    public int[] PlusOne(int[] digits)
    {
        int[] res = new int[digits.Length + 1];
        bool addOne = true;
        for (int i = digits.Length - 1; i >= 0; i--)   // O(n)
        {
            int d = digits[i];
            if (addOne)
            {
                if (d == 9)
                {
                    d = 0;
                }
                else
                {
                    d++;
                    addOne = false;
                }
            }
            res[i + 1] = d;     // O(1)
        }

        if (addOne) res[0] = 1;  // O(1)

        return (res[0] == 0) ? res[1..] : res;
    }
}
