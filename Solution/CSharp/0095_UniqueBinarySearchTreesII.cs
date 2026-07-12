// RESULTS:
//      Submitted on 12 July 2026 at 06:22
//
//      8 / 8 testcases passed.
//
//      Runtime:    3 ms
//      Memory:     44.19 MB
//
// Struggled with generating unique structural binary
// trees because of missing slices of the nodesLeft,
// so looked up an efficient solution for that to see
// that it wasn't efficient at all.

using Solution.LeetCodeImplementations;

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Generates all binary search trees of unique structure
    /// with <paramref name="n"/> <see cref="TreeNode"/> instances,
    /// each value in each <see cref="TreeNode"/> is a unique
    /// number from 1 to <paramref name="n"/>.
    /// </summary>
    /// <param name="n">The number of nodes for each binary search tree.</param>
    /// <returns>An <see cref="IList{T}"/> of all unique binary search trees.</returns>
    public IList<TreeNode> GenerateTrees(int n)
    {
        List<TreeNode> trees = Generate(n)!;

        // Satisfy binary search on all generated trees.
        int binarySearchNum;
        foreach (TreeNode tree in trees)
        {
            binarySearchNum = 1;
            SatisfyBinarySearch(tree);
        }

        return trees;


        // A recursive algorithm that generates all
        // structurally unique binary trees of nodesLeft
        // number of nodes.
        List<TreeNode?> Generate(int nodesLeft)
        {
            if (nodesLeft <= 0)
            {
                // This method must have at least one
                // collection so that foreach loops can
                // execute at least once.
                return [null];
            }

            List<TreeNode?> nodes = [];

            // Split the number of nodesLeft into two
            // parts that sum to nodesLeft, each one
            // being given to the left and right.
            for (int left = 0; left < nodesLeft; left++)
            {
                int right = nodesLeft - left - 1;

                foreach (TreeNode? leftItem in Generate(left))
                {
                    foreach (TreeNode? rightItem in Generate(right))
                    {
                        // Add to nodes list the generated TreeNode,
                        // otherwise point to null reference.
                        nodes.Add(new(left: leftItem, right: rightItem));
                    }
                }
            }

            return nodes;
        }

        // Ensures that the given TreeNode is
        // a binary search tree, where the left
        // node is smaller than the node which
        // is smaller then the right node.
        void SatisfyBinarySearch(TreeNode? node)
        {
            if (node is null)
            {
                return;
            }

            SatisfyBinarySearch(node.left);
            node.val = binarySearchNum++;
            SatisfyBinarySearch(node.right);
        }
    }
}
