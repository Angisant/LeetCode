/*
LeetCode Merge Intervals https://leetcode.com/problems/merge-intervals/
*/

namespace Problems.Merge;

public class Solution
{
    public int[][] Merge(int[][] intervals)
    {
        List<int[]> mergedIntervals = new List<int[]>();
        List<int[]> orderedIntervals = new List<int[]>();

        orderedIntervals = intervals.OrderBy(i => i[0]).ThenBy(i => i[1]).ToList();

        int intStart = orderedIntervals[0][0], intEnd = orderedIntervals[0][1];

        for (int i = 0; i < orderedIntervals.Count; i++)
        {
            int[] interval = orderedIntervals[i];
            if (intStart <= interval[0] && interval[0] <= intEnd && intEnd < interval[1])
            {
                intEnd = interval[1];
            }
            else if (intStart < interval[0] && intEnd < interval[1])
            {
                mergedIntervals.Add(new int[] { intStart, intEnd });
                intStart = interval[0];
                intEnd = interval[1];
            }
        }
        mergedIntervals.Add(new int[] { intStart, intEnd });

        return mergedIntervals.ToArray();
    }
}