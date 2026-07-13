// RESULTS:
//      Submitted on 13 July 2026 at 18:27
//
//      202 / 202 testcases passed.
//
//      Runtime:    1 ms
//      Memory:     45.06 MB
//
// Directly copied from 0105_ConstructBinaryTreeFromPreorderAndInorderTraversal,
// but reversed the index direction and checked when it reaches out of bounds.

using Solution.LeetCodeImplementations;

namespace Solution.CSharp.ConstructBinaryTreeFromInorderAndPostorderTraversal_0106;

public partial class Solution
{
    /// <summary>
    /// Builds a binary tree from the given
    /// <paramref name="inorder"/> and
    /// <paramref name="postorder"/> traversal
    /// <see cref="int"/> arrays.
    /// </summary>
    /// <param name="inorder">The inorder <see cref="int"/> array.</param>
    /// <param name="postorder">The postorder <see cref="int"/> array.</param>
    /// <returns>The starting <see cref="TreeNode"/> of the binary tree.</returns>
    public TreeNode BuildTree(int[] inorder, int[] postorder)
    {
        Dictionary<int, int> inorderIndices = [];
        for (int i = 0; i < inorder.Length; i++)
        {
            int element = inorder[i];
            inorderIndices.Add(element, i);
        }

        TreeNode root = new();

        int postorderIndex = postorder.Length - 1;
        Build(root, 0, postorderIndex);

        return root;


        void Build(TreeNode node, int leftBound, int rightBound)
        {
            int value = postorder[postorderIndex];
            node.val = value;

            int midIndex = inorderIndices[value];
            for (int _ = 0; _ < 2; _++)
            {
                if (--postorderIndex < 0)
                {
                    return;
                }

                int firstIndex = inorderIndices[postorder[postorderIndex]];
                if (firstIndex < leftBound || firstIndex > rightBound)
                {
                    postorderIndex++;
                    break;
                }

                if (firstIndex < midIndex)
                {
                    node.left = new();
                    Build(node.left, leftBound, midIndex - 1);
                }
                else
                {
                    node.right = new();
                    Build(node.right, midIndex + 1, rightBound);
                }
            }
        }
    }
}
