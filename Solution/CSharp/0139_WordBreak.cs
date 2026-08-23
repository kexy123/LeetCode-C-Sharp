// RESULTS:
//      Submitted on 23 August 2026 at 16:40
//
//      49 / 49 testcases passed.
//
//      Runtime:    2 ms
//      Memory:     45.86 MB

namespace Solution.CSharp;

/// <summary>
/// A trie node that assigns the next <see langword="char"/> to <see cref="CharTrieNode"/> instances.
/// </summary>
file sealed class CharTrieNode
{
    /// <summary>
    /// The <see langword="char"/> assigned to the <see cref="CharTrieNode"/>.
    /// </summary>
    private readonly Dictionary<char, CharTrieNode> Children = [];

    /// <summary>
    /// Determines whether a stream that reached this point can separate this as a word.
    /// </summary>
    public bool IsWord = false;

    /// <summary>
    /// Checks if this <see cref="CharTrieNode"/> has no children.
    /// </summary>
    public bool IsLeaf => Children.Count is 0;


    /// <summary>
    /// Retrieves the next <see cref="CharTrieNode"/> instance under this one at the
    /// given <paramref name="character"/>.
    /// </summary>
    /// <param name="character">The <see langword="char"/> to access.</param>
    /// <returns>The child <see cref="CharTrieNode"/>.</returns>
    public CharTrieNode this[char character]
    {
        get => Children[character];
    }

    /// <summary>
    /// Checks if this <see cref="CharTrieNode"/> contains the given <paramref name="character"/>.
    /// </summary>
    /// <param name="character">The <see langword="char"/> to check.</param>
    /// <returns><see langword="true"/> if it exists; otherwise <see langword="false"/>.</returns>
    public bool Contains(char character) => Children.ContainsKey(character);


    /// <summary>
    /// Creates a <see cref="CharTrieNode"/> sequence from the given <see langword="char"/>
    /// <paramref name="stream"/> and marks it as a valid word that can be split.
    /// </summary>
    /// <param name="stream">The <see cref="ReadOnlySpan{T}"/> to read.</param>
    public void CreateWordSequence(ReadOnlySpan<char> stream)
    {
        CharTrieNode current = this;
        foreach (char c in stream)
        {
            if (current.Children.ContainsKey(c))
            {
                // Traverse to the CharTrieNode.
                current = current[c];
            }
            else
            {
                // Create the new CharTrieNode.
                current.Children[c] = current = new();
            }
        }

        current.IsWord = true;
    }
}

public partial class Solution
{
    /// <summary>
    /// Checks if the <see langword="string"/> <paramref name="s"/> can be broken up into words within
    /// the given <paramref name="wordDict"/>. Words can be used more than once to break up sections of
    /// the <see langword="string"/>.
    /// </summary>
    /// <param name="s">The <see langword="string"/> to break up.</param>
    /// <param name="wordDict">The words.</param>
    /// <returns><see langword="true"/> if it can be broken up; otherwise <see langword="false"/>.</returns>
    public bool WordBreak(string s, IList<string> wordDict)
    {
        // Create a trie, which is a tree that stores character sequences. For example, "leet" would
        // be added to the trie root making:
        //  root -> l -> e -> e -> t (valid word)
        //
        // but if we add "loot" to the root as well, it would form this tree:
        //  root -> l -> e -> e -> t (valid word)
        //           \
        //            -> o -> o -> t (valid word)
        //
        // and if we add "looted" to the root, it would append "ed" to the end to form:
        //  root -> l -> e -> e -> t (valid word)
        //           \
        //            -> o -> o -> t (valid word) -> e -> d (valid word)
        //
        // while keeping "loot" a valid word.
        CharTrieNode root = new();
        foreach (string word in wordDict)
        {
            root.CreateWordSequence(word);
        }

        bool[] traversed = new bool[s.Length];
        return CanBeSplit(0);


        // A depth-first search algorithm that checks if the stream ahead of position can be broken
        // in words from the wordDict by using the CharTrieNode. If the stream was "lootedleet", using
        // the trie that was said before would traverse through the "loot" path, find out that "loot"
        // is a valid word, then check if "edleet" can be broken into words starting back from the
        // root, which can't so it continues, finding out that "looted" is also a word, which checks if
        // "leet" can be broken up into a word, which can. The final partition is then "looted" and
        // "leet" which this method will return true for.
        bool CanBeSplit(int position)
        {
            if (traversed[position])
            {
                // CanBeSplit has already traversed at this position, and cannot be split into words at
                // this point, so return false.
                return false;
            }

            CharTrieNode state = root;
            for (int i = position; i < s.Length; i++)
            {
                if (!state.Contains(s[i]))
                {
                    // If we couldn't reach the end of the string s, then return false and mark this
                    // traversed position as true to not traverse through it again.
                    traversed[position] = true;
                    return false;
                }

                state = state[s[i]];
                if (state.IsWord && (i + 1 >= s.Length || CanBeSplit(i + 1)))
                {
                    // This valid word can be broken down and we are either at the end of the string or
                    // CanBeSplit at this index returned true.
                    return true;
                }
            }

            // We reached the end of the string without being able to break down the word, so
            // return false.
            traversed[position] = true;
            return false;
        }
    }
}
