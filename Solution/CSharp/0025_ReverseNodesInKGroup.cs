// RESULTS:
//      Submitted on 25 June 2026 at 21:45
//
//      62 / 62 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     47.04 MB
//
// TODO: For some reason, inlining the
// Reverse() method makes it slower. Might
// be the LeetCode servers themselves.
// Check compiled results for inline vs.
// no inlining.

using Solution.LeetCodeImplementations;

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Divides the linked <see cref="ListNode"/> into
    /// segments of length <paramref name="k"/>,
    /// reverses them, then connects them together. The
    /// trailing <see cref="ListNode"/> that do not
    /// form a group of length <paramref name="k"/> will
    /// stay in the same order.
    /// </summary>
    /// <param name="head">The starting <see cref="ListNode"/>.</param>
    /// <param name="k">The number of <see cref="ListNode"/> in each group.</param>
    /// <returns>The new starting <see cref="ListNode"/> after reversal.</returns>
    public ListNode? ReverseKGroup(ListNode head, int k)
    {
        // It is unnecessary to reverse every
        // element in a ListNode as it simply
        // does nothing.
        if (k == 1)
        {
            return head;
        }

        ListNode top = new(next: head);
        ListNode? root = top;
        while (root is not null)
        {
            Reverse();
        }

        return top.next;


        // Reverses the next k ListNodes if
        // possible.
        void Reverse()
        {
            // Check if there aren't enough
            // ListNodes to complete the
            // reversal.
            ListNode? old = root.next;
            for (int i = 0; i < k; i++)
            {
                if (old is null)
                {
                    // If so, signal the method that
                    // the reversal process is finished.
                    root = null;
                    return;
                }

                old = old.next;
            }

            // For each targeted ListNode,
            // move its pointer to its
            // previous via the old
            // variable.
            old = root.next;
            ListNode? temp = old.next;
            for (int i = 1; i < k; i++)
            {
                // Visual example for k = 2:
                // (R - root, T - temp, O - old)
                //
                //           O    T
                //      R -> 0 -> 1 -> 2 -> 3 -> 4 -> 5
                //
                // (1) temp.next = old;
                //
                //           O    T
                //      R -> 0 <> 1    2 -> 3 -> 4 -> 5
                //
                // Note that temp.next refers to as it was
                // previously.
                // (2) old = temp; temp = temp.next;
                //
                //                O    T
                //      R -> 0 <> 1    2 -> 3 -> 4 -> 5

                (temp.next, old, temp) = (old, temp, temp.next);
            }

            // Visual example:
            //
            //                O    T
            //      R -> 0 <> 1    2 -> 3 -> 4 -> 5
            //
            // (1) root.next.next = temp;
            //
            //                O    T
            //      R -> 0 <- 1    2 -> 3 -> 4 -> 5
            //            \       /
            //             ------>
            //
            // (2) root.next = old;
            //
            //        ------>
            //       /       \
            //      R    0 <- 1    2 -> 3 -> 4 -> 5
            //            \       /
            //             ------>
            //
            // Rearranged:
            //
            //      R -> 1 -> 0 -> 2 -> 3 -> 4 -> 5
            //
            // root.next refers to as it was previously.
            // (3) root = root.next;
            //
            //     (0)
            //      R -> 2 -> 3 -> 4 -> 5
            //
            // And then this method is meant to be
            // repeated at the new root R.

            root.next.next = temp;
            (root.next, root) = (old, root.next);
        }
    }
}
