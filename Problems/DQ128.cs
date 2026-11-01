/*
LeetCode daily question #128 https://leetcode.com/problems/longest-consecutive-sequence/description/
*/

namespace Problems.DQ128;

public class Solution
{
    // Sorted Set Approach: Order distinct values with sorted set and go through the set to find sequences  
    // Time: O(nlogn) Space: O(n)
    public int LongestConsecutive(int[] nums)
    {
        if (nums.Length == 0) return 0;

        int longestSeq = 1, currSeq = 1;
        SortedSet<int> ordNums = new SortedSet<int>(nums);  // O(nlogn)
        int prevN = ordNums.Min;
        foreach (int n in ordNums)  // O(n)
        {
            if (n == prevN + 1)
            {
                currSeq++;
            }
            else
            {
                if (currSeq > longestSeq)
                {
                    longestSeq = currSeq;
                }
                currSeq = 1;
            }
            prevN = n;
        }
        return (currSeq > longestSeq) ? currSeq : longestSeq;   // In case last elements were part of a sequence
    }

    // Find Initial Limit Approach: Find the beggining of each sequence  
    // Time: O(n) Space: O(n)
    public int LongestConsecutive_InitialLimits(int[] nums)
    {
        if (nums.Length == 0) return 0;

        int longestSeq = 1, currSeq = 1;
        HashSet<int> set = new HashSet<int>(nums);  // O(n)
        HashSet<int> leftLimitSet = new HashSet<int>();
        foreach (int n in nums)  // O(n)
        {
            if (!set.Contains(n - 1)) leftLimitSet.Add(n);  // Find the number that is not preceded by another
        }

        foreach (int l in leftLimitSet)     // O(k), k being the number of consecutive sequences
        {
            while (set.Contains(l + currSeq))     // O(1)
            {
                currSeq++;
            }

            if (currSeq > longestSeq)
            {
                longestSeq = currSeq;
            }
            currSeq = 1;
        }
        return longestSeq;
    }
}
