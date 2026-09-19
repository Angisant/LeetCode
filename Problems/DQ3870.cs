/*
LeetCode daily question #3870 https://leetcode.com/problems/count-commas-in-range/description/
*/

namespace Problems.DQ3870;

public class Solution
{
    public int CountCommas(int n)
    {
        int count = 0;
        if (n > 999)
        {
            int nCopy = n;
            string nStr = nCopy.ToString();
            int minComma = (nStr.Length - 1) / 3;   // Minimum commas per current n. A comma every three digits
            double chunk = Math.Pow(1000, minComma);  // Slowly chip away at the number with a multiplier of 1000
            while (nCopy > 0)
            {
                if (minComma > 0)
                {
                    count += (int)(minComma * chunk);   // Add the commas of the chunk 
                    nCopy -= (int)chunk;                // Update n
                    nStr = nCopy.ToString();
                    minComma = (nStr.Length - 1) / 3;   // Update commas per current n
                    chunk = Math.Pow(1000, minComma);   // Update chunk
                }
                else
                {
                    count += nCopy;     // Add remaining number which is equivalent to one comma
                    nCopy = 0;
                }
            }
            count -= 999;   // Don't account for the numbers before 1000
        }
        return count;
    }

    public long CountCommasII(long n)
    {
        long count = 0;
        long nCopy = n;
        int minCommas = (nCopy.ToString().Length - 1) / 3;   // Minimum commas per current n. A comma every three digits
        double chunk = Math.Pow(1000, minCommas);  // Slowly chip away at the number with a multiplier of 1000

        while (nCopy > 999)  // Don't account for the numbers before 1000
        {
            if (nCopy - chunk >= chunk)
            {
                nCopy -= (long)chunk;                               // Update n
                count += (long)(minCommas * chunk);                 // Add the commas of the chunk
            }
            else
            {
                count += (long)(minCommas * (nCopy - chunk + 1));   // Add the commas of the numbers outside of the chunk 
                nCopy = (long)chunk - 1;                            // Update n
                minCommas--;                                        // Update commas since chunk will decrease
            }
            chunk = Math.Pow(1000, minCommas);  // Update chunk
        }
        return count;
    }
}