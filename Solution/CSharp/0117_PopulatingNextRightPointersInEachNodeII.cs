// RESULTS:
//      Submitted on 14 July 2026 at 23:11
//
//      55 / 55 testcases passed.
//
//      Runtime:    87 ms
//      Memory:     45.66 MB
//
// Directly borrowed from 0116_PopulatingNextRightPointersInEachNode,
// just adding both null checks for the left and right of the Node.

using Solution.LeetCodeImplementations;

namespace Solution.CSharp.PopulatingNextRightPointersInEachNodeII_0117;

public partial class Solution
{
    /// <summary>
    /// Connects the <see cref="Node.next"/> of all
    /// <see cref="Node"/> in a binary tree to the
    /// <see cref="Node"/> right next to it, otherwise
    /// <see cref="null"/> if not possible.
    /// </summary>
    /// <param name="root">The starting <see cref="Node"/>.</param>
    /// <returns>The <paramref name="root"/>.</returns>
    public Node? Connect(Node? root)
    {
        if (root is null)
        {
            return null;
        }

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
                    node.next = level.Peek();
                }

                // The binary tree isn't balanced unlike
                // 0116_PopulatingNextRightPointersInEachNode.
                if (node.left is not null)
                {
                    level.Enqueue(node.left);
                }

                if (node.right is not null)
                {
                    level.Enqueue(node.right);
                }
            }
        }

        return root;
    }
}
