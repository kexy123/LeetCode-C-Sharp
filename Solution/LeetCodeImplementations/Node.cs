namespace Solution.LeetCodeImplementations;

/// <summary>
/// Simplified definition of <see cref="node"/>
/// in 0116_PopulatingNextRightPointersInEachNode
/// and other questions. A binary tree node that
/// points to two other <see cref="Node"/> from
/// its <see cref="left/> and <see cref="right"/>,
/// stores a value and points to the <see cref="next"/>
/// <see cref="Node"/>. This is a mix of both the
/// <see cref="TreeNode"/> and the <see cref="ListNode"/>.
/// </summary>
public class Node
{
    /// <summary>
    /// The <see cref="int"/> value of <see cref="this"/>.
    /// </summary>
    public int val;

    /// <summary>
    /// The left part of the <see cref="Node"/>.
    /// </summary>
    public Node left;

    /// <summary>
    /// The right part of the <see cref="Node"/>.
    /// </summary>
    public Node right;

    /// <summary>
    /// The next <see cref="Node"/>.
    /// </summary>
    public Node next;

    /// <summary>
    /// Creates a <see cref="Node"/> instance with
    /// a <paramref name="val"/> (defaults to 0) and
    /// a <paramref name="left"/>, a <paramref name="right"/>,
    /// and a <paramref name="next"/> pointer to
    /// other <see cref="Node"/>.
    /// </summary>
    /// <param name="val">An <see cref="int"/> value. Defaults to 0.</param>
    /// <param name="left">The <see cref="Node"/> on the left.</param>
    /// <param name="right">The <see cref="Node"/> on the right.</param>
    /// <param name="next">The next <see cref="Node"/>.</param>
    public Node(int val = 0, Node? left = null, Node? right = null, Node? next = null)
    {
        this.val = val;
        this.left = left!;
        this.right = right!;
        this.next = next!;
    }
}
