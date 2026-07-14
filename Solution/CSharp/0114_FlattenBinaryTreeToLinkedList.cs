// RESULTS:
//      Submitted on 14 July 2026 at 15:01
//
//      225 / 225 testcases passed.
//
//      Runtime:    4 ms
//      Memory:     43.11 MB
//
// This solution is solved in-place with O(1) extra
// memory, although it is slower.

using Solution.LeetCodeImplementations;

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Transform the given binary tree such that
    /// traversing the <see cref="TreeNode.right"/>
    /// will lead to the next element in the preorder
    /// traversal of the binary tree.
    /// </summary>
    /// <param name="root">The starting <see cref="TreeNode"/>.</param>
    public void Flatten(TreeNode? root)
    {
        if (root is null)
        {
            // No transformation is needed.
            return;
        }

        TreeNode current = root;
        TreeNode? lastRight = null;
        while (current is not null)
        {
            if (current.right is not null)
            {
                // Set lastRight to the last element that
                // contains a right TreeNode.
                lastRight = current;
            }

            if (current.left is null)
            {
                if (lastRight is null)
                {
                    // The entire binary tree is in
                    // pre-order traversal, so break early.
                    break;
                }

                // Move lastRight to current.left and
                // reset both lastRight and current.
                current.left = lastRight.right;
                lastRight.right = null!;
                lastRight = null;

                current = root;
            }
            else
            {
                // Move to the left-most tree.
                current = current.left!;
            }
        }

        // Mirror the binary tree. Note that the
        // tree is left-skewed.
        current = root;
        while (current is not null)
        {
            (current, current.right, current.left) = (current.left, current.left, null!);
        }
    }
}
