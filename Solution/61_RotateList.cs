// RESULTS:
//      Submitted on 06 July 2026 at 14:59
//
//      232 / 232 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     42.82 MB

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Rotates connected <see cref="ListNode"/> starting
    /// from <paramref name="head"/> <paramref name="k"/>
    /// times to the right.
    /// </summary>
    /// <param name="head">The starting <see cref="ListNode"/>.</param>
    /// <param name="k">How many times to right-rotate.</param>
    /// <returns>The starting <see cref="ListNode"/>.</returns>
    public ListNode? RotateRight(ListNode? head, int k)
    {
        if (head is null)
        {
            // There is no ListNode to begin with,
            // so return early. It also avoids the
            // DivideByZeroException.
            return null;
        }

        // Count how many nodes are
        // in the list, and keep
        // track of the end node.
        ListNode? end = head;
        ListNode? root = head;
        int numNodes = 0;
        while (root is not null)
        {
            end = root;
            root = root.next;
            numNodes++;
        }

        root = head;
        int complement = numNodes - (k % numNodes);
        if (complement == numNodes)
        {
            // k enforces zero right rotation,
            // so return as is.
            return head;
        }

        // Find the point of where to rotate.
        for (int i = 1; i < complement; i++)
        {
            root = root.next;
        }

        ListNode start = root.next;
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        // Cut off the point
        root.next = null;
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        // Connect the disconnected node.
        end!.next = head;

        // Return the new starting node.
        return start;
    }
}
