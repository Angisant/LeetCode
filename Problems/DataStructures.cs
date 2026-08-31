/*
LeetCode Data Structures and Algorithms https://leetcode.com/quest/data-structures-and-algorithms-quest/
*/

using System.Dynamic;

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

    public IList<string> BuildArray(int[] target, int n)
    {
        int stackCount = 0;
        List<string> stackOps = new List<string>();

        for (int i = 1; i <= n; i++)
        {
            stackOps.Add("Push");
            if (target.Contains(i))
            {
                stackCount++;
            }
            else
            {
                stackOps.Add("Pop");
            }

            if (target.Length == stackCount)    //  Since stack only has elements from target, we only compare sizes
            {
                return stackOps;
            }
        }
        return stackOps;
    }

    // Instead of always searching through target, go through each value carefully
    public IList<string> BuildArray2(int[] target, int n)
    {
        int stackCount = 0, tIdx = 0;
        List<string> stackOps = new List<string>();

        for (int i = 1; i <= n; i++)
        {
            stackOps.Add("Push");
            if (tIdx < target.Length && target[tIdx] == i)
            {
                stackCount++;
                tIdx++;
            }
            else
            {
                stackOps.Add("Pop");
            }

            if (target.Length == stackCount)
            {
                return stackOps;
            }
        }
        return stackOps;
    }

    public int EvalRPN(string[] tokens)
    {
        List<string> tokensLst = tokens.ToList();
        string[] operators = new string[] { "+", "-", "*", "/" };

        int i = 0;
        while (tokensLst.Count > 1)
        {
            string currToken = tokensLst[i];
            if (operators.Contains(currToken))
            {
                int num1 = int.Parse(tokensLst[i - 2]);
                int num2 = int.Parse(tokensLst[i - 1]);
                int operationRes = 0;

                switch (currToken)
                {
                    case "+":
                        operationRes = num1 + num2;
                        break;
                    case "-":
                        operationRes = num1 - num2;
                        break;
                    case "*":
                        operationRes = num1 * num2;
                        break;
                    case "/":
                        operationRes = num1 / num2;
                        break;
                    default:
                        break;
                }
                tokensLst[i] = operationRes.ToString();     // Save operation result
                tokensLst.RemoveRange(i - 2, 2);      // Remove used operation elements
                i = 0;
            }
            else
            {
                i++;
            }
        }

        int res = int.Parse(tokensLst[0]);
        return res;
    }

    public int[] ExclusiveTime(int n, IList<string> logs)
    {
        int[] exTimes = new int[n];
        Stack<int> callStack = new Stack<int>();
        int prevTime = 0;

        foreach (string log in logs)
        {
            string[] subLog = log.Split(':');
            int funcId = int.Parse(subLog[0]);
            int time = int.Parse(subLog[2]);

            if (subLog[1] == "start")
            {
                if (callStack.Count > 0)
                {
                    exTimes[callStack.Peek()] += time - prevTime;   // Add time to previous function
                }
                prevTime = time;
                callStack.Push(funcId);     // Update current function
            }
            else
            {
                exTimes[callStack.Pop()] += time - prevTime + 1;    // Add time to current function
                prevTime = time + 1;
            }
        }
        return exTimes;
    }

    public int[] FinalPrices(int[] prices)
    {
        int[] answer = new int[prices.Length];

        for (int i = 0; i < prices.Length; i++)
        {
            answer[i] = prices[i];
            for (int j = i + 1; j < prices.Length; j++)
            {
                if (prices[j] <= prices[i])
                {
                    answer[i] -= prices[j];
                    break;
                }
            }
        }
        return answer;
    }

    public int[] DailyTemperatures(int[] temperatures)
    {
        int[] answer = new int[temperatures.Length];

        for (int i = 0; i < temperatures.Length; i++)
        {
            for (int j = i + 1; j < temperatures.Length; j++)
            {
                if (temperatures[j] > temperatures[i])
                {
                    answer[i] = j - i;
                    break;
                }
            }
        }
        return answer;
    }

    // Use stack for better performance
    public int[] DailyTemperatures_Stack(int[] temperatures)
    {
        Stack<int> idxStack = new Stack<int>();
        int[] answer = new int[temperatures.Length];

        for (int i = 0; i < temperatures.Length; i++)
        {
            // Until we find all temperatures in the stack lower than the current one
            while (idxStack.Count > 0 && (temperatures[i] > temperatures[idxStack.Peek()]))
            {
                int lastLowerIdx = idxStack.Pop();
                answer[lastLowerIdx] = i - lastLowerIdx;
            }
            idxStack.Push(i);
        }
        return answer;
    }

    // For each unique height, determine largest area
    public int LargestRectangleArea(int[] heights)
    {
        int highestArea = 0;
        SortedSet<int> sortedHeights = new SortedSet<int>(heights);
        foreach (int height in sortedHeights)
        {
            int highestWidth = 0;
            int prevWidth = 0;
            for (int i = 0; i < heights.Length; i++)
            {
                int currHeight = heights[i];
                if (currHeight >= height)
                {
                    prevWidth++;
                    if (i == heights.Length - 1 && prevWidth > highestWidth)
                    {
                        highestWidth = prevWidth;
                    }
                }
                else if (prevWidth > 0)
                {
                    if (prevWidth > highestWidth)
                    {
                        highestWidth = prevWidth;
                    }
                    prevWidth = 0;
                }
            }
            if (highestArea < height * highestWidth)
            {
                highestArea = height * highestWidth;
            }
        }
        return highestArea;
    }

    // For each bar, determine largest area => Use Stack to determine how far right can this bar mantain same height 
    public int LargestRectangleArea_Stack(int[] heights)
    {
        Stack<int> stack = new Stack<int>();
        int largestArea = 0;

        // Go through each bar, and one more iteration for all bars that didn't have anything shorter to their right
        for (int i = 0; i <= heights.Length; i++)
        {
            int currHeight = i == heights.Length ? 0 : heights[i];   // At the end, pretend there is a bar of height 0 
            while (stack.Count > 0 && heights[stack.Peek()] > currHeight)  // Current bar is smaller so rectangle ends here
            {
                int height = heights[stack.Pop()];  // stack top
                int width = (stack.Count == 0) ? i : i - stack.Peek() - 1;  // distance between curr and stack top
                if (largestArea < width * height)
                {
                    largestArea = width * height;
                }
            }

            if (i < heights.Length)
            {
                stack.Push(i);
            }
        }
        return largestArea;
    }
}