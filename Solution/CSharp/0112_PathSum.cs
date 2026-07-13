// RESULTS:
//      Submitted on 13 July 2026 at 21:51
//
//      118 / 118 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     46.56 MB

using Solution.LeetCodeImplementations;

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Checks if the given binary <see cref="TreeNode"/>
    /// contains a path from the <paramref name="root"/>
    /// to a leaf <see cref="TreeNode"/> where the sum of
    /// all the <see cref="TreeNode"/> between them is
    /// equal to the <paramref name="targetSum"/>.
    /// </summary>
    /// <param name="root">The starting <see cref="TreeNode"/>.</param>
    /// <param name="targetSum">The sum to find.</param>
    /// <returns><see langword="true"/> if a path exists; otherwise <see langword="false"/>.</returns>
    public bool HasPathSum(TreeNode? root, int targetSum)
    {
        if (root is null)
        {
            // There are no leaf TreeNode, so do
            // not return true, even if the
            // targetSum is 0.
            return false;
        }

        return TraverseForSum(root, targetSum);


        // Traverses through the binary tree until
        // it finds a leaf TreeNode whose sum from
        // the root to that TreeNode is equal to
        // the targetSum.
        static bool TraverseForSum(TreeNode? node, int difference)
        {
            if (node is null)
            {
                return false;
            }

            difference -= node.val;
            if (node.left is null && node.right is null)
            {
                // We reached a leaf TreeNode; check if
                // the difference is zero.
                return difference == 0;
            }

            // Subtract the difference and check
            // the left and right subtrees.
            return TraverseForSum(node.left, difference)
                || TraverseForSum(node.right, difference);
        }
    }
}
