/*
LeetCode daily question #2 https://leetcode.com/problems/add-two-numbers/description/
*/

namespace Problems.DQ2;

public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode dummy = new ListNode(0);
        ListNode current = dummy;
        int carry = 0;
        while (l1 != null || l2 != null)
        {
            int n1 = 0, n2 = 0;
            if (l1 != null)
            {
                n1 = l1.val;
                l1 = l1.next;
            }

            if (l2 != null)
            {
                n2 = l2.val;
                l2 = l2.next;
            }

            int sum = n1 + n2 + carry;
            carry = sum / 10;
            current.next = new ListNode(sum % 10);

            current = current.next;
        }

        if (carry > 0) current.next = new ListNode(carry);

        return dummy.next;
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
