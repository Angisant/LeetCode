/*
LeetCode daily question #202 https://leetcode.com/problems/happy-number/description/
*/

namespace Problems.DQ202;

public class Solution
{
    // Approach: keep seen sums to know if you're in an infite cycle
    public bool IsHappy(int n)
    {
        HashSet<int> seen = new HashSet<int>();
        while (n != 1)
        {
            int sum = 0, nCopy = n;
            while (nCopy > 0)
            {
                int digit = nCopy % 10;
                sum += digit * digit;
                nCopy /= 10;
            }
            n = sum;

            if (!seen.Add(n)) return false;  // repeated number
        }
        return true;
    }
}
