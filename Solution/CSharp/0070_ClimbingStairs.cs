// RESULTS:
//      Submitted on 07 July 2026 at 16:01
//
//      45 / 45 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     29.10 MB
//
// I began with a dynamic programming algorithm,
// until I realized that this is essentially the
// same as computing the nth term of the Fibonacci
// sequence, so this algorithm has O(n) time with
// O(1) space complexity.

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Given a staircase of <paramref name="n"/>
    /// steps, computes how many ways to climb
    /// up the stairs given that you can go up
    /// by either 1 or 2 steps.
    /// </summary>
    /// <param name="n">The number of steps.</param>
    /// <returns>The number of ways to climb up.</returns>
    public int ClimbStairs(int n)
    {
        // https://oeis.org/A000045:
        // The Fibonacci sequence.
        int a = 0, b = 1;
        for (int i = 0; i < n; i++)
        {
            int c = a + b;
            a = b;
            b = c;
        }

        return b;
    }
}
