/*
LeetCode Data Structures and Algorithms https://leetcode.com/quest/data-structures-and-algorithms-quest/
*/

using System.Dynamic;
using System.Globalization;

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

    public int[] PlusOne(int[] digits)
    {
        if (digits.Length == 0) return [];

        int[] res = new int[digits.Length];
        bool addOne = true;
        for (int i = digits.Length - 1; i >= 0; i--)
        {
            if (addOne)
            {
                int d = digits[i];
                if (d != 9)
                {
                    res[i] = d + 1;
                    addOne = false;
                }
                else
                {
                    res[i] = 0;
                }
            }
            else
            {
                res[i] = digits[i];
            }
        }

        if (addOne)
        {
            res = (new int[1] { 1 }).Concat(res).ToArray();
        }
        return res;
    }

    public bool ValidMountainArray(int[] arr)
    {
        bool isIncreasing = (arr.Length >= 3 && arr[0] < arr[1]);
        if (!isIncreasing) return false;

        int previousNum = -1;
        foreach (int n in arr)
        {
            if (previousNum >= 0)
            {
                if (n == previousNum || (!isIncreasing && n > previousNum))  // Didnt change or Was decreasing but increased again
                {
                    return false;
                }

                if (isIncreasing && n < previousNum)    // Decreasing starts
                {
                    isIncreasing = false;
                }
            }
            previousNum = n;
        }
        if (isIncreasing)
        {
            return false;
        }
        return true;
    }

    public string RemoveDuplicateLetters(string s)
    {
        SortedSet<char> letters = new SortedSet<char>(s);
        List<char> lst = new List<char>(s);

        if (letters.Count == s.Length) return s;

        Dictionary<char, int> lastIdxs = new Dictionary<char, int>();
        foreach (char c in letters)
        {
            lastIdxs.Add(c, lst.FindLastIndex(c2 => c2 == c));
        }

        Stack<char> stack = new Stack<char>();
        HashSet<char> present = new HashSet<char>();
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (!present.Contains(c))
            {
                // Curr char is lexicographically smaller than prev and prev char still appears later in the string
                // Can pop multiple values from stack
                while (stack.Count > 0 && c < stack.Peek() && i < lastIdxs[stack.Peek()])
                {
                    present.Remove(stack.Pop());
                }
                stack.Push(c);
                present.Add(c);
            }
        }
        return new string(stack.Reverse().ToArray());
    }

    // Circular sandwiches = 0, Square sandwiches = 1
    public int CountStudents(int[] students, int[] sandwiches)
    {
        Queue<int> studentQueue = new Queue<int>(students);
        int sIdx = 0, unable = 0;
        while (unable < studentQueue.Count)
        {
            if (studentQueue.Peek() == sandwiches[sIdx])
            {
                studentQueue.Dequeue();
                unable = 0;
                sIdx++;
            }
            else
            {
                studentQueue.Enqueue(studentQueue.Dequeue());
                unable++;
            }
        }
        return unable;
    }

    public int TimeRequiredToBuy(int[] tickets, int k)
    {
        int sum = 0, kTickets = tickets[k];
        for (int i = 0; i < tickets.Length; i++)
        {
            int iTickets = tickets[i];
            if (i <= k)
            {
                sum += (iTickets < kTickets) ? iTickets : kTickets;
            }
            else
            {
                sum += (iTickets < (kTickets - 1)) ? iTickets : (kTickets - 1);
            }
        }
        return sum;
    }

    public int TimeRequiredToBuy_Queue(int[] tickets, int k)
    {
        Queue<int> peopleQueue = new Queue<int>(Enumerable.Range(0, tickets.Length));
        int time = 0;
        while (true)
        {
            int frontIdx = peopleQueue.Peek();
            tickets[frontIdx]--;
            time++;
            if (tickets[frontIdx] == 0)
            {
                if (frontIdx == k)
                {
                    return time;
                }
                peopleQueue.Dequeue();
            }
            else
            {
                peopleQueue.Enqueue(peopleQueue.Dequeue());
            }
        }
    }

    public int LastStoneWeight(int[] stones)
    {
        List<int> orderedStones = stones.OrderBy(s => s).ToList();
        while (orderedStones.Count > 1)
        {
            int lastStone = orderedStones[orderedStones.Count - 1];
            int secondLastStone = orderedStones[orderedStones.Count - 2];
            if (lastStone == secondLastStone)
            {
                orderedStones.RemoveRange(orderedStones.Count - 2, 2);
            }
            else
            {
                orderedStones.RemoveAt(orderedStones.Count - 2);
                orderedStones[orderedStones.Count - 1] = Math.Max(lastStone - secondLastStone, secondLastStone - lastStone);
            }
            orderedStones = orderedStones.OrderBy(s => s).ToList();
        }
        return orderedStones.Count > 0 ? orderedStones[0] : 0;
    }

    // In c# heap = PriorityQueuque
    public int LastStoneWeight_Heap(int[] stones)
    {
        // Create heap with decreasing order comparer
        PriorityQueue<int, int> heap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b - a));
        foreach (int os in stones)
        {
            heap.Enqueue(os, os);   // Priority = weight => Heap will be ordered by weight
        }

        while (heap.Count > 1)
        {
            int lastStone = heap.Dequeue();
            int secondLastStone = heap.Dequeue();
            if (lastStone != secondLastStone)
            {
                int diff = Math.Max(lastStone - secondLastStone, secondLastStone - lastStone);
                heap.Enqueue(diff, diff);
            }
        }
        return heap.Count > 0 ? heap.Dequeue() : 0;
    }

    // nums1 and nums2 both are sorted in non-decreasing order and both have the same length
    public IList<IList<int>> KSmallestPairs2(int[] nums1, int[] nums2, int k)
    {
        IList<IList<int>> res = new List<IList<int>>() { };
        int i = 0, j = 0;
        while (res.Count < k)
        {
            res.Add(new List<int> { nums1[i], nums2[j] });
            if (i < nums1.Length - 1 && j < nums2.Length - 1)
            {
                if (nums1[i] + nums2[j + 1] <= nums1[i + 1] + nums2[j])
                {
                    i = 0;
                    j++;
                }
                else
                {
                    i++;
                    j = 0;
                }
            }
            else
            {
                if (i <= nums1.Length - 1)
                {
                    j++;
                }
                else
                {
                    i++;
                }
            }
        }
        return res;
    }

    public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
    {
        IList<IList<int>> res = new List<IList<int>>();
        PriorityQueue<int[], int> heap = new PriorityQueue<int[], int>();

        // Put the first pair from each row into the heap
        for (int i = 0; i < Math.Min(nums1.Length, k); i++)  // Insert up to k elements from nums1
        {
            heap.Enqueue([i, 0], nums1[i] + nums2[0]);
        }

        while (heap.Count > 0 && res.Count < k)
        {
            int[] idxs = heap.Dequeue();    // Get smallest saved sum
            int i = idxs[0], j = idxs[1];
            res.Add(new List<int> { nums1[i], nums2[j] });  // Add smallest saved sum

            // Move right
            if (j < nums2.Length - 1)
            {
                heap.Enqueue([i, j + 1], nums1[i] + nums2[j + 1]);
            }
        }
        return res;
    }

    public bool IsPossible(int[] target)
    {
        bool isAllOnes = false;
        int oldSum = 0, newSum = 0, oldSumIdx = 0;
        while (!isAllOnes)
        {
            isAllOnes = true;

            if (newSum > 0)
            {
                // newSum = sum - replacedNum + newNum => newSum = 2oldSum - replacedNum => replacedNum = 2oldSum - newSum
                target[oldSumIdx] = 2 * oldSum - newSum;    // Compute old X
                oldSum = 0;
                newSum = 0;
            }

            for (int i = 0; i < target.Length; i++)
            {
                if (target[i] > 1)
                {
                    isAllOnes = false;
                    if (target[i] > oldSum)
                    {
                        oldSum = target[i];     // oldSum (oldX) will always be the biggest value on the array 
                        oldSumIdx = i;
                    }
                }
                else if (target[i] != 1 && target[i] < target.Length)   // Cannot turn into 1
                {
                    return false;
                }
                newSum += target[i];        // Compute new X
            }
        }
        return true;
    }

    public bool IsPossible_Heap(int[] target)
    {
        // Create heap with bigger values first
        PriorityQueue<int, int> heap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b - a));
        foreach (int t in target) heap.Enqueue(t, t);

        bool isAllOnes = false;
        int newSum = target.Sum();
        while (!isAllOnes)
        {
            isAllOnes = true;
            int oldSum = heap.Dequeue();    // oldSum (oldX) will always be the biggest value on the array 

            if (oldSum < 1 || (oldSum > 1 && oldSum < target.Length))   // Cannot turn into 1
            {
                return false;
            }
            else if (oldSum > 1)
            {
                isAllOnes = false;

                // newSum = sum - replacedNum + newNum => newSum = 2oldSum - replacedNum => replacedNum = 2oldSum - newSum   
                int replacedNum = 2 * oldSum - newSum;      // Compute old X
                heap.Enqueue(replacedNum, replacedNum);
                newSum = oldSum;
            }
        }
        return true;
    }
}

