// RESULTS:
//      Submitted on 13 July 2026 at 02:45
//
//      35 / 35 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     48.32 MB

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
    public IList<IList<int>> LevelOrder(TreeNode? root)
    {
        if (root is null)
        {
            // There are no levels in an empty tree.
            return [];
        }

        IList<IList<int>> levels = [];

        // The root is the first level.
        Queue<TreeNode> queue = [];
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            int length = queue.Count;

            int[] level = new int[length];

            // Loop over all the elements at the
            // current level, adding their values
            // to the level list. We additionally
            // also reuse the queue as we know
            // exactly how many nodes to dequeue
            // per level.
            for (int i = 0; i < length; i++)
            {
                TreeNode node = queue.Dequeue();
                level[i] = node.val;

                // Add child nodes left to right if
                // they are not null.
                if (node.left is TreeNode left)
                {
                    queue.Enqueue(left);
                }

                if (node.right is TreeNode right)
                {
                    queue.Enqueue(right);
                }
            }

            // Add collection to levels.
            levels.Add(level);
        }

        return levels;
    }
}
