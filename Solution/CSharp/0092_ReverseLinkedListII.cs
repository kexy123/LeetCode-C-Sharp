// RESULTS:
//      Submitted on 11 July 2026 at 22:23
//
//      44 / 44 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     41.57 MB

using Solution.LeetCodeImplementations;

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Reverses a segment of the linked <see cref="ListNode"/>
    /// starting at <paramref name="head"/>. The segment is
    /// from the <paramref name="left"/> to the
    /// <paramref name="right"/> relative to <paramref name="head"/>.
    /// Both are 1-indexed.
    /// </summary>
    /// <param name="head">The starting <see cref="ListNode"/>.</param>
    /// <param name="left">The start of the segment relative to <paramref name="head"/>. Is 1-indexed.</param>
    /// <param name="right">The end of the segment relative to <paramref name="head"/>. Is 1-indexed.</param>
    /// <returns>The new starting <see cref="ListNode"/> after reversal.</returns>
    public ListNode ReverseBetween(ListNode head, int left, int right)
    {
        ListNode start = new(next: head);

        // Find the start of the segment and
        // go one node before it.
        ListNode reverseStart = start;
        for (int i = 0; i < left - 1; i++)
        {
            reverseStart = reverseStart.next;
        }

        // Reverse endpoints. Refer to 0025_ReverseNodesInKGroup.
        ListNode old = reverseStart.next;
        ListNode temp = old.next;
        for (int i = 0; i < right - left; i++)
        {
            (temp.next, old, temp) = (old, temp, temp.next);
        }

        // Change reference endpoints of the segment
        // that was reversed. The start of the segment
        // points to reverseStart, and reverseStart
        // points to the end of the segment.
        reverseStart.next.next = temp;
        reverseStart.next = old;

        return start.next;
    }
}
