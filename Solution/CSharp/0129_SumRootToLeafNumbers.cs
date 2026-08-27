// RESULTS:
//      Submitted on 13 August 2026 at 14:49
//
//      108 / 108 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     41.61 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Sums all possible root-to-leaf numbers in the tree of digits starting at the
    /// <paramref name="root"/>. A root-to-leaf number contains all the digits from the
    /// <paramref name="root"/> to a leaf node.
    /// </summary>
    /// <param name="root">The starting <see cref="TreeNode"/>.</param>
    /// <returns>The sum of all root-to-leaf numbers.</returns>
    public int SumNumbers(TreeNode root)
    {
        int total = 0;

        Traverse(root, root.val);

        return total;


        // Traverses via depth-first search and modifies the currentSum. If the subroutine reaches a
        // leaf node, it adds it to the total.
        void Traverse(TreeNode node, int currentSum)
        {
            if (node.left is null && node.right is null)
            {
                // The node is a leaf node, so add to the total.
                total += currentSum;
            }

            // Traverse on the left and right, appending the digit.
            if (node.left is TreeNode left)
            {
                Traverse(left, currentSum * 10 + left.val);
            }

            if (node.right is TreeNode right)
            {
                Traverse(right, currentSum * 10 + right.val);
            }
        }
    }
}
