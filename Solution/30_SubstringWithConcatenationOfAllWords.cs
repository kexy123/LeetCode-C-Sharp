// RESULTS:
//      Submitted on 26 June 2026 at 21:55
//
//      182 / 182 testcases passed.
//
//      Runtime:    2662 ms
//      Memory:     56.17 MB
//
// TODO: This code is extremely inefficient,
// and was submitted with an unnecessary Queue<T>
// implementation. Resubmit with more efficient
// form at the bottom. Resubmission at this time
// (26 June 2026) causes a time limit exceeded
// error for case #182.

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Locates all starting indices in the <see cref="string"/>
    /// <paramref name="s"/> that concatenates all of the words
    /// in <paramref name="words"/> exactly once regardless of
    /// order. Duplicate words are not ignored.
    /// </summary>
    /// <param name="s">The <see cref="string"/> containing words.</param>
    /// <param name="words">The array of words. Must all be the same length.</param>
    /// <returns>The list of indices where the substring after it contains all of the words concatenated once.</returns>
    public IList<int> FindSubstring(string s, string[] words)
    {
        // Convert to Dictionary of required occurrences.
        Dictionary<string, int> existingWords = [];
        // Queue of indexes of occurrences for each word.
        Dictionary<string, Queue<int>> wordIndexes = [];
        foreach (var word in words)
        {
            if (existingWords.TryAdd(word, 1))
            {
                wordIndexes.Add(word, []);
            }
            else
            {
                existingWords[word]++;
            }
        }

        // It is guaranteed for at least one word to
        // exist in the words array.
        int wordLength = words[0].Length;

        List<int> results = [];
        for (int left = 0; left <= s.Length - wordLength * words.Length; left++)
        {
            int j = 0;
            for (j = 0; j < words.Length; j++)
            {
                string word = s.Substring(left + j * wordLength, wordLength);

                // Check if word does not exist.
                if (!existingWords.ContainsKey(word))
                {
                    break;
                }

                Queue<int> item = wordIndexes[word];
                item.Enqueue(left + j * wordLength);

                // Check if word was captured too many times.
                if (item.Count > existingWords[word])
                {
                    break;
                }
            }

            // Check if j successfully found a concatenated
            // substring of all words in the words array
            // at least once, not ignoring duplicate words.
            if (j == words.Length)
            {
                results.Add(left);
            }

            // Clear all queued indices in wordIndexes.
            foreach (var item in wordIndexes)
            {
                item.Value.Clear();
            }
        }

        return results;
    }
}



// TO RESUBMIT:

//namespace Solution; public partial class Solution
//{
//    /// <summary>
//    /// Locates all starting indices in the <see cref="string"/>
//    /// <paramref name="s"/> that concatenates all of the words
//    /// in <paramref name="words"/> exactly once regardless of
//    /// order. Duplicate words are not ignored.
//    /// </summary>
//    /// <param name="s">The <see cref="string"/> containing words.</param>
//    /// <param name="words">The array of words. Must all be the same length.</param>
//    /// <returns>The list of indices where the substring after it contains all of the words concatenated once.</returns>
//    public IList<int> FindSubstring(string s, string[] words)
//    {
//        // Convert to Dictionary of required occurrences.
//        Dictionary<string, int> existingWords = [];
//        // Queue of indexes of occurrences for each word.
//        Dictionary<string, int> wordIndexes = [];
//        foreach (var word in words)
//        {
//            if (existingWords.TryAdd(word, 1))
//            {
//                wordIndexes.Add(word, 0);
//            }
//            else
//            {
//                existingWords[word]++;
//            }
//        }

//        // It is guaranteed for at least one word to
//        // exist in the words array.
//        int wordLength = words[0].Length;

//        IList<int> results = [];
//        for (int left = 0; left <= s.Length - wordLength * words.Length; left++)
//        {
//            int j = 0;
//            for (j = 0; j < words.Length; j++)
//            {
//                string word = s.Substring(left + j * wordLength, wordLength);

//                // Check if word does not exist.
//                if (!existingWords.ContainsKey(word))
//                {
//                    break;
//                }

//                // Increment occurrence and check if
//                // word was captured too many times.
//                if (++wordIndexes[word] > existingWords[word])
//                {
//                    break;
//                }
//            }

//            // Check if j successfully found a concatenated
//            // substring of all words in the words array
//            // at least once, not ignoring duplicate words.
//            if (j == words.Length)
//            {
//                results.Add(left);
//            }

//            // Clear all occurrences in wordIndexes.
//            foreach (string item in wordIndexes.Keys)
//            {
//                wordIndexes[item] = 0;
//            }
//        }

//        return results;
//    }
//}