public class MyQueue
{
    private Stack<int> _uprightStack;
    private Stack<int> _upsideDownStack;

    public MyQueue()
    {
        _uprightStack = new Stack<int>();
        _upsideDownStack = new Stack<int>();
    }

    public void Push(int x)
    {
        if (_uprightStack.Count > 0 && _upsideDownStack.Count == 0)
        {
            while (_uprightStack.Count > 0)
            {
                _upsideDownStack.Push(_uprightStack.Pop());
            }
        }
        _upsideDownStack.Push(x);
    }

    public int Pop()
    {
        if (_uprightStack.Count > 0)
        {
            return _uprightStack.Pop();
        }

        if (_upsideDownStack.Count > 0 && _uprightStack.Count == 0)
        {
            while (_upsideDownStack.Count > 0)
            {
                _uprightStack.Push(_upsideDownStack.Pop());
            }
            return _uprightStack.Pop();
        }
        return 0;
    }

    public int Peek()
    {
        if (_uprightStack.Count > 0)
        {
            return _uprightStack.Peek();
        }

        if (_upsideDownStack.Count > 0 && _uprightStack.Count == 0)
        {
            while (_upsideDownStack.Count > 0)
            {
                _uprightStack.Push(_upsideDownStack.Pop());
            }
            return _uprightStack.Peek();
        }
        return 0;
    }

    public bool Empty()
    {
        return _upsideDownStack.Count == 0 && _uprightStack.Count == 0;
    }
}