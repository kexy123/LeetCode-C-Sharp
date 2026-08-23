// RESULTS:
//      Submitted on 23 August 2026 at 19:40
//
//      18 / 18 testcases passed.
//
//      Runtime:    88 ms
//      Memory:     47.61 MB
//
// Directly borrowed from 0141_LinkedListCycle but finds the starting point of the cycle as well.

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Finds the starting point of a given cycle if there exists one.
    /// </summary>
    /// <param name="head">The starting <see cref="ListNode"/>.</param>
    /// <returns>The start of the cycle if there is one; otherwise <see langword="null"/>.</returns>
    public ListNode? DetectCycle(ListNode? head)
    {
        if (head is null)
        {
            return null;
        }

        ListNode slow = head, fast = head;
        while (fast.next is ListNode next && next.next is ListNode nextNext)
        {
            slow = slow.next;
            fast = nextNext;

            if (slow == fast)
            {
                goto CycleDetected;
            }
        }

        return null;

    CycleDetected:
        fast = head;
        while (fast != slow)
        {
            // Another variant of the tortoise and hare problem in 0141_LinkedListCycle is that if you
            // put fast back at the head, fast and slow are an equal distance apart from the start of
            // the ListNode that begins the cycle.
            slow = slow.next;
            fast = fast.next;
        }

        return slow;
    }
}
