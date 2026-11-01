/*
LeetCode daily question #2333 https://leetcode.com/problems/minimum-sum-of-squared-difference/description/
*/

namespace Problems.DQ2333;

public class Solution
{
    public long MinSumSquareDiff(int[] nums1, int[] nums2, int k1, int k2)
    {
        long res = 0;
        PriorityQueue<long, long> diffQueue = new PriorityQueue<long, long>(Comparer<long>.Create((a, b) => b.CompareTo(a)));     // descending order
        for (int i = 0; i < nums1.Length; i++)
        {
            long diff = Math.Abs(nums1[i] - nums2[i]);     // |n1-n2|    easier to deal with only positive diff. 
            res += diff * diff;
            diffQueue.Enqueue(diff, diff);      // We only care about the diff now, not the position
        }

        int k = k1 + k2;    // k1:-1 <=> k2:+1 and k1:+1 <=> k2:-1 => We just have to worry about approximating diff to 0
        if (k > 0)
        {
            while (k > 0 && diffQueue.Peek() > 0)   // We can subtract
            {
                long newDiff = diffQueue.Dequeue() - 1;
                diffQueue.Enqueue(newDiff, newDiff);
                k--;
            }
            res = 0;
            while (diffQueue.Count > 0)
            {
                long d = diffQueue.Dequeue();
                res += d * d;
            }
        }
        return res;
    }
}