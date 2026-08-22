// RESULTS:
//      Submitted on 25 June 2026 at 22:42
//
//      994 / 994 testcases passed.
//
//      Runtime:    1232 ms
//      Memory:     29.59 MB
//
// TODO: Make this code more efficient using bitwise operations.

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Returns the <see langword="int"/> quotient of the <paramref name="dividend"/> over the
    /// <paramref name="divisor"/>, without using <see langword="int"/> division, multiplication, or
    /// modulo operations.
    /// </summary>
    /// <param name="dividend">The numerator.</param>
    /// <param name="divisor">The denominator. Must not equal 0.</param>
    /// <returns>The quotient.</returns>
    public int Divide(int dividend, int divisor)
    {
        // Quotient identity.
        if (divisor == 1)
        {
            return dividend;
        }
        else if (divisor == -1)
        {
            // int.MinValue cannot be turned into a positive number as it makes it greater than
            // int.MaxValue, so clamp it.
            return dividend == int.MinValue ? int.MaxValue : -dividend;
        }

        // Make both dividend and divisor negative and preserve the sign result. This is because the
        // negative integers contain one number larger than the positive ones, which is int.MinValue
        // compared to int.MaxValue.
        int sign = 1;
        if (dividend > 0)
        {
            dividend = -dividend;
        }
        else
        {
            sign = -sign;
        }

        if (divisor > 0)
        {
            divisor = -divisor;
        }
        else
        {
            sign = -sign;
        }

        int result = 0;
        int whole = divisor;
        // Stop while loop if it ever reaches an integer underflow, which makes a number positive.
        while (whole >= dividend && whole < 0)
        {
            whole += divisor;
            result--;
        }

        if (sign > 0)
        {
            // Ditto to the negative identity divisor check.
            return result == int.MinValue ? int.MaxValue : -result;
        }
        else
        {
            return result;
        }
    }
}
