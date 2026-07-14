// RESULTS:
//      Submitted on 14 July 2026 at 22:37
//
//      66 / 66 testcases passed.
//
//      Runtime:    10 ms
//      Memory:     51.08 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Returns the number of distinct subsequences
    /// in <paramref name="s"/> that equal to
    /// <paramref name="t"/>. A subsequence of a
    /// <see cref="string"/> refers to any sequence
    /// of characters in the <see cref="string"/>,
    /// ignoring gaps.
    /// </summary>
    /// <param name="s">The <see cref="string"/> to find subsequences for.</param>
    /// <param name="t">The <see cref="string"/> to get subsequences in.</param>
    /// <returns>The number of distinct subsequences.</returns>
    public int NumDistinct(string s, string t)
    {
        int?[,] numSubsequences = new int?[s.Length, t.Length];

        // Start from the end of the strings. This
        // also prevents repeated computation of
        // the length of the strings in the for
        // loop condition.
        return FindSubsequence(s.Length - 1, t.Length - 1);


        // This traverses in possible subsequences
        // of s and t at the given iS and iT, and
        // reusing computation of subsequences if
        // possible.
        int FindSubsequence(int iS, int iT)
        {
            if (iT < 0)
            {
                // iT reached the end, so the traversed
                // subsequence is valid and distinct, so
                // simply return 1.
                return 1;
            }

            ref int? subsequences = ref numSubsequences[iS, iT];
            if (subsequences is not null)
            {
                // This subsequence was already visited,
                // so return its value.
                return (int)subsequences!;
            }

            subsequences = 0;

            char c = t[iT];
            for (; iS >= iT; iS--)
            {
                if (s[iS] == c)
                {
                    // Branch off to a possible subsequence.
                    subsequences += FindSubsequence(iS - 1, iT - 1);
                }
            }

            return (int)subsequences!;
        }
    }
}
