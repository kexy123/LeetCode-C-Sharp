// RESULTS:
//      Submitted on 25 June 2026 at 12:14
//
//      134 / 134 testcases passed.
//
//      Runtime:    171 ms
//      Memory:     49.57 MB

using Solution.LeetCodeImplementations;

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Merges all given <see cref="ListNode"/> in
    /// ascending order, assuming that they are
    /// already ordered.
    /// </summary>
    /// <param name="lists">Array of <see cref="ListNode"/>.</param>
    /// <returns>The resulting merged <see cref="ListNode"/>.</returns>
    public ListNode? MergeKLists(ListNode?[] lists)
    {
        // If there are no ListNodes,
        // simply return nothing.
        if (lists.Length == 0)
        {
            return null;
        }

        // Make the first ListNode the
        // primary one.
        ListNode? result = null;
        int i = 0;
        while (result is null && i < lists.Length)
        {
            result = lists[i];
            i++;
        }

        // If lists only contains empty
        // ListNodes, return null..
        if (i > lists.Length)
        {
            return null;
        }

        for (int j = i; j < lists.Length; j++)
        {
            ListNode list = lists[j]!;

            // If one of the lists is empty,
            // do not perform merge operation.
            if (list is null)
            {
                continue;
            }

            ListNode head = new();
            ListNode root = head;
            while (result is not null || list is not null)
            {
                // Check if the current selected node
                // in list1 is less than list2, or if we
                // reached the end of list2, or if we
                // reached the end of list1.
                if (result is not null && (list is null || result!.val < list.val))
                {
                    // Set the root's next and root
                    // itself to list1.
                    root = root.next = result;

                    // Move to next node in list1.
                    result = result.next;
                }
                else
                {
                    // Set the root's next and root
                    // itself to list2.
                    root = root.next = list!;

                    // Move to next node in list2.
                    list = list!.next;
                }
            }

            // Ignore the empty ListNode object.
            result = head.next;
        }

        return result;
    }
}
