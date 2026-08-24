// RESULTS:
//      Submitted on 24 August 2026 at 20:17
//
//      71 / 71 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     46.25 MB
//
// Unlike 0094_BinaryTreeInorderTraversal, this is an iterative approach as per the follow-up question.

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Performs the preorder traversal of the values of the binary tree starting from the
    /// <paramref name="root"/>, where a <see cref="TreeNode"/> in preorder form is
    /// <c>T(<see cref="TreeNode"/>) => [<see cref="TreeNode.val"/>,
    /// ..T(<see cref="TreeNode.left"/>), ..T(<see cref="TreeNode.right"/>)]</c> if the given
    /// <see cref="TreeNode"/> is not <see langword="null"/>.
    /// </summary>
    /// <param name="root">The starting <see cref="TreeNode"/> instance.</param>
    /// <returns>The preorder traversal.</returns>
    public IList<int> PreorderTraversal(TreeNode? root)
    {
        if (root is null)
        {
            // Return an empty array because there are no TreeNode instances.
            return [];
        }

        IList<int> result = [];

        Stack<TreeNode> stack = [];
        stack.Push(root);
        while (stack.TryPop(out TreeNode? node))
        {
            // Preorder form: [Main, Left, Right].
            result.Add(node.val);

            if (node.right is TreeNode right)
            {
                // Push the right node.
                stack.Push(right);
            }

            if (node.left is TreeNode left)
            {
                // Push the left node. Ensure this node is done first.
                stack.Push(left);
            }
        }

        return result;
    }
}
