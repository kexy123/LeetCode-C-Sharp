// RESULTS:
//      Submitted on 12 July 2026 at 18:01
//
//      107 / 107 testcases passed.
//
//      Runtime:    65 ms
//      Memory:     40.92 MB
//
// TODO: Try to complete the follow-up problem with
// O(s2.Length) space complexity.

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Checks if <paramref name="s3"/> is an interleave of
    /// the characters in <paramref name="s1"/> and
    /// <paramref name="s2"/>.
    /// </summary>
    /// <param name="s1">The first <see cref="string"/>.</param>
    /// <param name="s2">The second <see cref="string"/>.</param>
    /// <param name="s3">The <see cref="string"/> to check if it interleaves with <paramref name="s1"/> and <paramref name="s2"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="s3"/> interleaves with <paramref name="s1"/> and <paramref name="s2"/>, otherwise <see langword="false"/>.</returns>
    public bool IsInterleave(string s1, string s2, string s3)
    {
        if (s1.Length + s2.Length != s3.Length)
        {
            // The interleaving of s1 and s2 must produce
            // a string that is the sum of their lengths.
            return false;
        }

        bool?[,] results = new bool?[s1.Length + 1, s2.Length + 1];

        // Start at the beginning of s1 and s2.
        return Interleave(0, 0);


        // A recursive function that moves the i1, i2,
        // and i3 pointers such that it finds a possible
        // interleaving combination of the two strings.
        bool Interleave(int i1, int i2)
        {
            ref bool? result = ref results[i1, i2];
            if (result is not null)
            {
                return (bool)result;
            }

            for (int i3 = i1 + i2; i3 < s3.Length; i3++)
            {
                char? c1 = i1 < s1.Length ? s1[i1] : null;
                char? c2 = i2 < s2.Length ? s2[i2] : null;
                char c3 = s3[i3];

                if (c1 == c3 && c1 == c2)
                {
                    // Return if there is a possibility in the
                    // two interleaved possibilities.
                    result = Interleave(i1 + 1, i2) || Interleave(i1, i2 + 1);
                    return (bool)result;
                }
                else if (c1 == c3)
                {
                    // Move i1 right.
                    i1++;
                }
                else if (c2 == c3)
                {
                    // Move i2 right.
                    i2++;
                }
                else
                {
                    // No character matches at this point, so
                    // set the earliest sign of it happening to
                    // false, which are the starting indices of
                    // this function.
                    result = false;
                    return false;
                }
            }

            // i1, i2, and i3 have reached the end of
            // their strings, so return true. This
            // also terminates the recursive function.
            return true;
        }
    }
}
