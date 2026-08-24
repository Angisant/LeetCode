/*
LeetCode daily question #3345 https://leetcode.com/problems/smallest-divisible-digit-product-i/description/
*/

namespace Problems.DQ3345;

public class Solution
{
    public int SmallestNumber(int n, int t)
    {
        for (int num = n; num <= 100; num++)
        {
            if (ProductOfDigits(num) % t == 0) return num;
        }
        return -1;
    }

    private int ProductOfDigits(int num)
    {
        int numDigits = num.ToString().Length;
        if (numDigits == 1)
        {
            return num;
        }
        return (num % 10) * ProductOfDigits(num / 10);
    }
}