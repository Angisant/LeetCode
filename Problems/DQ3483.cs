/*
LeetCode daily question #3483 https://leetcode.com/problems/unique-3-digit-even-numbers/description/
*/

namespace Problems.DQ3483;

public class Solution
{
    public int TotalNumbers(int[] digits)
    {
        List<int> disEvenDigits = digits.Where(d => d % 2 == 0).Distinct().ToList();
        HashSet<int> perms = new HashSet<int>();
        if (disEvenDigits.Count > 0)
        {
            Dictionary<int, int> freqs = digits.GroupBy(d => d).ToDictionary(g => g.Key, g => g.Count());
            foreach (int en in disEvenDigits)   // LAST DIGIT
            {
                foreach (int md in digits)   // MIDDLE DIGIT
                {
                    if (md != en || freqs[en] > 1)
                    {
                        foreach (int fd in digits)   // FIRST DIGIT
                        {
                            if ((fd == en && freqs[en] < 2) || (fd == md && freqs[md] < 2) || (fd == en && fd == md && freqs[en] < 3)) continue;
                            if (fd > 0) perms.Add(fd * 100 + md * 10 + en);
                        }
                    }
                }
            }
        }
        return perms.Count;
    }
}