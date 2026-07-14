// RESULTS:
//      Submitted on 13 July 2026 at 19:58
//
//      53 / 53 testcases passed.
//
//      Runtime:    3 ms
//      Memory:     85.75 MB
//
// Directly copied from 0104_MaximumDepthOfBinaryTree, but
// moved where the minDepth variable changes and prune
// unnecessary traversals.

using Solution.LeetCodeImplementations;

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Finds the shortest level in the binary tree
    /// that contains a leaf <see cref="TreeNode"/>.
    /// </summary>
    /// <param name="root">The starting <see cref="TreeNode"/>.</param>
    /// <returns>The shortest level in the binary tree that contains a leaf <see cref="TreeNode"/>.</returns>
    public int MinDepth(TreeNode? root)
    {
        if (root is null)
        {
            // Avoid incorrect depth result of int.MaxValue.
            return 0;
        }

        int minDepth = int.MaxValue;

        Traverse(root, 0);

        return minDepth;


        void Traverse(TreeNode? node, int depth)
        {
            if (node is null || depth >= minDepth)
            {
                // We only need to traverse in levels
                // lower than the minimum depth.
                return;
            }

            depth++;
            if (node.left is null && node.right is null)
            {
                // There are no subtrees at this level,
                // so update the minimum depth as its
                // parent is a leaf node.
                minDepth = Math.Min(minDepth, depth);
            }
            else
            {
                Traverse(node.left, depth);
                Traverse(node.right, depth);
            }
        }
    }
}
