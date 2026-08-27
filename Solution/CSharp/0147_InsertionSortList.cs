// RESULTS:
//      Submitted on 27 August 2026 at 21:06
//
//      19 / 19 testcases passed.
//
//      Runtime:    3 ms
//      Memory:     46.73 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Sorts the linked list using <see href="https://en.wikipedia.org/wiki/Insertion_sort">Insertion
    /// sort</see> and returns the first <see cref="ListNode"/> in ascending order.
    /// </summary>
    /// <param name="head">The starting <see cref="ListNode"/>.</param>
    /// <returns>The first <see cref="ListNode"/> of the sorted linked list.</returns>
    public ListNode InsertionSortList(ListNode head)
    {
        ListNode start = new(int.MinValue, head);

        // Go through the linked list.
        ListNode? current = head, previous = start;
        while (current is not null)
        {
            ListNode? oldRight = current.next;
            if (current.val < previous.val)
            {
                // The linked list is not in ascending order at previous -> current, so perform
                // an insertion.

                ListNode newLeft = start;
                while (newLeft.next.val < current.val)
                {
                    // Find a point in the linked list that is newLeft -> newRight such that
                    // newLeft <= current <= newRight. In which case we only need current <= newRight.
                    newLeft = newLeft.next;
                }

                ListNode newRight = newLeft.next;

                // We need to dissolve previous -> current -> oldRight into previous -> oldRight.
                previous.next = oldRight;

                // Then insert current in-between newLeft -> newRight to make
                // newLeft -> current -> newRight.
                newLeft.next = current;
                current.next = newRight;

                // Note that we do not change the previous as current will be oldRight whose previous
                // is the same.
            }
            else
            {
                previous = current;
            }

            current = oldRight;
        }

        return start.next;
    }
}
