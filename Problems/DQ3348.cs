/*
LeetCode daily question #3348 https://leetcode.com/problems/smallest-divisible-digit-product-ii/description/
*/

namespace Problems.DQ3348;

public class Solution
{
    public string SmallestNumber(string num, long t)
    {
        long n = long.Parse(num);
        if (!num.Contains('0') && ProductOfDigits(n) % t == 0)
        {
            return num;
        }

        // Check if its possible for the product of digits of any number to be divsible by t
        List<long> primeFactors = PrimeFactors(t);
        if (primeFactors.Any(pf => pf > 7))     // Prime factors can only have values of digits (2, 3, 5, 7)
        {
            return "-1";
        }

        while (true)
        {
            string res = n.ToString();
            if (!res.Contains('0') && ProductOfDigits(n) % t == 0)
            {
                return res;
            }
            n++;
        }
    }

    private long ProductOfDigits(long num)
    {
        int numDigits = num.ToString().Length;
        if (numDigits == 1)
        {
            return num;
        }
        return (num % 10) * ProductOfDigits(num / 10);
    }

    private List<long> PrimeFactors(long n)
    {
        List<long> factors = new List<long>();

        // Handle factor 2 separately
        while (n % 2 == 0)
        {
            factors.Add(2);
            n /= 2;
        }

        // Only test odd numbers (non-divisible by 2)
        for (int i = 3; i * i <= n; i += 2)
        {
            while (n % i == 0)
            {
                factors.Add(i);
                n /= i;
            }
        }

        // Anything left is prime
        if (n > 1)
            factors.Add(n);

        return factors;
    }
}