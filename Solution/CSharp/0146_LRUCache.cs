// RESULTS:
//      Submitted on 27 August 2026 at 19:41
//
//      23 / 23 testcases passed.
//
//      Runtime:    8 ms
//      Memory:     75.36 MB

namespace Solution.CSharp;

public partial class Solution;

/// <summary>
/// A cache class with a given <see cref="Capacity"/> that evicts the least-recently used (LRU) cache
/// entries in terms of access and assignment.
/// </summary>
public class LRUCache
{
    /// <summary>
    /// A cache entry that stores the <see cref="Value"/> and the assigned <see cref="RecencyNode"/>.
    /// </summary>
    private class CacheEntry()
    {
        /// <summary>
        /// The stored <see langword="int"/> value.
        /// </summary>
        public required int Value;

        /// <summary>
        /// The <see cref="LinkedListNode{T}"/> that this <see cref="CacheEntry"/> instance is
        /// assigned to.
        /// </summary>
        public required LinkedListNode<int> RecencyNode;
    }

    /// <summary>
    /// A doubly-linked list of <see langword="int"/> keys to the <see cref="_entries"/> dictionary.
    /// </summary>
    private readonly LinkedList<int> _recency = [];

    /// <summary>
    /// A dictionary that stores an <see langword="int"/> key to a <see cref="CacheEntry"/> instance.
    /// </summary>
    private readonly Dictionary<int, CacheEntry> _entries = [];

    /// <summary>
    /// The maximum number of cache entries that this <see cref="LRUCache"/> can hold before having to
    /// evict least-recently used cache entries.
    /// </summary>
    public int Capacity { get; private set; }


    /// <summary>
    /// Creates an <see cref="LRUCache"/> instance with the given <paramref name="capacity"/>.
    /// </summary>
    /// <param name="capacity">The maximum number of cache entries.</param>
    public LRUCache(int capacity)
    {
        Capacity = capacity;
    }

    /// <summary>
    /// Retrieves the value at the given <paramref name="key"/> in O(1) average time complexity.
    /// Returns -1 if no value was found in any cache entries.
    /// </summary>
    /// <param name="key">The <see langword="int"/> key to access.</param>
    /// <returns>The value at that <paramref name="key"/>; otherwise -1.</returns>
    public int Get(int key)
    {
        if (_entries.TryGetValue(key, out CacheEntry? cacheEntry))
        {
            // This cacheEntry was accessed, so move it to the most-recent position in the LinkedList.
            _recency.Remove(cacheEntry.RecencyNode);
            _recency.AddLast(cacheEntry.RecencyNode);

            return cacheEntry.Value;
        }

        return -1;
    }

    /// <summary>
    /// Adds or reassigns a given <paramref name="key"/> to a <paramref name="value"/>, and evicts the
    /// least-recently used cache entry if this <see cref="LRUCache"/> instance exceeds the
    /// <see cref="Capacity"/> in O(1) average time complexity.
    /// </summary>
    /// <param name="key">The <see langword="int"/> key to assign or add.</param>
    /// <param name="value">The <see langword="int"/> value to assign to.</param>
    public void Put(int key, int value)
    {
        if (_entries.TryGetValue(key, out CacheEntry? cacheEntry))
        {
            // This cacheEntry was recently accessed.
            _recency.Remove(cacheEntry.RecencyNode);
            _recency.AddLast(cacheEntry.RecencyNode);

            cacheEntry.Value = value;

            return;
        }

        if (_entries.Count >= Capacity)
        {
            // The number of entries will overflow, so remove the very first LinkedListNode from the
            // LinkedList. The LinkedList is managed in such a way that it is ordered from
            // least-recently used to most-recently used from First to Last, so we can simply remove
            // the First element and its CacheEntry, which are O(1) operations.
            _entries.Remove(_recency.First!.Value);
            _recency.RemoveFirst();
        }

        // Add the entry as the most-recent entry.
        _entries[key] = new CacheEntry()
        {
            Value = value,
            RecencyNode = _recency.AddLast(key)
        };
    }
}
