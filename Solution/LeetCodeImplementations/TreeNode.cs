using System.Diagnostics;

namespace Solution.LeetCodeImplementations;

/// <summary>
/// Simplified definition of <see cref="TreeNode"/>
/// in 0094_BinaryTreeInorderReversal and other questions.
/// A binary tree node that points to two other
/// <see cref="TreeNode"/> from its <see cref="left"/>
/// and <see cref="right"/> and stores a value.
/// </summary>
[DebuggerDisplay("{ToString(),nq}")]
public class TreeNode
{
    /// <summary>
    /// The <see cref="int"/> value of <see cref="this"/>.
    /// </summary>
    public int val;

    /// <summary>
    /// The left part of the <see cref="TreeNode"/>.
    /// </summary>
    public TreeNode left;

    /// <summary>
    /// The right part of the <see cref="TreeNode"/>.
    /// </summary>
    public TreeNode right;

    /// <summary>
    /// Creates a <see cref="TreeNode"/> instance with
    /// a <paramref name="val"/> (defaults to 0) and
    /// a <paramref name="left"/> and <paramref name="right"/>
    /// pointer to other <see cref="TreeNode"/>.
    /// </summary>
    /// <param name="val">An <see cref="int"/> value. Defaults to 0.</param>
    /// <param name="left">The <see cref="TreeNode"/> on the left.</param>
    /// <param name="right">The <see cref="TreeNode"/> on the right.</param>
    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        this.val = val;
        this.left = left!;
        this.right = right!;
    }

    /// <summary>
    /// Converts the given <see cref="int"/> array
    /// <paramref name="tree"/> into a binary
    /// <see cref="TreeNode"/>, with <see cref="null"/>
    /// values preventing the creation of
    /// <see cref="TreeNode"/> instances.
    /// </summary>
    /// <remarks>
    /// This should only be used for debugging and
    /// unit-testing purposes.
    /// </remarks>
    /// <param name="tree">The <see cref="int"/> array.</param>
    public TreeNode(int?[] tree)
    {
        val = (int)tree[0]!;
        left = null!;
        right = null!;

        // Store the node and which direction to
        // add the new node in (false = left,
        // true = right).
        Queue<(TreeNode node, bool direction)> queue = [];
        queue.Enqueue((this, false));
        queue.Enqueue((this, true));

        int i = 1;
        while (i < tree.Length)
        {
            int endI = Math.Min(i + queue.Count, tree.Length);
            for (; i < endI; i++)
            {
                (TreeNode node, bool direction) = queue.Dequeue();
                if (tree[i] is null)
                {
                    continue;
                }

                TreeNode newNode = new((int)tree[i]!);
                if (direction)
                {
                    node.right = newNode;
                }
                else
                {
                    node.left = newNode;
                }

                queue.Enqueue((newNode, false));
                queue.Enqueue((newNode, true));
            }
        }
    }

    public override string ToString()
    {
        List<string> list = [];

        HashSet<TreeNode> visited = [];
        Queue<TreeNode?> nodes = [];
        nodes.Enqueue(this);

        while (nodes.Count is int length and > 0)
        {
            for (int i = 0; i < length; i++)
            {
                TreeNode? node = nodes.Dequeue();
                if (node is null)
                {
                    list.Add("null");
                }
                else if (!visited.Add(node))
                {
                    list.Add("!!!CYCLE!!!");
                }
                else
                {
                    list.Add(Convert.ToString(node.val));
                    nodes.Enqueue(node.left);
                    nodes.Enqueue(node.right);
                }
            }
        }

        // Remove trailing null string literals.
        while (list[^1] == "null")
        {
            list.RemoveAt(list.Count - 1);
        }

        return $"[{string.Join(", ", list)}]";
    }
}
