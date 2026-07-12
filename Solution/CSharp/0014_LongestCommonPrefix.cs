// RESULTS:
//      Submitted on 23 June 2026 at 21:00
//
//      126 / 126 testcases passed.
//
//      Runtime:    1 ms
//      Memory:     43.21 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Finds the longest prefix that exists
    /// in all elements of the <paramref name="strs"/>
    /// array.
    /// </summary>
    /// <param name="strs">The array of <see cref="string"/> to inspect.</param>
    /// <returns>The longest common prefix.</returns>
    public string LongestCommonPrefix(string[] strs)
    {
        // Make the first element the
        // pivoting element.
        string first = strs[0];

        // The terminating length will
        // be acquired in the first loop
        // which determines the max
        // iterations to do.
        int terminatingLength = first.Length;

        int i;
        for (i = 0; i < terminatingLength; i++)
        {
            char c = first[i];

            // Check if the character c
            // exists in the same index
            // as every other element.
            // If the element is too short
            // or has an invalid character,
            // yield the common prefix.
            for (int j = 1; j < strs.Length; j++)
            {
                string element = strs[j];
                int length = element.Length;

                if (length < terminatingLength)
                {
                    terminatingLength = length;
                }

                if (length <= i || element[i] != c)
                {
                    return first[..i];
                }
            }
        }

        return first[..i];
    }
}
