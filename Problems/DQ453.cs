/*
LeetCode daily question #453 https://leetcode.com/problems/minimum-moves-to-equal-array-elements/description/
*/

namespace Problems.DQ453;

public class Solution
{
    // Approach: Increment the n-1 smallest elements by one until all element are the same
    // Time: O(nlogn)  Space: O(n)
    public int MinMoves(int[] nums)
    {
        int n = nums.Length - 1;
        bool areAllEqual = true;
        int lastNum = nums[0], max = nums[0];
        PriorityQueue<int, int> queue = new PriorityQueue<int, int>();
        foreach (int num in nums)
        {
            queue.Enqueue(num, num);

            if (num > max)
            {
                max = num;
            }

            if (areAllEqual && lastNum != num)
            {
                areAllEqual = false;
            }
            lastNum = num;
        }

        if (areAllEqual) return 0;

        int inc = 0;
        while (true)
        {
            int[] incNums = new int[n];
            lastNum = queue.Peek();
            areAllEqual = true;
            for (int i = 0; i < n; i++)
            {
                int num = queue.Dequeue();
                incNums[i] = num + 1;
                if (areAllEqual && lastNum != num)
                {
                    areAllEqual = false;
                }
                lastNum = num;
            }
            inc++;

            if (areAllEqual && incNums[0] == queue.Peek() && incNums[0] == max) return inc;

            foreach (int num in incNums)
            {
                if (num > max)
                {
                    max = num;
                }
                queue.Enqueue(num, num);
            }
        }
    }

    // Approach: Same as above but increment instead by the difference between min and max values
    // Time: O(nlogn)  Space: O(n)
    public int MinMoves_MaxDiff(int[] nums)
    {
        int n = nums.Length - 1;
        bool areAllEqual = true;
        int lastNum = nums[0], max = nums[0];
        PriorityQueue<int, int> queue = new PriorityQueue<int, int>();
        foreach (int num in nums)
        {
            queue.Enqueue(num, num);

            if (num > max)
            {
                max = num;
            }

            if (areAllEqual && lastNum != num)
            {
                areAllEqual = false;
            }
            lastNum = num;
        }

        if (areAllEqual) return 0;

        int inc = 0;
        while (true)
        {
            int[] incNums = new int[n];
            lastNum = queue.Peek();
            areAllEqual = true;
            int minMaxDiff = max - queue.Peek();
            for (int i = 0; i < n; i++)
            {
                int num = queue.Dequeue();
                incNums[i] = num + minMaxDiff;
                if (areAllEqual && lastNum != num)
                {
                    areAllEqual = false;
                }
                lastNum = num;
            }
            inc += minMaxDiff;

            if (areAllEqual && incNums[0] == queue.Peek() && incNums[0] == max) return inc;

            foreach (int num in incNums)
            {
                if (num > max)
                {
                    max = num;
                }
                queue.Enqueue(num, num);
            }
        }
    }

    // Approach: Nº moves to increase n-1 elements until they are all equal <=> Nº moves to decrease 1 element until they are all equal
    // Time: O(nlogn)   Space: O(1) when not counting input
    public int MinMoves_Decrease(int[] nums)
    {
        Array.Sort(nums);   // O(nlogn)
        int inc = 0, min = nums[0];
        for (int j = nums.Length - 1; j > 0; j--)   // O(n)
        {
            if (nums[j] != min)
            {
                inc += nums[j] - min;
                nums[j] = min;
            }
            else
            {
                break;
            }
        }
        return inc;
    }
}
