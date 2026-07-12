// RESULTS:
//      Submitted on 13 July 2026 at 02:51
//
//      33 / 33 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     46.60 MB
//
// Directly borrowed from 0102_BinaryTreeLevelOrderTraversal,
// just with a tracked current level and check to reverse
// the array indices or not.

using Solution.LeetCodeImplementations;

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Returns an <see cref="IList{T}"/> of levels that
    /// refer to the value of the <see cref="TreeNode"/>
    /// at those levels from the top (the <paramref name="root"/>)
    /// to the bottom. However, it is traversed in a
    /// zigzag pattern; the first level is left-to-right,
    /// then the second level is right-to-left, etc.
    /// </summary>
    /// <param name="root">The starting <see cref="TreeNode"/>.</param>
    /// <returns>The <see cref="IList{T}"/> of levels.</returns>
    public IList<IList<int>> ZigzagLevelOrder(TreeNode? root)
    {
        if (root is null)
        {
            return [];
        }

        IList<IList<int>> levels = [];

        Queue<TreeNode> queue = [];
        queue.Enqueue(root);

        // Note that currentLevel is 0-indexed.
        int currentLevel = 0;
        while (queue.Count > 0)
        {
            int length = queue.Count;

            int[] level = new int[length];

            for (int i = 0; i < length; i++)
            {
                TreeNode node = queue.Dequeue();
                if ((currentLevel & 1) == 0)
                {
                    // Left to right for every even currentLevel.
                    level[i] = node.val;
                }
                else
                {
                    // Right to left for every odd currentLevel.
                    level[^(i + 1)] = node.val;
                }

                if (node.left is TreeNode left)
                {
                    queue.Enqueue(left);
                }

                if (node.right is TreeNode right)
                {
                    queue.Enqueue(right);
                }
            }

            levels.Add(level);

            currentLevel++;
        }

        return levels;
    }
}
