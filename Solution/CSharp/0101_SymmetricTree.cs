// RESULTS:
//      Submitted on 13 July 2026 at 02:31
//
//      201 / 201 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     44.06 MB

using Solution.LeetCodeImplementations;

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Checks if a <see cref="TreeNode"/> is symmetric;
    /// the structure and values of its left subtree are
    /// a perfect mirror to its right subtree.
    /// </summary>
    /// <param name="root">The root <see cref="ListNode"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="root"/> is symmetrical; otherwise <see langword="false"/>.</returns>
    public bool IsSymmetric(TreeNode root)
    {
        return Compare(root.left, root.right);


        // Checks if the structure and values of
        // the left node is symmetrical to the
        // right node.
        static bool Compare(TreeNode? left, TreeNode? right)
        {
            if (left is null)
            {
                return right is null;
            }
            else if (right is null)
            {
                return left is null;
            }

            if (left.val != right.val)
            {
                // The values are not the same.
                return false;
            }

            // Compare the left of left with the right of right
            // and the right of left with the left of right.
            return Compare(left.left, right.right)
                && Compare(left.right, right.left);
        }
    }
}
