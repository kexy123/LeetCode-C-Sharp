// RESULTS:
//      Submitted on 13 August 2026 at 00:01
//
//      57 / 57 testcases passed.
//
//      Runtime:    184 ms
//      Memory:     56.87 MB
//
// Similar to 0126_WordLadderII, but only needs to return the depth of the
// shortest sequence.

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Finds the length of the shortest route from <paramref name="beginWord"/> to
    /// <paramref name="endWord"/> following a <paramref name="wordList"/>.
    /// </summary>
    /// <param name="beginWord">The starting word.</param>
    /// <param name="endWord">The ending word.</param>
    /// <param name="wordList">A dictionary of words. Must contain the <paramref name="endWord"/>.</param>
    /// <returns>The number of words in the shortest sequence from <paramref name="beginWord"/> to <paramref name="endWord"/>. 0 if no sequence exists.</returns>
    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        if (!wordList.Contains(endWord))
        {
            return 0;
        }

        Dictionary<string, List<string>> adjacentWordsGraph = [];
        foreach (string word in wordList)
        {
            adjacentWordsGraph[word] = [];
        }

        if (!adjacentWordsGraph.ContainsKey(beginWord))
        {
            wordList.Add(beginWord);
            adjacentWordsGraph[beginWord] = [];
        }

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


        // Breadth-first search can store the depth, which is the same as the
        // number of words in the sequence as long as we don't visit previous
        // words.
        HashSet<string> visited = [];
        Queue<(string word, int level)> queue = [];
        queue.Enqueue((beginWord, 1));
        while (queue.Count is > 0)
        {
            (string word, int level) = queue.Dequeue();
            visited.Add(word);

            if (word == endWord)
            {
                // The endWord was retrieved, so simply return the depth.
                return level;
            }

            foreach (string next in adjacentWordsGraph[word])
            {
                if (visited.Contains(next))
                {
                    continue;
                }

                queue.Enqueue((next, level + 1));
            }
        }

        return 0;


        static bool DiffersByOne(string a, string b)
        {
            bool differs = false;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    if (differs)
                    {
                        return false;
                    }

                    differs = true;
                }
            }

            return differs;
        }
    }
}
