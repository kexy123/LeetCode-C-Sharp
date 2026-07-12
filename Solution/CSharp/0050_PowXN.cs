// RESULTS:
//      Submitted on 05 July 2026 at 00:35
//
//      307 / 307 testcases passed.
//
//      Runtime:    1 ms
//      Memory:     30.07 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Raises <paramref name="x"/> to the
    /// <paramref name="n"/> power, given that
    /// <paramref name="x"/> and <paramref name="n"/>
    /// are not 0.
    /// </summary>
    /// <param name="x">The <see cref="double"/> base.</param>
    /// <param name="n">The <see cref="int"/> exponent.</param>
    /// <returns>The resulting value.</returns>
    public double MyPow(double x, int n)
    {
        bool isReciprocal = true;
        switch (n)
        {
            case > 1:
                // Negate as negative integers
                // have a higher range than
                // positive integers.
                n *= -1;
                isReciprocal = false;
                break;
            // Exponent identity.
            case 1:
                return x;
            // Exponent absorption. x is guaranteed
            // to not be 0 here.
            case 0:
                return 1;
        }

        // Keep track of the squares computed.
        double squaredBase = x;
        Stack<double> squares = [];

        // Ensure that the currentBase
        // will be raised to the maximum
        // power of two whose result is
        // less than the actual value of
        // x^n.
        int powerOfSquare = -2;
        while (n <= powerOfSquare && powerOfSquare < 0)
        {
            // Square the squaredBase.
            squares.Push(squaredBase);
            squaredBase *= squaredBase;
            powerOfSquare <<= 1;
        }

        if (powerOfSquare >= 0)
        {
            // Doubling -2^31 will underflow
            // to 0, so remain under that
            // threshold.
            powerOfSquare = int.MinValue;
        }
        else
        {
            powerOfSquare >>= 1;
        }

        double result = squaredBase;

        // Square root the squaredBase
        // by using the precomputed
        // squares stack and multiply
        // by result to finally make
        // it x^|n|.
        int complement = n - powerOfSquare;
        while (complement < 0)
        {
            while (powerOfSquare < complement)
            {
                squaredBase = squares.Pop();
                powerOfSquare >>= 1;
            }

            result *= squaredBase;
            complement -= powerOfSquare;
        }

        // If n was negative to begin
        // with, take the reciprocal.
        return isReciprocal ? 1 / result : result;
    }
}
