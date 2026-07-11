// RESULTS:
//      Submitted on 11 July 2026 at 23:23
//
//      71 / 71 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     46.45 MB

namespace Solution;

/// <summary>
/// Simplified definition of <see cref="TreeNode"/>
/// in 94_BinaryTreeInorderReversal and other questions.
/// A binary tree node that points to two other
/// <see cref="TreeNode"/> from its <see cref="left"/>
/// and <see cref="right"/> and stores a value.
/// </summary>
public class TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
{
    /// <summary>
    /// The <see cref="int"/> value of <see cref="this"/>.
    /// </summary>
    public int val = val;

    /// <summary>
    /// The left part of the <see cref="TreeNode"/>.
    /// </summary>
    public TreeNode left = left!;

    /// <summary>
    /// The right part of the <see cref="TreeNode"/>.
    /// </summary>
    public TreeNode right = right!;
}

public partial class Solution
{
    /// <summary>
    /// Computes the in-order traversal of the values
    /// of the <see cref="TreeNode"/> starting from
    /// <paramref name="root"/>.
    /// </summary>
    /// <param name="root">The starting <see cref="TreeNode"/>.</param>
    /// <returns>The in-order traversal.</returns>
    public IList<int> InorderTraversal(TreeNode root)
    {
        IList<int> inOrder = [];

        Traverse(root);

        return inOrder;


        // A depth-first search function that runs
        // itself on the left of its node, adds the
        // value of node to the in-order list, then
        // runs itself on the right of its node.
        void Traverse(TreeNode? node)
        {
            if (node is null)
            {
                return;
            }

            Traverse(node.left);
            inOrder.Add(node.val);
            Traverse(node.right);
        }
    }
}
