namespace Solution.LeetCodeImplementations.CloneGraph_0133;

/// <summary>
/// Simplified definition of <see cref="Node"/> in
/// 0133_CloneGraph: a bidirectional graph node that
/// stores a value and connects to an arbitrary number
/// of <see cref="Node"/> that are considered its
/// <see cref="neighbors"/>. Two <see cref="Node"/>
/// connected by an edge must contain each other in its
/// <see cref="neighbors"/> field.
/// </summary>
public class Node
{
    /// <summary>
    /// The value of the <see cref="Node"/> instance.
    /// </summary>
    public int val;

    /// <summary>
    /// The neighboring <see cref="Node"/> instances that it's pointing to.
    /// </summary>
    public IList<Node> neighbors;


    /// <summary>
    /// Creates a lone <see cref="Node"/> instance.
    /// </summary>
    /// <param name="_val">The value of the <see cref="Node"/>. Defaults to 0.</param>
    public Node(int _val = 0)
    {
        val = _val;
        neighbors = [];
    }

    /// <summary>
    /// Creates a <see cref="Node"/> instance that connects to neighboring
    /// <see cref="Node"/> instances.
    /// </summary>
    /// <param name="_val">The value of the <see cref="Node"/>.</param>
    /// <param name="_neighbors">An <see cref="IList{T}"/> of its neighboring nodes.</param>
    public Node(int _val, IList<Node> _neighbors)
    {
        val = _val;
        neighbors = _neighbors;
    }
}
