namespace Solution.LeetCodeImplementations;

/// <summary>
/// Simplified definition of <see cref="TreeNode"/>
/// in 0094_BinaryTreeInorderReversal and other questions.
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
