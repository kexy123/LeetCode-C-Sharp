// RESULTS:
//      Submitted on 12 July 2026 at 18:29
//
//      86 / 86 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     45.93 MB

using Solution.LeetCodeImplementations;

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Checks if the given <see cref="TreeNode"/> is a
    /// binary-search tree, where all nodes in its left
    /// subtree are strictly less than the value of the
    /// <see cref="TreeNode"/>, and the value of the
    /// <see cref="TreeNode"/> is strictly less than all
    /// the nodes in its right subtree, and the same
    /// property must apply to all the <see cref="TreeNode"/>
    /// instances.
    /// </summary>
    /// <param name="root">The starting <see cref="TreeNode"/>.</param>
    /// <returns><see langword="true"/> if it is a valid binary search tree; otherwise <see langword="false"/>.</returns>
    public bool IsValidBST(TreeNode root)
    {
        // TreeNode values can be from -2,147,483,648 to
        // 2,147,483,647, so use a long to go past that
        // boundary and avoid null checks on if-statements.
        long minValue = long.MinValue;

        return ValidRoot(root);


        // Checks if the current TreeNode is a valid binary
        // search tree by recursively checking its left
        // and right subtrees and comparing their values.
        bool ValidRoot(TreeNode node)
        {
            // Checks if the value of the left node is less
            // than or equal to the value of this node or
            // if the left subtree is invalid.
            if (node.left is TreeNode left && (left.val <= minValue || !ValidRoot(left)))
            {
                return false;
            }

            // Checks if the current value of this node is
            // less than or equal to the highest value found
            // in its left subtree.
            if (node.val <= minValue)
            {
                return false;
            }

            // minValue will always be set to the next lowest
            // element in the tree.
            minValue = node.val;

            // Checks if the value of this node is less than
            // or equal to the value of the right node or if
            // the right subtree is invalid.
            if (node.right is TreeNode right && (right.val <= minValue || !ValidRoot(right)))
            {
                return false;
            }

            // The node is a valid binary search tree.
            return true;
        }
    }
}
