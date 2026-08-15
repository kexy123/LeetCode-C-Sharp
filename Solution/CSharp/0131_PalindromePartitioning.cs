// RESULTS:
//      Submitted on 15 August 2026 at 12:26
//
//      32 / 32 testcases passed.
//
//      Runtime:    45 ms
//      Memory:     84.41 MB
//
// Originally thought of how to check if a string is a palindrome without the endpoint,
// until I realized that the complexity for doing such a method is roughly equivalent to
// just checking if its a palindrome from the end of the string, so there wasn't a purpose
// to use Manacher's algorithm:
// https://en.wikipedia.org/wiki/Longest_palindromic_substring#Manacher's_algorithm

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Returns every possible partition of <paramref name="s"/> such that each partition is
    /// a palindrome.
    /// </summary>
    /// <param name="s">The <see langword="string"/> to partition.</param>
    /// <returns>Every possible partition sequence.</returns>
    public IList<IList<string>> Partition(string s)
    {
        IList<IList<string>> result = [];
        IList<string> current = [];

        List<int>[] partitionIndices = new List<int>[s.Length];
        Split(0);

        return result;


        // A depth-first search subroutine that partitions at every valid palindrome of s
        // starting at the given index, and calls itself with the index being the end of
        // the partitioned substring.
        void Split(int index)
        {
            if (index >= s.Length)
            {
                // Reached the end, so add the partition sequence to the results.
                result.Add([.. current]);
                return;
            }

            if (partitionIndices[index] is List<int> indices)
            {
                // The partition indices has already been computed, so use them.
                foreach (int cutIndex in indices)
                {
                    current.Add(s[index..cutIndex]);
                    Split(cutIndex);
                    current.RemoveAt(current.Count - 1);
                }

                return;
            }

            indices = partitionIndices[index] = [];

            // Run through the string s from index, and check for palindrome validity.
            int cutAttempt = s.Length;
            while (cutAttempt > index)
            {
                // Check if s[index..cutAttempt] is a palindrome.
                int left = index, right = cutAttempt - 1;
                while (right > left)
                {
                    if (s[left] != s[right])
                    {
                        break;
                    }
                    right--;
                    left++;
                }

                // The slice s[index..cutAttempt] is a palindrome, so partition here.
                if (right <= left)
                {
                    indices.Add(cutAttempt);

                    current.Add(s[index..(cutAttempt)]);
                    Split(cutAttempt);
                    current.RemoveAt(current.Count - 1);
                }

                cutAttempt--;
            }
        }
    }
}
