/*
LeetCode daily question #141 https://leetcode.com/problems/linked-list-cycle/description/
*/

namespace Problems.DQ141;

public class Solution
{
    public bool HasCycle(ListNode head)
    {
        ListNode slowP = head, fastP = head;
        while (fastP != null && fastP.next != null)
        {
            slowP = slowP.next;
            fastP = fastP.next.next;
            if (slowP == fastP)
            {
                return true;
            }
        }
        return false;
    }
}

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int x)
    {
        val = x;
        next = null;
    }

    public static ListNode MakeNodeList(int[] vals)
    {
        ListNode dummy = new ListNode(0);
        ListNode current = dummy;
        foreach (int v in vals)
        {
            current.next = new ListNode(v);
            current = current.next;
        }
        return dummy.next;
    }
}