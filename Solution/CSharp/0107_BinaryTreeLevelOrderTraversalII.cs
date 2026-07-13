// RESULTS:
//      Submitted on 13 July 2026 at 18:30
//
//      34 / 34 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     47.03 MB
//
// Directly copied from 0102_BinaryTreeLevelOrderTraversal,
// just that the elements are inserted in reverse order.

using Solution.LeetCodeImplementations;

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Returns an <see cref="IList{T}"/> of levels that
    /// refer to the value of the <see cref="TreeNode"/>
    /// at those levels from the top (the <paramref name="root"/>)
    /// to the bottom.
    /// </summary>
    /// <param name="root">The starting <see cref="TreeNode"/>.</param>
    /// <returns>The <see cref="IList{T}"/> of levels.</returns>
    public IList<IList<int>> LevelOrderBottom(TreeNode? root)
    {
        if (root is null)
        {
            return [];
        }

        IList<IList<int>> levels = [];

        Queue<TreeNode> queue = [];
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            int length = queue.Count;

            int[] level = new int[length];

            for (int i = 0; i < length; i++)
            {
                TreeNode node = queue.Dequeue();
                level[i] = node.val;

                if (node.left is TreeNode left)
                {
                    queue.Enqueue(left);
                }

                if (node.right is TreeNode right)
                {
                    queue.Enqueue(right);
                }
            }

            levels.Insert(0, level);
        }

        return levels;
    }
}
