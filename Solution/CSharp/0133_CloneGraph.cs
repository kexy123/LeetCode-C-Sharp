// RESULTS:
//      Submitted on 15 August 2026 at 15:46
//
//      22 / 22 testcases passed.
//
//      Runtime:    138 ms
//      Memory:     49.63 MB

using Node = Solution.LeetCodeImplementations.CloneGraph_0133.Node;

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Deep clones a graph of <see cref="Node"/> instances.
    /// </summary>
    /// <param name="node">One of the <see cref="Node"/> instances in the graph.</param>
    /// <returns>The cloned graph starting at the duplicate of <paramref name="node"/>.</returns>
    public Node? CloneGraph(Node? node)
    {
        if (node is null)
        {
            return null;
        }

        Dictionary<Node, Node> clonedNodes = [];
        Queue<Node> queue = [];
        queue.Enqueue(node);
        while (queue.TryDequeue(out Node? currentNode))
        {
            // Create a new clone of the currentNode.
            clonedNodes[currentNode] = new(currentNode.val);

            foreach (Node neighbor in currentNode.neighbors)
            {
                if (!clonedNodes.ContainsKey(neighbor))
                {
                    // Enqueue the next Node to clone.
                    queue.Enqueue(neighbor);
                }
            }
        }

        foreach (KeyValuePair<Node, Node> entry in clonedNodes)
        {
            // Connect the neighbors of the clone to other clones
            // that correspond to the original.
            foreach (Node neighbor in entry.Key.neighbors)
            {
                entry.Value.neighbors.Add(clonedNodes[neighbor]);
            }
        }

        return clonedNodes[node];
    }
}
