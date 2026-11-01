/*
LeetCode daily question #2089 https://leetcode.com/problems/find-target-indices-after-sorting-array/description/
*/

namespace Problems.DQ2089;

public class Solution
{
    // Original Approach: Sort the array and loop through it until you find all target indices
    // Time: O(nlogn)   Space: O(n)
    public IList<int> TargetIndices(int[] nums, int target)
    {
        List<int> idxs = new List<int>();

        Array.Sort(nums);   // O(nlogn)

        for (int i = 0; i < nums.Length; i++)   // O(n)
        {
            if (nums[i] == target)
            {
                idxs.Add(i);
            }
            else if (idxs.Count > 0)
            {
                return idxs;
            }
        }
        return idxs;
    }

    // Binary Search Approach: Sort the array and perform binary search until you find all target indices
    // Time: O(nlogn)   Space: O(n)
    public IList<int> TargetIndices_BinarySearch(int[] nums, int target)
    {
        List<int> idxs = new List<int>();

        Array.Sort(nums);   // O(nlogn)

        // Perform binary search    O(logn)
        int left = 0;
        int right = nums.Length - 1;
        int i = -1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (nums[mid] == target)
            {
                i = mid;
                break;
            }
            else if (nums[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        // Target was found
        if (i != -1)
        {
            // Go to first occurence
            while (i > 0 && nums[i - 1] == target)
            {
                i--;
            }

            // Save all target occurrences
            while (i < nums.Length && nums[i] == target)
            {
                idxs.Add(i);
                i++;
            }
        }

        return idxs;
    }

    // No Sorting Approach: Determine the target indices by counting the targets and the values that come before
    // Time: O(n)   Space: O(n)
    public IList<int> TargetIndices_NoSorting(int[] nums, int target)
    {
        int preCount = 0, tCount = 0;
        List<int> idxs = new List<int>();

        foreach (int n in nums)  // O(n)
        {
            if (n == target)
            {
                tCount++;
            }
            else if (n < target)
            {
                preCount++;
            }
        }

        for (int i = preCount; i < preCount + tCount; i++)
        {
            idxs.Add(i);
        }
        return idxs;
    }
}
