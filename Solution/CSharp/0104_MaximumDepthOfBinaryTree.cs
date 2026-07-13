// RESULTS:
//      Submitted on 13 July 2026 at 13:34
//
//      40 / 40 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     45.49 MB

using Solution.LeetCodeImplementations;

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Finds the deepest level in the <see cref="TreeNode"/>.
    /// </summary>
    /// <param name="root">The starting <see cref="TreeNode"/>.</param>
    /// <returns>The deepest level in the binary tree.</returns>
    public int MaxDepth(TreeNode? root)
    {
        int maxDepth = 0;

        Traverse(root, 1);

        return maxDepth;


        // Traverses through the list pre-order
        // and finds the deepest level.
        void Traverse(TreeNode? node, int depth)
        {
            if (node is null)
            {
                // There is no TreeNode at this level,
                // so it doesn't count.
                return;
            }

            // Depth is incremented after the maxDepth
            // check.
            maxDepth = Math.Max(maxDepth, depth++);

            Traverse(node.left, depth);
            Traverse(node.right, depth);
        }
    }
}
