using System.Diagnostics;

namespace Solution.LeetCodeImplementations.CopyListWithRandomPointer_0138;

/// <summary>
/// Simplified definition of <see cref="Node"/> in 0138_CopyListWithRandomPointer: stores an
/// <see langword="int"/> value, the pointer to the next <see cref="Node"/>, and a random pointer to
/// a <see cref="Node"/> in the linked list.
/// </summary>
[DebuggerDisplay("{ToString(),nq}")]
public class Node : ListNode
{
    /// <summary>
    /// The next <see cref="Node"/> to point to.
    /// </summary>
    public new Node next;

    /// <summary>
    /// The random <see cref="Node"/> it is pointing to. Can be <see langword="null"/>.
    /// </summary>
    public Node? random;

    /// <summary>
    /// Creates a <see cref="Node"/> instance with a <paramref name="_val"/>.
    /// </summary>
    /// <param name="_val">An <see langword="int"/> value.</param>
    public Node(int _val)
    {
        val = _val;
        next = null!;
        random = null;
    }

    /// <summary>
    /// Creates a chained <see cref="Node"/> from the given <see cref="IList{T}"/> collection
    /// <paramref name="sequence"/> and yields the starting element. Each entry in
    /// <paramref name="sequence"/> must contain an <see langword="int"/> value and the pointer index
    /// to a <see cref="Node"/> or <see langword="null"/>.
    /// </summary>
    /// <remarks>
    /// This should only be used for debugging and unit-testing purposes.
    /// </remarks>
    /// <param name="sequence">The <see cref="IList{T}"/> collection.</param>
    public Node(IList<IList<int?>> sequence)
    {
        ArgumentOutOfRangeException.ThrowIfZero(sequence.Count);

        Node[] nodes = new Node[sequence.Count];
        nodes[0] = this;

        // Prevent non-nullable field warning.
        next = null!;

        // Create the nodes.
        val = (int)sequence[0][0]!;
        Node current = this;
        for (int i = 1; i < sequence.Count; i++)
        {
            nodes[i] = current = current.next = new((int)sequence[i][0]!);
        }

        // Set the random positions.
        for (int i = 0; i < sequence.Count; i++)
        {
            if (sequence[i][1] is int position)
            {
                nodes[i].random = nodes[position];
            }
        }
    }


    /// <summary>
    /// Determines if <see cref="this"/> is part of a cyclic linked <see cref="Node"/>. If it is,
    /// find the starting point of the cycle.
    /// </summary>
    /// <returns>The starting point of the cycle. <see langword="null"/> if not in a cycle.</returns>
    private Node? IsInCycle()
    {
        Node fast = this, slow = this;
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
        Node? cyclicStart = IsInCycle();

        List<string> list = [];
        Node current = this;
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
