// RESULTS:
//      Submitted on 28 August 2026 at 19:11
//
//      30 / 30 testcases passed.
//
//      Runtime:    13 ms
//      Memory:     71.19 MB
//
// Grasping how a bottom-up in-place Merge sort algorithm for a linked list would work was too
// difficult for me to visualize, so I used pencil and paper to simulate the algorithm for this
// problem. The follow-up question asked for an O(n log n) time and O(1) space complexity, which I
// followed through instead of directly copying from 0147_InsertionSortList. The sorting algorithm that
// would fit best for this problem was the bottom-up in-place Merge sort algorithm.

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Performs a bottom-up in-place <see href="https://en.wikipedia.org/wiki/Merge_sort">Merge
    /// sort</see> on a linked list starting from the <paramref name="head"/> by rearranging the
    /// <see cref="ListNode"/> instances in ascending order.
    /// </summary>
    /// <param name="head">The starting <see cref="ListNode"/>.</param>
    /// <returns>The new starting <see cref="ListNode"/> of the sorted linked list.</returns>
    public ListNode? SortList(ListNode? head)
    {
        if (head is null)
        {
            return null;
        }

        ListNode start = new(int.MinValue, head);

        // A bottom-up merge sort implementation sorts elements in partitions, and merging partition
        // pairs that are next to each other such that their combined partition is sorted. For example:
        //  (2) -> (1) -> (3) -> (4) -> (8) -> (7) -> (10) -> (5)
        //
        // The grouped elements are partitions. Pairs of partitions are then selected. A partition must
        // be a sorted contiguous section in the linked list. Afterwards, we sort them in pairs:
        //  (1) -> (2) -> (3) -> (4) -> (7) -> (8) -> (5) -> (10)
        //
        // Now we can group every pair into partitions as every pair is in ascending order:
        //  (1 -> 2) -> (3 -> 4) -> (7 -> 8) -> (5 -> 10)
        //
        // Now we need to merge pairs of partitions together, especially for (7 -> 8) -> (5 -> 10). We
        // will assign two pointers, left (L) and right (R), situated on the first element of the left
        // partition and the first element of the second partition respectfully:
        //  ... 4) -> (7 -> 8) -> (5 -> 10)
        //      ^      ^           ^
        //      C      L           R
        //
        // We will also put C right before L. Now, we compare L and R. 5 < 7, so we point C to 5 which
        // is 4 -> 5, then move R and C to their next ListNode:
        //  ... 4) -> (5 -> 10)
        //           / ^    ^
        //   (7 -> 8)  C    R
        //    ^
        //    L
        //
        // 10 > 7, so we point C to 7 which is 5 -> 7, then move L and C to their next ListNode:
        //  ... 4) -> (5 -> 7)         (10)
        //           /      ^           ^
        //        (8)       C           R
        //         ^
        //         L
        //
        // Note that 10 is completely disconnected but still has a reference by R. 10 > 8, so point
        // C to 8 which is 7 -> 8, then move L and C to their next ListNode:
        //  ... 4) -> (5 -> 7) -> (8)       (10)
        //              \         /          ^
        //             ^ <-------- ^         R
        //             L           C
        //
        // Note that 8 still has a reference to 5, making this linked list cyclic so far. However, we
        // need to stop comparing values from L now as it has exited its left partition (7 -> 8). We
        // simply append C to R which is 8 -> 10, and move R until it leaves its partition as well.
        //  ... 4) -> (5 -> 7) -> (8 -> 10)
        //
        // And, if we had future values after 10, we would set C to 10 and the L and R pointers at
        // their starting points from C as well. This algorithm works from start-to-end starting from
        // single elements up to the entire list. However, there are three additional edge cases.
        int step = 1;
        while (true)
        {
            ListNode current = start;

            ListNode left = current.next;
            ListNode? right = Jump(left, step);
            if (right is null)
            {
                // The step value is bigger than the length of the linked list, so the entire linked
                // list is a sorted partition itself, meaning that the linked list is sorted.
                break;
            }

            while (right is not null)
            {
                // The first edge case is that the right partition doesn't have the same number of
                // elements as the left partition. In which case an extra null-check for the right
                // pointer must exist along with the rightTraversed sentinel check.
                int leftTraversed = 0, rightTraversed = 0;
                while (leftTraversed < step && rightTraversed < step && right is not null)
                {
                    if (left!.val <= right.val)
                    {
                        // L <= R, so append L after C and move L and C and increment its tracker.
                        current = current.next = left;
                        left = left.next;
                        leftTraversed++;
                    }
                    else
                    {
                        // R < L, so append R after C and move R and C and increment its tracker.
                        current = current.next = right;
                        right = right.next;
                        rightTraversed++;
                    }
                }

                // The two while loops cannot happen at the same time as either the right traversed
                // faster than the left or vice versa.
                while (rightTraversed < step && right is not null)
                {
                    current = current.next = right;
                    right = right.next;
                    rightTraversed++;
                }

                while (leftTraversed < step)
                {
                    // The second edge case is that if the right pointer had finished first, there
                    // could be a ListNode at the end of the entire partition itself that would cycle
                    // back to an existing ListNode instead of pointing to the next element or null. A
                    // simple case is this:
                    //  START -> (4) -> (3)
                    //  ^         ^      ^
                    //  C         L      R
                    //
                    // 3 < 4, so we append R after C and move C and R (R points to null):
                    //  START -> (3) <- (4)
                    //            ^      ^
                    //            C      L
                    //
                    // R has finished first, so now we append 4 after C in this while loop:
                    //  START -> (3) <-> (4)
                    //
                    // The nodes 3 and 4 now form a cycle. This while loop resolves that by
                    // disconnecting 4 and setting C to that node:
                    //  START -> (3) -> (4)
                    //                   ^
                    //                   C
                    //
                    // And if there were ever more nodes after 4, then the first statement in this
                    // while loop would reconnect it back:
                    //  START -> (3) -> (4) -> (?)
                    //                   ^      ^
                    //                   C      R
                    current = current.next = left!;
                    left = left!.next;
                    current.next = null!;
                    leftTraversed++;
                }

                // R is now at the spot where L should be, and C is directly before R.
                left = right!;
                right = Jump(right, step);
            }

            // The third edge case is where a partition has a left-out pair, which always exists at the
            // end of the linked list, and that the paired partition before it experienced the second
            // edge case, disconnecting this left-out partition from the linked list. This reconnection
            // prevents that edge case from happening.
            current.next = left;

            // All partitions of size step are now sorted, now we sort those pairs by doubling step.
            step *= 2;
        }

        return start.next;


        // Returns the ListNode instance that is after the given node by a given number of steps. If
        // the ListNode ends early, returns null.
        static ListNode? Jump(ListNode? node, int ahead)
        {
            for (int i = 0; i < ahead; i++)
            {
                if (node is null)
                {
                    return null;
                }

                node = node.next;
            }

            return node;
        }
    }
}
