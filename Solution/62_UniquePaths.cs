// RESULTS:
//      Submitted on 06 July 2026 at 18:25
//
//      64 / 64 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     28.95 MB
//
// I discovered an invariant while tinkering
// with this problem and found that sequences,
// such as the triangle and tetrahedral numbers,
// were formed from the grid, with both of
// their formulas having similar structure,
// that being the combinatorics choose function,
// so I implemented that in a for loop, while
// avoiding long overflow. Additionally, one of
// the problem's topics stated that it uses
// dynamic programming, which has O(mn) time
// and space complexity, while the combinatorics
// solution has O(min(m, n)) time and O(1) space.
// This method isn't standard in practice, however.

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// On an <paramref name="m"/> by
    /// <paramref name="n"/> grid, computes
    /// how many unique paths there are from
    /// the top-left to bottom-right corners,
    /// given that you can only move right
    /// or down.
    /// </summary>
    /// <param name="m">The width of the grid.</param>
    /// <param name="n">The height of the grid.</param>
    /// <returns>The number of unique paths.</returns>
    public int UniquePaths(int m, int n)
    {
        int endingMultiplier = 1;

        if (m == n)
        {
            // A square grid is symmetrical,
            // so we can reduce n and double
            // the result at the end. This
            // is to prevent the long overflow.
            n--;
            endingMultiplier = n > 0 ? 2 : 1;
        }
        else if (n > m)
        {
            // Perform the for-loop on
            // the lower number for the
            // choose function.
            (m, n) = (n, m);
        }

        // Compute the choose of
        // (m, n - 1).
        long numerator = 1;
        long denominator = 1;
        for (int i = 1; i < n; i++)
        {
            numerator *= m + i - 1;
            denominator *= i;
        }

        // The result is guaranteed to
        // be less than 2,000,000,000.
        return (int)(numerator / denominator * endingMultiplier);
    }
}
