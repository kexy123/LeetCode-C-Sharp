// RESULTS:
//      Submitted on 24 August 2026 at 22:04
//
//      71 / 71 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     46.50 MB
//
// Directly borrowed from 0144_BinaryTreePreorderTraversal, but swaps and then reverses the result.

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Performs the postorder traversal of the values of the binary tree starting from the
    /// <paramref name="root"/>, where a <see cref="TreeNode"/> in preorder form is
    /// <c>T(<see cref="TreeNode"/>) => [..T(<see cref="TreeNode.left"/>),
    /// ..T(<see cref="TreeNode.right"/>), <see cref="TreeNode.val"/>]</c> if the given
    /// <see cref="TreeNode"/> is not <see langword="null"/>.
    /// </summary>
    /// <param name="root">The starting <see cref="TreeNode"/> instance.</param>
    /// <returns>The preorder traversal.</returns>
    public IList<int> PostorderTraversal(TreeNode? root)
    {
        if (root is null)
        {
            return [];
        }

        List<int> result = [];

        Stack<TreeNode> stack = [];
        stack.Push(root);
        while (stack.TryPop(out TreeNode? node))
        {
            // Reversed preorder form: [Main, Right, Left].
            result.Add(node.val);

            if (node.left is TreeNode left)
            {
                stack.Push(left);
            }

            if (node.right is TreeNode right)
            {
                stack.Push(right);
            }
        }

        // By reversing the result, it turns into the postorder form: [Left, Right, Main].
        result.Reverse();
        return result;
    }
}
