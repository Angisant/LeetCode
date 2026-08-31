/*
LeetCode daily question #2058 https://leetcode.com/problems/find-the-minimum-and-maximum-number-of-nodes-between-critical-points/description/
*/

namespace Problems.DQ2058;

public class Solution
{
    public int[] NodesBetweenCriticalPoints(ListNode head)
    {
        int[] dists = new int[2] { -1, -1 };
        List<int> criticalIdxs = new List<int>();
        ListNode curr = head, prev = null;
        int currIdx = 0;
        while (curr.next != null)
        {
            if (prev != null &&
            ((curr.val < prev.val && curr.val < curr.next.val) || (curr.val > prev.val && curr.val > curr.next.val)))
            {
                criticalIdxs.Add(currIdx);
            }
            prev = curr;
            curr = curr.next;
            currIdx++;
        }

        if (criticalIdxs.Count >= 2)
        {
            for (int i = 0; i < criticalIdxs.Count - 1; i++)
            {
                int dist = criticalIdxs[i + 1] - criticalIdxs[i];
                if (dists[0] < 0 || dist < dists[0])
                {
                    dists[0] = dist;
                }
            }
            dists[1] = criticalIdxs[criticalIdxs.Count - 1] - criticalIdxs[0];
        }
        return dists;
    }
}

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }

    public ListNode CreateListNode(int[] lst)
    {
        ListNode head = new ListNode();
        ListNode ln = head;

        for (int i = 0; i < lst.Length; i++)
        {
            ln.val = lst[i];
            if (i < lst.Length - 1)
            {
                ln.next = new ListNode();
                ln = ln.next;
            }
        }
        return head;
    }
}