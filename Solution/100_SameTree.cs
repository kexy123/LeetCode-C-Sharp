// RESULTS:
//      Submitted on 12 July 2026 at 22:20
//
//      67 / 67 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     42.97 MB

using Solution.LeetCodeImplementations;

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Checks if <paramref name="p"/> and
    /// <paramref name="q"/> have the same
    /// <see cref="TreeNode"/> structure
    /// and values.
    /// </summary>
    /// <param name="p">The first <see cref="TreeNode"/>.</param>
    /// <param name="q">The second <see cref="TreeNode"/>.</param>
    /// <returns><see langword="true"/> if both trees have the same structure, otherwise <see langword="false"/>.</returns>
    public bool IsSameTree(TreeNode? p, TreeNode? q)
    {
        // Null checks; check if both parameters
        // are null. If they are, they are the
        // same tree.
        if (p is null)
        {
            return q is null;
        }
        else if (q is null)
        {
            return p is null;
        }

        if (p.val != q.val)
        {
            // Their values are not equal.
            return false;
        }

        // Check if both the left and right trees
        // are the same.
        return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
    }
}
