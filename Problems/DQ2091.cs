/*
LeetCode daily question #2091 https://leetcode.com/problems/removing-minimum-and-maximum-from-array/description/
*/

namespace Problems.DQ2091;

public class Solution
{
    public int MinimumDeletions(int[] nums)
    {
        int minDel = 1;
        int[] minMaxIdx = new int[2];
        int min = nums[0], max = min;

        for (int i = 1; i < nums.Length; i++)
        {
            int n = nums[i];
            if (n < min)
            {
                min = n;
                minMaxIdx[0] = i;
            }

            if (n > max)
            {
                max = n;
                minMaxIdx[1] = i;
            }
        }

        if (nums.Length > 1)
        {
            var (maxIdx, minIdx) = minMaxIdx[0] > minMaxIdx[1] ?
                (minMaxIdx[0], minMaxIdx[1]) :
                (minMaxIdx[1], minMaxIdx[0]);

            // You either delete only from the left, only from the right, or from both sides
            int delLeft = maxIdx + 1;   // if we only delete from left
            int delRight = nums.Length - minIdx;   // if we only delete from right
            int delBoth = minIdx + 1 + (nums.Length - maxIdx);   // if we delete from left and right

            if (delLeft <= delRight && delLeft <= delBoth)
            {
                minDel = delLeft;
            }
            else if (delRight <= delLeft && delRight <= delBoth)
            {
                minDel = delRight;
            }
            else
            {
                minDel = delBoth;
            }
        }
        return minDel;
    }
}