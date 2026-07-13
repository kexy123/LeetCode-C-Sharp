// RESULTS:
//      Submitted on 13 July 2026 at 19:30
//
//      32 / 32 testcases passed.
//
//      Runtime:    1 ms
//      Memory:     49.29 MB
//
// Directly copied from 0108_ConvertSortedArrayToBinarySearchTree,
// but simply transforming the linked ListNode to an array and
// adding an empty ListNode check to return an empty tree.

using Solution.LeetCodeImplementations;

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Builds a height-balanced binary search tree
    /// from the given sorted <see cref="int"/> linked
    /// <see cref="ListNode"/> <paramref name="nums"/>
    /// where the subtrees of every <see cref="TreeNode"/>
    /// in the tree have a max depth that differ by at
    /// most one.
    /// </summary>
    /// <param name="nums">The starting <see cref="ListNode"/>.</param>
    /// <returns>The starting <see cref="TreeNode"/>.</returns>
    public TreeNode? SortedListToBST(ListNode? nums)
    {
        if (nums is null)
        {
            // Avoid an ArgumentOutOfRangeException from
            // a faulty right pointer, and simply return
            // an empty tree.
            return null;
        }

        // Convert to array.
        List<int> numList = [];
        while (nums is not null)
        {
            numList.Add(nums.val);
            nums = nums.next;
        }

        TreeNode root = new();

        Build(root, 0, numList.Count - 1);

        return root;


        void Build(TreeNode node, int left, int right)
        {
            int mid = left + (right - left >> 1);
            node.val = numList[mid];

            if (mid == right)
            {
                return;
            }

            node.right = new();
            Build(node.right, mid + 1, right);

            if (mid != left)
            {
                node.left = new();
                Build(node.left, left, mid - 1);
            }
        }
    }
}
