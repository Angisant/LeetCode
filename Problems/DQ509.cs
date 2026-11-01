/*
LeetCode daily question #509 https://leetcode.com/problems/predict-the-winner/description/
*/

namespace Problems.DQ509;

public class Solution
{
    /*
    * F(0) = 0, F(1) = 1
    * F(n) = F(n - 1) + F(n - 2), for n > 1.
    */
    public int Fib(int n)
    {
        int fib = (n >= 1) ? 1 : 0;
        if (n > 1)
        {
            for (int i = 2; i <= n; i++)
            {
                fib += fib;
            }
        }
        return fib;
    }

    public int Fib_Recursive(int n)
    {
        if (n == 0 || n == 1)
        {
            return n;
        }
        return Fib_Recursive(n - 1) + Fib_Recursive(n - 2);
    }
}