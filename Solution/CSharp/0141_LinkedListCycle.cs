// RESULTS:
//      Submitted on 23 August 2026 at 19:21
//
//      29 / 29 testcases passed.
//
//      Runtime:    103 ms
//      Memory:     49.44 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Checks if the given linked list has a cycle.
    /// </summary>
    /// <param name="head">The starting <see cref="ListNode"/>.</param>
    /// <returns><see langword="true"/> if it has a cycle; otherwise <see langword="false"/>.</returns>
    public bool HasCycle(ListNode? head)
    {
        if (head is null)
        {
            // There is no cycle in an empty linked list.
            return false;
        }

        // This is based on Floyd's tortoise and hare algorithm:
        // https://en.wikipedia.org/wiki/Cycle_detection#Floyd's_tortoise_and_hare
        //
        // If we have a slow pointer that only moves to the next node, while we have a fast pointer
        // that moves two pointers ahead of itself, then eventually they will intersect. When both the
        // tortoise and the hare are inside of the cycle, they are offset by some difference D. With
        // the length of the cycle being L, their difference is D mod L. After some amount of steps,
        // the resulting difference will be (D + steps) mod L. This steps variable will eventually have
        // to equal -D mod L, meaning that (D - D) mod L = 0, so they are intersecting, and therefore
        // are part of a cycle. If there was no cycle, the fast pointer would've already reached the
        // end of the linked list.
        ListNode slow = head, fast = head;
        while (fast.next is ListNode next && next.next is ListNode nextNext)
        {
            slow = slow.next;
            fast = nextNext;

            if (slow == fast)
            {
                return true;
            }
        }

        return false;
    }
}
