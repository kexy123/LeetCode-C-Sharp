// RESULTS:
//      Submitted on 09 July 2026 at 23:14
//
//      168 / 168 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     43.53 MB
//
// Similar to 82_RemoveDuplicatesFromSortedList, but
// a lot more simplified because there is no requirement
// to remove all duplicates.

using Solution.LeetCodeImplementations;

namespace Solution.RemoveDuplicatesFromSortedList_83;

public partial class Solution
{
    /// <summary>
    /// Removes all other duplicates from the
    /// sorted linked <see cref="ListNode"/>
    /// starting at <paramref name="head"/>.
    /// </summary>
    /// <param name="head">The starting <see cref="ListNode"/>.</param>
    /// <returns>The new distinct sorted linked <see cref="ListNode"/>.</returns>
    public ListNode? DeleteDuplicates(ListNode? head)
    {
        if (head is null)
        {
            return null;
        }

        ListNode old = head;
        ListNode root = head.next;
        while (root is not null)
        {
            if (old.val == root.val)
            {
                // B is essentially ignored
                // because A's pointer is
                // skipping over B now.
                // However, we keep old at
                // B to check for any more
                // duplicates.
                //
                //   ------>
                //  /       \
                // A    B -> C
                root = old.next = root.next;
            }
            else
            {
                old = root;
                root = root.next;
            }
        }

        return head;
    }
}
