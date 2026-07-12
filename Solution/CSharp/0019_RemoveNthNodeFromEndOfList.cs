// RESULTS:
//      Submitted on 24 June 2026 at 42.28
//
//      208 / 208 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     42.28 MB

using Solution.LeetCodeImplementations;

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Removes the <paramref name="n"/>th <see cref="ListNode"/>
    /// from the end of <paramref name="head"/> and moves its
    /// previous node such that it skips it. The root node can
    /// also be destroyed.
    /// </summary>
    /// <param name="head">The root <see cref="ListNode"/>.</param>
    /// <param name="n">The nth node from the end.</param>
    /// <returns><paramref name="head"/> if possible.</returns>
    public ListNode? RemoveNthFromEnd(ListNode head, int n)
    {
        // The root node is the only
        // ListNode in the chain,
        // and since n = 1 is
        // guaranteed, simply return null.
        if (head.next is null)
        {
            return null;
        }

        // Begin with the root being
        // offset.
        ListNode? root = head;
        for (int i = 0; i <= n; i++)
        {
            // This will only happen if
            // we want to delete the root
            // node, so simply return its
            // next ListNode.
            if (root is null)
            {
                return head.next;
            }

            root = root.next;
        }

        // Shift both root and offset
        // until the root reaches the
        // end. The offset is then the
        // nth node from the end.
        ListNode offset = head;
        while (root is not null)
        {
            root = root.next;
            offset = offset.next;
        }

        // Skip the ListNode that it is
        // currently pointing to.
        offset.next = offset.next.next;

        return head;
    }
}
