// RESULTS:
//      Submitted on 12 July 2026 at 06:50
//
//      19 / 19 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     29.05 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Computes the number of structurally unique
    /// binary trees with <paramref name="n"/>
    /// nodes.
    /// </summary>
    /// <param name="n">The number of nodes in each binary tree.</param>
    /// <returns>The number of unique binary trees.</returns>
    public int NumTrees(int n)
    {
        // https://oeis.org/A000108:
        // Catalan numbers. After looking at the
        // sequence of the numbers, they form the
        // equation (C denotes the Catalan number):
        //
        //          (2n)!
        //  C_n = --------
        //        n!(n+1)!
        //
        // Where n is from 1 to 19 as stated in
        // LeetCode. However, 38! and 19!*20!
        // cannot fit in an int or a long. However,
        // we can take the multiplicative
        // difference of the current and next term
        // C_(n+1) and simplify:
        //
        //  C_(n+1)      (2n+2)!     n!(n+1)!
        //  ------- = ------------ * --------
        //    C_n     (n+1)!(n+2)!     (2n)!
        //
        //
        //            C_n * (4n+2)
        //  C_(n+1) = ------------
        //                n+2
        //
        // Therefore, computing the next term
        // takes the previous term and multiplies
        // it by 4n+2, then divides it all by n+2.
        // Note that this multiplication must
        // include C_n as the numerator and must
        // not be taken out, otherwise 4n+2 would
        // not be divisible by n+2 and cause quirks
        // with integer division. However, C_n(4n+2)
        // will always be divisible by n+2.
        long result = 1;

        for (int i = 0; i < n; i++)
        {
            result *= 4 * i + 2;
            result /= i + 2;
        }

        return (int)result;
    }
}
