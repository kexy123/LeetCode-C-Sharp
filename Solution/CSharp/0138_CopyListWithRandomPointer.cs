// RESULTS:
//      Submitted on 23 August 2026 at 13:03
//
//      19 / 19 testcases passed.
//
//      Runtime:    73 ms
//      Memory:     42.86 MB

using Node = Solution.LeetCodeImplementations.CopyListWithRandomPointer_0138.Node;

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Deep-copies a linked list of <see cref="Node"/> instances that contain a random pointer to
    /// another <see cref="Node"/> instance within the linked list or <see langword="null"/>.
    /// </summary>
    /// <param name="head">The starting <see cref="Node"/> instance.</param>
    /// <returns>The starting <see cref="Node"/> of the new deep copy.</returns>
    public Node? CopyRandomList(Node? head)
    {
        if (head is null)
        {
            // There is no linked list to deep copy.
            return null;
        }

        Dictionary<Node, Node> nodes = [];

        // Create a copy of each Node individually without any pointer references.
        Node? current = head;
        while (current is not null)
        {
            nodes.Add(current, new(current.val));
            current = current.next;
        }

        // Link each Node to its next and its random pointer if not null.
        current = head;
        while (current is not null)
        {
            // The next pointer.
            if (current.next is Node next)
            {
                nodes[current].next = nodes[next];
            }

            // The random pointer.
            if (current.random is Node random)
            {
                nodes[current].random = nodes[random];
            }

            current = current.next;
        }

        return nodes[head];
    }
}
