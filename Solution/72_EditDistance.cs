// RESULTS:
//      Submitted on 07 July 2026 at 20:51
//
//      1149 / 1149 testcases passed.
//
//      Runtime:    3 ms
//      Memory:     45.87 MB
//
// This is the Levenshtein distance for
// computing the minimum distance between two
// sequences given that you can only replace,
// delete, or insert elements:
// https://en.wikipedia.org/wiki/Levenshtein_distance
// I struggled to comprehend this question
// as it wasn't easy to figure out what counts
// as the minimum distance, so this problem
// included a bit of research.

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Computes the minimum number of letter
    /// operations (inserting a character,
    /// deleting a character, or replacing a
    /// character) that transforms
    /// <paramref name="word1"/> into
    /// <paramref name="word2"/>.
    /// </summary>
    /// <param name="word1">The starting <see cref="string"/>.</param>
    /// <param name="word2">The ending <see cref="string"/>.</param>
    /// <returns>The minimum number of operations.</returns>
    public int MinDistance(string word1, string word2)
    {
        // Matrix for memoization of the two
        // indices corresponding to the minimum
        // number of operations.
        int[,] distances = new int[word1.Length + 1, word2.Length + 1];

        return Distance(0, 0);


        // Returns the minimum number of operations
        // for word1 and word2 if they started at
        // the given indexes i and j. Their result
        // is stored in the distances matrix to
        // avoid repeated computation.
        int Distance(int i, int j)
        {
            ref int distance = ref distances[i, j];
            if (distance > 0)
            {
                return distance;
            }

            // Check if any one of the
            // two words have a length
            // of 0 after truncation.
            // In which case, the number
            // of insertions is the
            // length of the other word.
            if (word1.Length - i == 0)
            {
                return distance = word2.Length - j;
            }
            else if (word2.Length - j == 0)
            {
                return distance = word1.Length - i;
            }

            if (word1[i] == word2[j])
            {
                // The first letter of each word
                // at their given indexes is the
                // same, so simply return the
                // distance of the strings without
                // that first letter.
                return distance = Distance(i + 1, j + 1);
            }
            else
            {
                // We have to perform one operation
                // (insert, delete, or replace),
                // and determine which one has the
                // least number of operations.
                return distance = 1 + Math.Min(Math.Min(
                    Distance(i + 1, j),         // Delete a letter from word1.
                    Distance(i, j + 1)),        // Insert a letter from word1.
                    Distance(i + 1, j + 1));    // Replace a letter to match word2.
            }
        }
    }
}
