// RESULTS:
//      Submitted on 23 August 2026 at 19:06
//
//      29 / 29 testcases passed.
//
//      Runtime:    2 ms
//      Memory:     47.42 MB
//
// Directly borrowed from 0139_WordBreak, except that the memoization was removed and the recursive
// function is a recursive subroutine.

namespace Solution.CSharp.WordBreakII_0140;

file sealed class CharTrieNode
{
    private readonly Dictionary<char, CharTrieNode> Children = [];

    public bool IsWord = false;

    public bool IsLeaf => Children.Count is 0;


    public CharTrieNode this[char character]
    {
        get => Children[character];
    }

    public bool Contains(char character) => Children.ContainsKey(character);


    public void CreateWordSequence(ReadOnlySpan<char> stream)
    {
        CharTrieNode current = this;
        foreach (char c in stream)
        {
            if (current.Children.ContainsKey(c))
            {
                current = current[c];
            }
            else
            {
                current.Children[c] = current = new();
            }
        }

        current.IsWord = true;
    }
}

public partial class Solution
{
    /// <summary>
    /// Breaks the <see langword="string"/> <paramref name="s"/> into all possible sequences of words
    /// from the <paramref name="wordDict"/>, with each returning entry being <paramref name="s"/>
    /// delimited with spaces in-between valid words.
    /// </summary>
    /// <param name="s">The <see langword="string"/> to break up.</param>
    /// <param name="wordDict">The words.</param>
    /// <returns>Each possible breakup of the <see langword="string"/> <paramref name="s"/>.</returns>
    public IList<string> WordBreak(string s, IList<string> wordDict)
    {
        CharTrieNode root = new();
        foreach (string word in wordDict)
        {
            root.CreateWordSequence(word);
        }

        IList<string> spaced = [];
        List<string> currentWords = [];

        CanBeSplit(0);
        return spaced;


        void CanBeSplit(int position)
        {
            CharTrieNode state = root;
            for (int i = position; i < s.Length; i++)
            {
                if (!state.Contains(s[i]))
                {
                    return;
                }

                state = state[s[i]];
                if (state.IsWord)
                {
                    // Add the word to the current sequence, call CanBeSplit again, then remove it.
                    currentWords.Add(s[position..(i + 1)]);
                    if (i + 1 >= s.Length)
                    {
                        spaced.Add(string.Join(' ', currentWords));
                        currentWords.RemoveAt(currentWords.Count - 1);
                        return;
                    }
                    else
                    {
                        CanBeSplit(i + 1);
                        currentWords.RemoveAt(currentWords.Count - 1);
                    }
                }
            }
        }
    }
}
