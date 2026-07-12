using System.Diagnostics;

namespace Solution.LeetCodeImplementations;

/// <summary>
/// Simplified definition of <see cref="ListNode"/>
/// in 2_AddTwoNumbers and other questions. Stores
/// a base-10 digit and a pointer to another
/// <see cref="ListNode"/>.
/// </summary>
[DebuggerDisplay("{ToString(),nq}")]
public class ListNode
{
    /// <summary>
    /// The <see cref="int"/> value of <see cref="this"/>.
    /// </summary>
    public int val;

    /// <summary>
    /// The next <see cref="ListNode"/> to point to.
    /// </summary>
    public ListNode next;

    /// <summary>
    /// Creates a <see cref="ListNode"/> instance with
    /// a <paramref name="val"/> (defaults to 0) and an
    /// optional <paramref name="next"/> that points to
    /// the next <see cref="ListNode"/>.
    /// </summary>
    /// <param name="val">An <see cref="int"/> value. Defaults to 0.</param>
    /// <param name="next">The next <see cref="ListNode"/> to point to.</param>
    public ListNode(int val = 0, ListNode? next = null)
    {
        this.val = val;
        this.next = next!;
    }

    /// <summary>
    /// Creates a chained <see cref="ListNode"/> from
    /// the given <see cref="IList{T}"/> collection
    /// <paramref name="values"/> and yields the starting
    /// element.
    /// </summary>
    /// <remarks>
    /// This should only be used for debugging and
    /// unit-testing purposes.
    /// </remarks>
    /// <param name="values">The <see cref="IList{T}"/> collection.</param>
    public ListNode(IList<int> values)
    {
        ArgumentOutOfRangeException.ThrowIfZero(values.Count);

        val = values[0];
        next = null!;
        ListNode current = this;
        for (int i = 1; i < values.Count; i++)
        {
            current = current.next = new(values[i]);
        }
    }


    /// <summary>
    /// Determines if <see cref="this"/> is part of a
    /// cyclic linked <see cref="ListNode"/>. If it is,
    /// find the starting point of the cycle.
    /// </summary>
    /// <returns>The starting point of the cycle. <see langword="null"/> if not in a cycle.</returns>
    private ListNode? IsInCycle()
    {
        ListNode fast = this, slow = this;
        while (fast.next is not null && fast.next.next is not null)
        {
            slow = slow.next;
            fast = fast.next.next;
            if (slow == fast)
            {
                goto Intersected;
            }
        }

        return null;

    Intersected:
        slow = this;
        while (slow != fast)
        {
            slow = slow.next;
            fast = fast.next;
        }

        return slow;
    }

    public override string ToString()
    {
        ListNode? cyclicStart = IsInCycle();

        List<string> list = [];
        ListNode current = this;
        do
        {
            list.Add(Convert.ToString(current.val));
            current = current.next;
        } while (current is not null && cyclicStart != current);

        if (cyclicStart is not null && current == cyclicStart)
        {
            list.Add("!!!CYCLE!!!");
        }

        return $"[{string.Join(", ", list)}]";
    }
}
