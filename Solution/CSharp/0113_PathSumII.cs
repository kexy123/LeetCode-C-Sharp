// RESULTS:
//      Submitted on 13 July 2026 at 21:57
//
//      115 / 115 testcases passed.
//
//      Runtime:    2 ms
//      Memory:     49.85 MB
//
// Borrowed from 0112_PathSum, but finds all possible
// path sums.

using Solution.LeetCodeImplementations;

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Returns all paths from the <paramref name="root"/>
    /// of the binary <see cref="TreeNode"/> to the leaf
    /// <see cref="TreeNode"/> whose sum is equal to the
    /// <paramref name="targetSum"/>.
    /// </summary>
    /// <param name="root">The starting <see cref="TreeNode"/>.</param>
    /// <param name="targetSum">The target sum.</param>
    /// <returns>An <see cref="IList{T}"/> containing paths of <see cref="int"/> whose sum adds to the <paramref name="targetSum"/>.</returns>
    public IList<IList<int>> PathSum(TreeNode? root, int targetSum)
    {
        IList<IList<int>> paths = [];

        IList<int> currentPath = [];
        TraverseForPaths(root, targetSum);

        return paths;


        void TraverseForPaths(TreeNode? node, int difference)
        {
            if (node is null)
            {
                return;
            }

            currentPath.Add(node.val);
            difference -= node.val;
            if (node.left is null && node.right is null)
            {
                if (difference == 0)
                {
                    // Add the path as its sum is the targetSum.
                    paths.Add([.. currentPath]);
                }

                currentPath.RemoveAt(currentPath.Count - 1);

                // Prevent unnecessary calls to TraverseForPaths.
                return;
            }

            TraverseForPaths(node.left, difference);
            TraverseForPaths(node.right, difference);

            // Remove node element after traversal of
            // its subtrees.
            currentPath.RemoveAt(currentPath.Count - 1);
        }
    }
}
