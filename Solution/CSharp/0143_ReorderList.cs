// RESULTS:
//      Submitted on 24 August 2026 at 12:35
//
//      12 / 12 testcases passed.
//
//      Runtime:    1 ms
//      Memory:     51.89 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Rearranges the <see cref="ListNode"/> instances in a linked list such that it is in the form
    /// <c>L[0] -> L[n] -> L[1] -> L[n - 1] -> L[2] -> L[n - 2] -> ...</c> where <c>L</c> is the given
    /// linked list.
    /// </summary>
    /// <param name="head">The starting <see cref="ListNode"/>.</param>
    public void ReorderList(ListNode head)
    {
        // Keep track of all the nodes backwards.
        Stack<ListNode> nodes = [];

        ListNode? current = head;
        while (current is not null)
        {
            nodes.Push(current);
            current = current.next;
        }

        // This is a form of interlacing, where the last half is interlaced with the front half in
        // reverse order.
        int halfLength = nodes.Count / 2;
        current = head;
        for (int i = 0; i < halfLength; i++)
        {
            ListNode last = nodes.Pop();
            last.next = current.next;

            ListNode next = current.next;
            current.next = last;
            current = next;
        }

        // Prevent a cyclic list.
        current.next = null!;
    }
}
