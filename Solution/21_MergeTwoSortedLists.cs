// RESULTS:
//      Submitted on 24 June 2026 at 21:41
//
//      208 / 208 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     43.34 MB

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Merges two <see cref="ListNode"/> retaining ascending
    /// sorted order.
    /// </summary>
    /// <param name="list1">The first <see cref="ListNode"/>.</param>
    /// <param name="list2">The second <see cref="ListNode"/>.</param>
    /// <returns></returns>
    public ListNode? MergeTwoLists(ListNode list1, ListNode list2)
    {
        // If one of the lists is empty,
        // simply return the other as
        // it counts as a merged list.
        if (list1 is null || list2 is null)
        {
            return list1 ?? list2;
        }

        ListNode head = new();
        ListNode root = head;
        while (list1 is not null || list2 is not null)
        {
            // Check if the current selected node
            // in list1 is less than list2, or if we
            // reached the end of list2, or if we
            // reached the end of list1.
            if (list1 is not null && (list2 is null || list1!.val < list2.val))
            {
                // Set the root's next and root
                // itself to list1.
                root = root.next = list1;

                // Move to next node in list1.
                list1 = list1.next;
            }
            else
            {
                // Set the root's next and root
                // itself to list2.
                root = root.next = list2!;

                // Move to next node in list2.
                list2 = list2!.next;
            }
        }

        // Ignore the empty ListNode object.
        return head.next;
    }
}
