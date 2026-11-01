/*
LeetCode daily question #2913 https://leetcode.com/problems/subarrays-distinct-element-sum-of-squares-i/description/
*/

namespace Problems.DQ2913;

public class Solution
{
    // Approach where you use a set
    public int SumCounts(IList<int> nums)
    {
        List<int> subArrsCounts = new List<int>();
        for (int n = 1; n <= nums.Count; n++)
        {
            for (int i = 0; i <= nums.Count - n; i++)
            {
                HashSet<int> set = new HashSet<int>();
                int count = 0;
                while (count < n)
                {
                    set.Add(nums[i + count]);
                    count++;
                }
                subArrsCounts.Add(set.Count);
            }
        }
        return subArrsCounts.Sum(c => c * c);
    }

    // Approach where you save all subarrays
    public int SumCounts_SubList(IList<int> nums)
    {
        List<List<int>> subArrs = new List<List<int>>();
        int sum = 0;
        for (int n = 1; n <= nums.Count; n++)
        {
            for (int i = 0; i <= nums.Count - n; i++)
            {
                List<int> subArr = new List<int>();
                int j = i;
                while (subArr.Count < n)
                {
                    subArr.Add(nums[j]);
                    j++;
                }
                subArrs.Add(subArr);
            }
        }

        sum = subArrs.Select(s => s.Distinct().Count()).Sum(c => c * c);
        return sum;
    }
}
