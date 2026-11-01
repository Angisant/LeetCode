/*
LeetCode daily question #1 https://leetcode.com/problems/two-sum/description/
*/

namespace Problems.DQ1;

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> diffs = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int diff = target - nums[i];
            if (diffs.ContainsKey(diff))
            {
                return [diffs[diff], i];
            }
            else if (!diffs.ContainsKey(nums[i]))
            {
                diffs.Add(nums[i], i);
            }
        }
        return [];
    }
}
