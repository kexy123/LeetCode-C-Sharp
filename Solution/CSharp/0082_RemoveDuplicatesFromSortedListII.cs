// RESULTS:
//      Submitted on 09 July 2026 at 23:11
//
//      166 / 166 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     42.90 MB

using Solution.LeetCodeImplementations;

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Deletes all <see cref="ListNode"/> that have
    /// the same value in a sorted linked
    /// <see cref="ListNode"/> starting from
    /// <paramref name="head"/>.
    /// </summary>
    /// <param name="head">The starting <see cref="ListNode"/>.</param>
    /// <returns>The start of the distinct sorted linked <see cref="ListNode"/>.</returns>
    public ListNode? DeleteDuplicates(ListNode? head)
    {
        if (head is null)
        {
            // Simply return null as there are
            // no elements in the linked ListNode.
            return null;
        }

        ListNode start = new();
        ListNode startRoot = start;

        int duplicate = int.MinValue;
        ListNode? root = head;
        while (root is not null)
        {
            ListNode? next = root.next;
            if (next is not null && root.val == next.val)
            {
                // Mark the duplicate value because this
                // condition only checks all duplicates
                // until the very end of the section
                // of duplicated elements, in which case
                // it would've been added to the new
                // linked ListNode.
                duplicate = root.val;
            }
            else if (root.val != duplicate)
            {
                // Add this ListNode to the new list.
                startRoot = startRoot.next = root;
            }

            // Remove reference to the next
            // ListNode when we return start.next.
            root.next = null!;
            root = next;
        }

        return start.next;
    }
}
