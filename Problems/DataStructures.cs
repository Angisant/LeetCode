/*
LeetCode Data Structures and Algorithms https://leetcode.com/quest/data-structures-and-algorithms-quest/
*/

namespace Problems.DataStructures;

public class Solution
{
    public int[] GetConcatenation(int[] nums)
    {
        int n = nums.Length;
        int[] ans = new int[n * 2];

        for (int i = 0; i < n; i++)
        {
            ans[i] = nums[i];
            ans[i + n] = nums[i];
        }
        return ans;
    }

    public int[] Shuffle(int[] nums, int n)
    {
        int[] ans = new int[n * 2];

        for (int i = 0; i < n * 2; i += 2)
        {
            ans[i] = nums[i / 2];
            ans[i + 1] = nums[i / 2 + n];
        }
        return ans;
    }

    public int FindMaxConsecutiveOnes(int[] nums)
    {
        int max = 0, cons = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 1)
            {
                cons++;
                if (cons > max)
                {
                    max = cons;
                }
            }

            if (i > 0 && nums[i - 1] == 1 && nums[i] != 1)
            {
                cons = 0;
            }
        }
        return max;
    }

    public int[] FindErrorNums(int[] nums)
    {
        int missingNum = 0, duplicatedNum = 0;
        HashSet<int> existing = new HashSet<int>();
        HashSet<int> all = new HashSet<int>(nums);

        for (int i = 0; i < nums.Length; i++)
        {
            int n = nums[i];
            if (missingNum == 0 && !all.Contains(i + 1))
            {
                missingNum = i + 1;
            }

            if (duplicatedNum == 0 && !existing.Add(n))
            {
                duplicatedNum = n;
            }

            if (missingNum > 0 && duplicatedNum > 0)
            {
                return [duplicatedNum, missingNum];
            }
        }
        return [];
    }

    public int[] SmallerNumbersThanCurrent(int[] nums)
    {
        List<int> res = new List<int>();

        var counts = nums.GroupBy(n => n).ToDictionary(count => count.Key, count => count.Count());

        foreach (int num in nums)
        {
            int smallerCountsSum = counts.Where(count => count.Key < num).Sum(count => count.Value);    // DECREASES PERFORMANCE!
            res.Add(smallerCountsSum);
        }
        return res.ToArray();
    }

    public IList<int> FindDisappearedNumbers(int[] nums)
    {
        List<int> res = new List<int>();
        HashSet<int> all = new HashSet<int>(nums);

        for (int n = 1; n <= nums.Length; n++)
        {
            if (!all.Contains(n))
            {
                res.Add(n);
            }
        }
        return res;
    }
}