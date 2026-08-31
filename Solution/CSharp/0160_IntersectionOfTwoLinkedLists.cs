// RESULTS:
//      Submitted on 01 September 2026 at 10:36
//
//      41 / 41 testcases passed.
//
//      Runtime:    162 ms
//      Memory:     70.14 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Finds the intersecting node of two linked lists <paramref name="headA"/> and
    /// <paramref name="headB"/>, otherwise return <see langword="null"/>.
    /// </summary>
    /// <param name="headA">A starting <see cref="ListNode"/>.</param>
    /// <param name="headB">A starting <see cref="ListNode"/>.</param>
    /// <returns>The intersection of <paramref name="headA"/> and <paramref name="headB"/>, otherwise null.</returns>
    public ListNode? GetIntersectionNode(ListNode headA, ListNode headB)
    {
        ListNode endA = headA;
        while (endA.next is not null)
        {
            endA = endA.next;
        }

        // Link the linked list of headA back to itself to create a cycle.
        endA.next = headA;

        // Directly borrowed from 0142_LinkedListCycleII. Since the linked list at headA is a cycle,
        // if headB intersects headA, then headB must also be in a cycle. For a linked list such as:
        //  1 -> 2 -> 3 -> 4 ->
        //             \       \
        //              <- 6 <- 5
        //
        // where headA is a cycle at 3 and headB starts at 1, Floyd's algorithm can find the
        // intersection of the slow and fast nodes, which also finds the intersection of headA
        // and headB.
        ListNode slow = headB, fast = headB;
        while (fast.next is ListNode next && next.next is ListNode nextNext)
        {
            slow = slow.next;
            fast = nextNext;

            if (slow == fast)
            {
                goto CycleDetected;
            }
        }

        // Note that the linked list at endA must retain its structure.
        endA.next = null!;
        return null;

    CycleDetected:
        fast = headB;
        while (fast != slow)
        {
            slow = slow.next;
            fast = fast.next;
        }

        endA.next = null!;
        return slow;
    }
}
