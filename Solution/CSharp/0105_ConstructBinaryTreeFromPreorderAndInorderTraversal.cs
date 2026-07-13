// RESULTS:
//      Submitted on 13 July 2026 at 18:19
//
//      203 / 203 testcases passed.
//
//      Runtime:    1 ms
//      Memory:     44.79 MB

using Solution.LeetCodeImplementations;

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Builds a binary tree from the given
    /// <paramref name="inorder"/> and
    /// <paramref name="preorder"/> traversal
    /// <see cref="int"/> arrays.
    /// </summary>
    /// <param name="preorder">The preorder <see cref="int"/> array.</param>
    /// <param name="inorder">The inorder <see cref="int"/> array.</param>
    /// <returns>The starting <see cref="TreeNode"/> of the binary tree.</returns>
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        // Convert inorder array to a Dictionary
        // of elements to indices knowing that
        // inorder contains unique elements. This
        // reduces O(n^2) to O(n) since an index
        // has on average O(1) time complexity.
        Dictionary<int, int> inorderIndices = [];
        for (int i = 0; i < inorder.Length; i++)
        {
            int element = inorder[i];
            inorderIndices.Add(element, i);
        }

        TreeNode root = new();

        int preorderIndex = 0;
        Build(root, 0, preorder.Length - 1);

        return root;


        // Builds the binary tree from both the
        // preorder and inorder traversal arrays.
        // Preorder arrays will always have at
        // most the next two nodes after a node.
        // This means that the left node will
        // always be directly right of its parent.
        void Build(TreeNode node, int leftBound, int rightBound)
        {
            int value = preorder[preorderIndex];
            node.val = value;

            int midIndex = inorderIndices[value];
            for (int _ = 0; _ < 2; _++)
            {
                if (++preorderIndex >= preorder.Length)
                {
                    // We reached the end of the preorder
                    // array, so the binary tree is built.
                    return;
                }

                int firstIndex = inorderIndices[preorder[preorderIndex]];
                if (firstIndex < leftBound || firstIndex > rightBound)
                {
                    // The inorder index at that point is
                    // out of bounds with where it's supposed
                    // to be, so decrement it to make sure
                    // that other recursive calls can access
                    // it to put the element at the correct
                    // spot.
                    preorderIndex--;
                    break;
                }

                if (firstIndex < midIndex)
                {
                    // The element is within range and left to
                    // its parent in the inorder array.
                    node.left = new();
                    Build(node.left, leftBound, midIndex - 1);
                }
                else
                {
                    // The element is right to the its parent
                    // in the inorder array.
                    node.right = new();
                    Build(node.right, midIndex + 1, rightBound);
                }
            }
        }
    }
}
