// RESULTS:
//      Submitted on 13 July 2026 at 19:45
//
//      228 / 228 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     47.12 MB

using Solution.LeetCodeImplementations;

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Checks if the given binary tree is height-balanced,
    /// where the depth of the subtrees in every
    /// <see cref="TreeNode"/> differ by at most one.
    /// </summary>
    /// <param name="root">The starting <see cref="TreeNode"/>.</param>
    /// <returns><see langword="true"/> if the binary tree is height-balanced; otherwise <see langword="false"/>.</returns>
    public bool IsBalanced(TreeNode? root)
    {
        // Check if the depth is not -1.
        return CheckAndGetDepth(root, 0) >= 0;


        // A recursive function that returns -1 if the
        // difference in depth of the two subtrees of
        // the node is greater than one or one of the
        // subtrees themselves returned -1; otherwise
        // returns the depth of the deeper subtree. 
        static int CheckAndGetDepth(TreeNode? node, int depth)
        {
            if (node is null)
            {
                return depth;
            }

            depth++;
            int leftDepth = CheckAndGetDepth(node.left, depth);
            int rightDepth = CheckAndGetDepth(node.right, depth);

            if (leftDepth == -1 || rightDepth == -1 || Math.Abs(leftDepth - rightDepth) > 1)
            {
                // The binary tree is invalid; return -1.
                return -1;
            }
            return Math.Max(leftDepth, rightDepth);
        }
    }
}
