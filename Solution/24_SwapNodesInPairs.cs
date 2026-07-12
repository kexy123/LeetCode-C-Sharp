// RESULTS:
//      Submitted on 25 June 2026 at 15:07
//
//      55 / 55 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     41.45 MB

using Solution.LeetCodeImplementations;

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Swaps every pair in the <see cref="ListNode"/>
    /// starting at <paramref name="head"/>.
    /// </summary>
    /// <param name="head">The root <see cref="ListNode"/>.</param>
    /// <returns>The new <see cref="ListNode"/>.</returns>
    public ListNode? SwapPairs(ListNode? head)
    {
        // If no ListNode is given, simply
        // return itself.
        if (head is null)
        {
            return head;
        }

        ListNode top = new(next: head);
        ListNode? root = top;

        // Check if the root contains the
        // next two ListNods.
        while (root is not null && root.next is ListNode temp && root.next.next is ListNode temp2)
        {
            // Visual demonstration:
            // root -> A -> B -> C
            ListNode? temp3 = root.next.next.next;

            // root -> A <- B    C
            root.next.next.next = temp;

            //           ------>
            //          /       \
            // root    A <- B    C
            root.next.next = temp3;

            // Rearranged:
            // root -> B -> A -> C
            root.next = temp2;

            // root -> A
            root = temp;
        }

        return top.next;
    }
}
