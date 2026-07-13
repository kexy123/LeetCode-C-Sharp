// RESULTS:
//      Submitted on 13 July 2026 at 19:09
//
//      31 / 31 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     46.08 MB

using Solution.LeetCodeImplementations;

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Builds a height-balanced binary search tree
    /// from the given sorted <see cref="int"/> array
    /// <paramref name="nums"/> where the subtrees of
    /// every <see cref="TreeNode"/> in the tree have
    /// a max depth that differ by at most one.
    /// </summary>
    /// <param name="nums">The sorted <see cref="int"/> array.</param>
    /// <returns>The starting <see cref="TreeNode"/>.</returns>
    public TreeNode SortedArrayToBST(int[] nums)
    {
        TreeNode root = new();

        Build(root, 0, nums.Length - 1);

        return root;


        // Builds the TreeNode's subtrees from the range
        // of the nums array.
        void Build(TreeNode node, int left, int right)
        {
            int mid = left + (right - left >> 1);
            node.val = nums[mid];

            if (mid == right)
            {
                // The mid is the midpoint between left and
                // right, with ties in favor of the left
                // pointer. Therefore, if mid == right, then
                // left == right too, meaning that there are
                // no other nodes to branch off to.
                return;
            }

            // Branch to the right node.
            node.right = new();
            Build(node.right, mid + 1, right);

            // If mid == left, then left and right are
            // right next to each other, and since we
            // already wrote the value for mid, we only
            // need to branch the right.
            if (mid != left)
            {
                // Otherwise, branch to the left node.
                node.left = new();
                Build(node.left, left, mid - 1);
            }
        }
    }
}
