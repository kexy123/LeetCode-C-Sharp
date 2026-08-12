// RESULTS:
//      Submitted on 12 August 2026 at 23:36
//
//      38 / 38 testcases passed.
//
//      Runtime:    23 ms
//      Memory:     56.16 MB
//
// This was an extremely difficult question, and I took a long break
// from LeetCode because of it as well. I looked up a solution which
// included a bidirectional breadth-first search algorithm, until I
// found a more memory-efficient method by creating a custom class
// for this problem.

namespace Solution.CSharp;

/// <summary>
/// A tree node that stores a <see cref="Word"/> and references to other
/// <see cref="WordNode"/> instances that are the shortest routes to the
/// starting word.
/// </summary>
file sealed class WordNode
{
    /// <summary>
    /// The assigned word to this <see cref="WordNode"/> instance.
    /// </summary>
    public required string Word;

    /// <summary>
    /// A <see cref="List{T}"/> of the nodes before this <see cref="WordNode"/>
    /// instance that are the shortest paths to the starting word.
    /// </summary>
    public List<WordNode> ShortestPaths = [];


    /// <summary>
    /// A depth-first search algorithm that traverses through the tree at
    /// the shortest paths, adding the <paramref name="currentSequence"/>
    /// to the <paramref name="sequence"/> once it reaches the starting
    /// <see cref="WordNode"/>.
    /// </summary>
    /// <param name="sequence">The <see cref="IList{T}"/> to add sequences to.</param>
    /// <param name="currentSequence">The <see cref="IList{T}"/> to modify. This should be empty when called at the root.</param>
    public void Traverse(IList<IList<string>> sequence, IList<string> currentSequence)
    {
        currentSequence.Add(Word);

        if (ShortestPaths.Count is <= 0)
        {
            // This is specifically a List<T> and not an IList<T> to prevent
            // using the IEnumerable<string> extension Reverse().
            List<string> newList = [.. currentSequence];
            newList.Reverse();

            sequence.Add(newList);
            goto End;
        }

        foreach (WordNode node in ShortestPaths)
        {
            node.Traverse(sequence, currentSequence);
        }

    End:
        currentSequence.RemoveAt(currentSequence.Count - 1);
    }
}

public partial class Solution
{
    /// <summary>
    /// Finds all shortest paths from <paramref name="beginWord"/> to <paramref name="endWord"/>
    /// following a given <paramref name="wordList"/> such that you can traverse through words
    /// that differ by exactly one character.
    /// </summary>
    /// <param name="beginWord">The starting word.</param>
    /// <param name="endWord">The ending word.</param>
    /// <param name="wordList">A dictionary of words. Must contain the <paramref name="endWord"/>.</param>
    /// <returns>All shortest sequences from <paramref name="beginWord"/> to <paramref name="endWord"/>. Empty if no possible path exists.</returns>
    public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
    {
        if (!wordList.Contains(endWord))
        {
            // The wordList must contain the endWord.
            return [];
        }

        Dictionary<string, List<string>> adjacentWordsGraph = [];
        foreach (string word in wordList)
        {
            adjacentWordsGraph[word] = [];
        }

        if (!adjacentWordsGraph.ContainsKey(beginWord))
        {
            // Add the beginWord if not already.
            wordList.Add(beginWord);
            adjacentWordsGraph[beginWord] = [];
        }

        // Create a network graph of all words that differ by exactly
        // one character.
        for (int i = 0; i < wordList.Count - 1; i++)
        {
            string word = wordList[i];
            List<string> main = adjacentWordsGraph[word];

            for (int j = i + 1; j < wordList.Count; j++)
            {
                string otherWord = wordList[j];
                if (DiffersByOne(word, otherWord))
                {
                    main.Add(otherWord);
                    adjacentWordsGraph[otherWord].Add(word);
                }
            }
        }

        
        IList<IList<string>> sequences = [];
        Dictionary<string, WordNode> nodes = [];

        Queue<(string word, string? before)> queue = [];
        queue.Enqueue((beginWord, null));

        //   B ---- C ---|
        //  /       |    |
        // A        D -- F
        //  \      /
        //   - E --
        //
        // Notice that, to get from A to F, AEDF is shorter than ABCDF. This
        // is because AE can get to D faster than ABC. In this breadth-first
        // search algorithm, nodes that are too slow to reach intersections
        // will be discarded as they are guaranteed to not be one of the
        // shortest paths. However, ABCF is also as fast as AEDF, because C
        // and D intersect F at exactly the same node distance, which is
        // acknowledged by the algorithm. WordNode instances will then only
        // store WordNode objects adjacent to it that have the shortest
        // route to beginWord.
        bool reachedEnd = false;
        while (!reachedEnd && queue.Count is int levelLength and > 0)
        {
            // Create WordNode instances and store a HashSet of all
            // the words visited at this level.
            HashSet<string> words = [];
            for (int i = 0; i < levelLength; i++)
            {
                (string word, string? before) = queue.Dequeue();
                words.Add(word);

                if (!nodes.TryGetValue(word, out WordNode? node))
                {
                    node = new WordNode() { Word = word };
                    nodes[word] = node;
                }

                if (before is not null)
                {
                    // Add the shortest WordNode to this WordNode.
                    node.ShortestPaths.Add(nodes[before]);
                }
            }

            foreach (string word in words)
            {
                if (word == endWord)
                {
                    // Reached the end, so halt enqueueing.
                    reachedEnd = true;
                }
                else if (reachedEnd)
                {
                    continue;
                }

                foreach (string next in adjacentWordsGraph[word])
                {
                    if (nodes.ContainsKey(next))
                    {
                        // Don't enqueue a word whose WordNode has already been visited,
                        // because it has all the information it needs to get to the
                        // beginWord in the shortest path.
                        continue;
                    }

                    queue.Enqueue((next, word));
                }
            }
        }

        if (!nodes.TryGetValue(endWord, out WordNode? endNode))
        {
            // There is no WordNode for the endWord, so the algorithm
            // did not find any existing path.
            return [];
        }

        endNode.Traverse(sequences, []);
        return sequences;


        // Checks if two different strings a and b
        // differ by exactly one character.
        static bool DiffersByOne(string a, string b)
        {
            bool differs = false;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    if (differs)
                    {
                        // The string differs by more than 1 character.
                        return false;
                    }

                    differs = true;
                }
            }

            return differs;
        }
    }
}
