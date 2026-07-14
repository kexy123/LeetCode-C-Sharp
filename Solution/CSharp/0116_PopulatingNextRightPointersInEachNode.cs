// RESULTS:
//      Submitted on 14 July 2026 at 23:03
//
//      59 / 59 testcases passed.
//
//      Runtime:    84 ms
//      Memory:     48.14 MB
//
// TODO: Do follow-up with O(1) space complexity
// (excludes implicit space such as the stack frame).
// The same goes for 0117_PopulatingNextRightPointersInEachNodeII.

using Solution.LeetCodeImplementations;

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Connects the <see cref="Node.next"/> of all
    /// <see cref="Node"/> in a balanced binary tree
    /// to the <see cref="Node"/> right next to it,
    /// otherwise <see cref="null"/> if not possible.
    /// </summary>
    /// <param name="root">The starting <see cref="Node"/>.</param>
    /// <returns>The <paramref name="root"/>.</returns>
    public Node? Connect(Node? root)
    {
        if (root is null)
        {
            return null;
        }

        // Breadth-first search will always traverse the
        // binary tree by depth, putting the required
        // Nodes adjacent to each other.
        Queue<Node> level = [];
        level.Enqueue(root);

        while (level.Count > 0)
        {
            int length = level.Count;
            for (int i = length - 1; i >= 0; i--)
            {
                Node node = level.Dequeue();
                if (i > 0)
                {
                    // Point to the right Node in the level.
                    node.next = level.Peek();
                }

                if (node.left is not null)
                {
                    // In a balanced binary tree, a Node either
                    // has a left and a right, or no left or right.
                    // Additionally, the level Queue should be
                    // left-to-right.
                    level.Enqueue(node.left);
                    level.Enqueue(node.right);
                }
            }
        }

        return root;
    }
}
