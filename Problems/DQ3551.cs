/*
LeetCode daily question #3551 https://leetcode.com/problems/minimum-swaps-to-sort-by-digit-sum/description/
*/

namespace Problems.DQ3551;

public class Solution
{
    public int MinSwaps(int[] nums)
    {
        Dictionary<int, List<int>> sumsDigits = new Dictionary<int, List<int>>();
        for (int i = 0; i < nums.Length; i++)
        {
            int sum = 0, n = nums[i];
            while (n > 0)
            {
                sum += n % 10;
                n /= 10;
            }

            if (sumsDigits.TryGetValue(sum, out List<int> lst))
            {
                lst.Add(i);
            }
            else
            {
                sumsDigits.Add(sum, new List<int> { i });
            }
        }

        int[] ordNums = sumsDigits.OrderBy(s => s.Key).SelectMany(s => s.Value.OrderBy(i => nums[i])).ToArray();

        int swaps = 0;
        bool[] swapped = new bool[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            if (swapped[i]) continue;

            int j = i, size = 0;
            while (!swapped[j])
            {
                swapped[j] = true;
                j = ordNums[j];
                size++;
            }
            swaps += Math.Max(0, size - 1);     // cycle of k elements requires k-1 swaps.
        }
        return swaps;
    }
}
