// RESULTS:
//      Submitted on 12 July 2026 at 21:52
//
//      1919 / 1919 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     49.74 MB
//
// TODO: Do follow-up problem with Morris traversal
// to make the algorithm run with only O(1) space
// complexity.

using Solution.LeetCodeImplementations;

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Recovers a corrupt binary search tree where
    /// exactly two <see cref="TreeNode"/> instances
    /// had their values swapped.
    /// </summary>
    /// <param name="root">The starting <see cref="TreeNode"/>.</param>
    public void RecoverTree(TreeNode root)
    {
        TreeNode? first = null, second = null;

        long minValue = long.MinValue;
        TreeNode min = null!;

        InorderTraverse(root);

        (first!.val, second!.val) = (second.val, first.val);


        // Traverses the binary tree in-order. When
        // traversing the tree in-order on a binary
        // search tree, the elements it passes through
        // must always be in ascending order, with
        // every element being greater than the
        // previous.
        void InorderTraverse(TreeNode node)
        {
            if (node.left is not null)
            {
                // Traverse the left subtree.
                InorderTraverse(node.left);
            }

            if (node.val > minValue)
            {
                minValue = node.val;
            }
            else
            {
                // There are only two cases where the
                // binary search tree may be unordered
                // thanks to a discussion post that
                // pointed it out:
                //
                // Traverse the tree in-order and consider
                // it as the element array. If only one
                // pair is in descending order, swap
                // those elements around. If two pairs
                // are in descending order (including
                // overlapping pairs), swap the first
                // element of the first pair with the
                // second element of the second pair.
                //
                // This means that the first ListNode
                // only has to be assigned once, while
                // the second is dynamic.
                first ??= min;
                second = node;
            }
            min = node;

            if (node.right is not null)
            {
                // Traverse the right subtree.
                InorderTraverse(node.right);
            }
        }
    }
}
