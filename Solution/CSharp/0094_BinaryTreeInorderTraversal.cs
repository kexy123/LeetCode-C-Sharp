// RESULTS:
//      Submitted on 11 July 2026 at 23:23
//
//      71 / 71 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     46.45 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Performs the preorder traversal of the values of the binary tree starting from the
    /// <paramref name="root"/>, where a <see cref="TreeNode"/> in preorder form is
    /// <c>T(<see cref="TreeNode"/>) => [..T(<see cref="TreeNode.left"/>), <see cref="TreeNode.val"/>,
    /// ..T(<see cref="TreeNode.right"/>)]</c> if the given <see cref="TreeNode"/> is
    /// not <see langword="null"/>.
    /// </summary>
    /// <param name="root">The starting <see cref="TreeNode"/>.</param>
    /// <returns>The inorder traversal.</returns>
    public IList<int> InorderTraversal(TreeNode root)
    {
        IList<int> inorder = [];

        Traverse(root);

        return inorder;


        // A depth-first search function that runs itself on the left of its node, adds the value of
        // the node to the inorder list, then runs itself on the right of its node.
        void Traverse(TreeNode? node)
        {
            if (node is null)
            {
                return;
            }

            Traverse(node.left);
            inorder.Add(node.val);
            Traverse(node.right);
        }
    }
}
