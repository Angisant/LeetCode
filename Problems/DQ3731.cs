/*
LeetCode daily question #3731 https://leetcode.com/problems/find-missing-elements/description/
*/

namespace Problems.DQ3731;

public class Solution
{
    public IList<int> FindMissingElements(int[] nums)
    {
        IList<int> missingElements = new List<int>();

        if (nums.Length > 0)
        {
            nums.Sort();
            for (int n = 1; n < nums.Length; n++)
            {
                int previousElement = nums[n - 1];
                int currentElement = nums[n];
                for (int m = previousElement + 1; m < currentElement; m++)
                {
                    missingElements.Add(m);
                }
            }
        }
        return missingElements;
    }
}