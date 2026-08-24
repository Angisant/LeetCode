/*
LeetCode Arithmetic & Basic Reasoning https://leetcode.com/problems/can-make-arithmetic-progression-from-sequence/description/
*/

using System.Drawing;

namespace Problems.Arithmetic;

public class Solution
{
    public bool CanMakeArithmeticProgression(int[] arr)
    {
        if (arr.Length > 2)
        {
            Array.Sort(arr);
            int interval = arr[1] - arr[0];
            for (int i = 1; i < arr.Length - 1; i++)
            {
                if ((arr[i + 1] - arr[i]) != interval)
                {
                    return false;
                }
            }

        }
        return true;
    }

    public int PivotInteger(int n)
    {
        int pivot = 1;
        int leftRangeSum = Enumerable.Range(1, pivot).Sum();
        int rightRangeSum = Enumerable.Range(pivot, n - pivot + 1).Sum();
        while (leftRangeSum <= rightRangeSum)
        {
            if (leftRangeSum == rightRangeSum)
            {
                return pivot;
            }
            else
            {
                rightRangeSum -= pivot;
                pivot++;
                leftRangeSum += pivot;
            }
        }
        return -1;
    }

    public bool IsPalindrome(int x)
    {
        if (x < 0)
        {
            return false;
        }
        else
        {
            string str = x.ToString();
            for (int i = 0; i <= str.Length / 2; i++)
            {
                if (str[i] != str[str.Length - (i + 1)])
                {
                    return false;
                }
            }
            return true;
        }
    }


    public int Reverse(int x)
    {
        // Transform into string and reverse it
        if (x <= -Math.Pow(2, 31) || x >= Math.Pow(2, 31) - 1)
        {
            return 0;
        }
        string reverseStr = Math.Abs(x).ToString();
        char[] charArray = reverseStr.ToCharArray();
        Array.Reverse(charArray);
        reverseStr = new string(charArray);
        if (!Int32.TryParse(reverseStr, out int parsedInt))
        {
            return 0;
        }
        return (x >= 0) ? parsedInt : -parsedInt;
    }

    public bool IsUgly(int n)
    {
        if (n <= 0) return false;

        List<int> factors = PrimeFactors(n);
        foreach (int f in factors)
        {
            if (f != 2 && f != 3 && f != 5) return false;
        }
        return true;
    }

    private List<int> PrimeFactors(int n)
    {
        List<int> factors = new List<int>();

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

    public int SmallestRepunitDivByK(int k)
    {
        if (k % 2 == 0 || k % 5 == 0) return -1;
        {
            long n = 1;
            for (int i = k; k > 0; i--)
            {
                if (n % k == 0)
                {
                    return k - i + 1;
                }
                n = (n * 10 + 1) % k;
            }
            return -1;
        }
    }

    public IList<int> SelfDividingNumbers(int left, int right)
    {
        IList<int> res = new List<int>();
        for (int n = left; n <= right; n++)
        {
            if (IsSelfDividing(n)) res.Add(n);
        }
        return res;
    }

    private bool IsSelfDividing(int n)
    {
        string str = n.ToString();
        if (str.Contains('0')) return false;

        int rem = n;
        for (int i = 0; i < str.Length; i++)
        {
            if (n % (rem % 10) != 0)
            {
                return false;
            }
            rem = rem / 10;
        }
        return true;
    }

    public string GetPermutation(int n, int k)
    {
        string perm = "";
        List<int> seq = Enumerable.Range(1, n).ToList();

        if (n >= 1 && n <= 9 && k <= GetFactorial(n))
        {
            int rank = k - 1;   // Convert from 1-based k to 0-based rank
            while (seq.Count > 0)
            {
                int fact = GetFactorial(seq.Count - 1);     // Blocks (same first digit) of n! have size (n-1)!

                int index = rank / fact;    // Which block are we in?

                int num = seq[index];   // Pick that element

                perm += num.ToString();
                seq.RemoveAt(index);

                rank %= fact;   // Position within the selected block
            }
        }
        return perm;
    }

    private int GetFactorial(int f)
    {
        if (f == 0)
            return 1;
        else
            return f * GetFactorial(f - 1);
    }

    public IList<IList<int>> Generate(int numRows)
    {
        IList<IList<int>> triangle = new List<IList<int>>();
        for (int row = 0; row < numRows; row++)
        {
            triangle.Add(new List<int>());
            for (int i = 0; i <= row; i++)
            {
                if (i == 0 || i == row)
                {
                    triangle[row].Add(1);
                }
                else
                {
                    triangle[row].Add(triangle[row - 1][i - 1] + triangle[row - 1][i]);
                }
            }
        }
        return triangle;
    }

    public int RearrangeSticks(int n, int k)
    {
        List<List<int>> perms = new List<List<int>>();
        int[] seq = Enumerable.Range(1, n).ToArray();
        GetPermutations(perms, seq, 0);

        int res = 0;
        foreach (var perm in perms)
        {
            int visible = 0;
            int biggestStick = 0;
            foreach (int s in perm)
            {
                if (s > biggestStick)
                {
                    visible++;
                    biggestStick = s;
                }

                if (visible > k) break;     // to increase performance
            }
            if (visible == k) res++;
        }
        return res;
    }

    private void GetPermutations(List<List<int>> res, int[] arr, int index)
    {
        if (index == arr.Length)
        {
            res.Add(new List<int>(arr));
            return;
        }

        for (int i = index; i < arr.Length; i++)
        {
            // Swapping
            int temp = arr[index];
            arr[index] = arr[i];
            arr[i] = temp;

            // Recursive call
            GetPermutations(res, arr, index + 1);

            // Backtracking
            temp = arr[index];
            arr[index] = arr[i];
            arr[i] = temp;
        }
    }
}

public class Bank
{

    private long[] _balance;

    public Bank(long[] balance)
    {
        _balance = balance;
    }

    public bool transfer(int account1, int account2, long money)
    {
        if (account1 <= _balance.Length && account2 <= _balance.Length && money <= _balance[account1 - 1])
        {
            _balance[account1 - 1] -= money;
            _balance[account2 - 1] += money;
            return true;
        }
        return false;
    }

    public bool deposit(int account, long money)
    {
        if (account <= _balance.Length)
        {
            _balance[account - 1] += money;
            return true;
        }
        return false;
    }

    public bool withdraw(int account, long money)
    {
        if (account <= _balance.Length && money <= _balance[account - 1])
        {
            _balance[account - 1] -= money;
            return true;
        }
        return false;
    }
}
