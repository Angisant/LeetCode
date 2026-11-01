/*
LeetCode daily question #50 https://leetcode.com/problems/powx-n/description/
*/

namespace Problems.DQ50;

public class Solution
{
    public double MyPow(double x, int n)
    {
        long pow = n < 0 ? -(long)n : n;
        double res = 1;
        while (pow > 0)
        {
            if (pow % 2 == 1) res *= x;

            x *= x;
            pow /= 2;
        }
        return n < 0 ? 1 / res : res;
    }
}
