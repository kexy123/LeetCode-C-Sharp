// RESULTS:
//      Submitted on 15 August 2026 at 14:42
//
//      37 / 37 testcases passed.
//
//      Runtime:    811 ms
//      Memory:     39.29 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Returns the minimum number of cuts to partition <paramref name="s"/> such that each partition
    /// is a palindrome.
    /// </summary>
    /// <param name="s">The <see langword="string"/> to partition.</param>
    /// <returns>The minimum number of cuts to partition <paramref name="s"/>.</returns>
    public int MinCut(string s)
    {
        int[] minimumCuts = new int[s.Length];

        return Split(0) - 1;


        // A depth-first search subroutine that partitions at every valid palindrome of s starting at
        // the given index, and checks if it yields the minimum number of cuts at that point as well.
        int Split(int index)
        {
            if (index >= s.Length)
            {
                return 0;
            }

            ref int minCuts = ref minimumCuts[index];
            if (minCuts is > 0)
            {
                return minCuts;
            }

            minCuts = int.MaxValue;
            int cutAttempt = s.Length;
            while (cutAttempt > index)
            {
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

                if (right <= left)
                {
                    // Check if the current split at cutAttempt has the smallest number of cuts.
                    minCuts = Math.Min(minCuts, Split(cutAttempt));
                }

                cutAttempt--;
            }

            return ++minCuts;
        }
    }
}
