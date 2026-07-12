// RESULTS:
//      Submitted on 10 July 2026 at 19:44
//
//      168 / 168 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     42.10 MB

using Solution.LeetCodeImplementations;

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Partitions the given linked <see cref="ListNode"/>
    /// where the elements less than <paramref name="x"/>
    /// are on the left and the elements greater than or
    /// equal to <paramref name="x"/> are on the right,
    /// while keeping their relative order.
    /// </summary>
    /// <param name="head">The start of the linked <see cref="ListNode"/>.</param>
    /// <param name="x">The given <see cref="int"/> for partitioning.</param>
    /// <returns>The starting <see cref="ListNode"/>.</returns>
    public ListNode? Partition(ListNode? head,int x)
    {
        // The linked ListNode will only be in
        // two segments: the segment where all
        // values are less than x, and the other
        // segment where all values are greater
        // than or equal to x. These are the
        // start and end segments respectively.
        ListNode start = new();
        ListNode end = new();

        // We keep track of the pointers for
        // those segments.
        ListNode startRoot = start;
        ListNode endRoot = end;

        ListNode? root = head;
        while (root is not null)
        {
            ListNode temp = root.next;
            if (root.val<x)
            {
                // Move the start segment pointer.
                startRoot=startRoot.next = root;
            }
            else
            {
                // Move the end segment pointer.
                endRoot = endRoot.next = root;
            }

            root = temp;
        }

        // Join the start and the end.
        startRoot.next = end.next;

        // Prevent cyclic references.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        endRoot.next = null;
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

        return start.next;
    }
}
