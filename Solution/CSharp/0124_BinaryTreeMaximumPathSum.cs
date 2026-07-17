// RESULTS:
//      Submitted on 17 July 2026 at 22:20
//
//      96 / 96 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     48.47 MB
//
// Was nearly about to look up a solution given my old
// convoluted method, until I found a different approach
// to traversing the binary tree.

using Solution.LeetCodeImplementations;

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Computes the maximum sum possible of a
    /// non-empty path that traverses adjacent
    /// <see cref="TreeNode"/> instances in the
    /// binary tree only once.
    /// </summary>
    /// <param name="root">The starting <see cref="TreeNode"/>.</param>
    /// <returns>The maximum sum possible.</returns>
    public int MaxPathSum(TreeNode root)
    {
        int maxSum = int.MinValue;
        Traverse(root);

        return maxSum;


        // Finds the maximum sum possible in the current
        // TreeNode that connects to this TreeNode, and
        // sets the maxSum if possible to the maximum
        // parent sum or the sum of the left and right
        // subtrees. Note that the sum of this method can
        // never contain the sum of its left and right
        // subtrees.
        int Traverse(TreeNode node)
        {
            if (node is null)
            {
                return 0;
            }

            int leftSum = Traverse(node.left);
            int rightSum = Traverse(node.right);

            // The sum that can be returned is either itself,
            // itself plus the maximum sum of the left subtree,
            // or itself plus the maximum sum of the right
            // subtree.
            int maxParentSum = Math.Max(node.val, node.val + Math.Max(leftSum, rightSum));
            
            // And then the maxSum can contain the maxParentSum
            // or the sum of the left and right subtrees connected
            // by this TreeNode.
            maxSum = Math.Max(maxSum, Math.Max(maxParentSum, leftSum + node.val + rightSum));

            return maxParentSum;
        }
    }
}
