// RESULTS:
//      Submitted on 25 June 2026 at 22:42
//
//      994 / 994 testcases passed.
//
//      Runtime:    1232 ms
//      Memory:     29.59 MB
//
// TODO: Make this code more efficient
// using bitwise operations.

public partial class Solution
{
    /// <summary>
    /// Returns the <see cref="int"/> quotient of
    /// <c><paramref name="dividend"/> /
    /// <paramref name="divisor"/></c>.
    /// </summary>
    /// <remarks>
    /// This method does not use the <see cref="int"/>
    /// division, multiplication, or modulus operation.
    /// </remarks>
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
            // -2,147,483,648 cannot be turned
            // into a positive number as it
            // makes it greater than int.MaxValue,
            // so clamp it.
            return dividend == int.MinValue ? int.MaxValue : -dividend;
        }

        // Make both dividend and divisor
        // negative and preserve the sign
        // result. This is because the
        // negative integers contains one
        // number larger than the positive
        // ones, which is -2,147,483,748
        // compared to int.MaxValue =
        // 2,147,483,647.
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
        // Stop while loop if it ever
        // reaches an integer underflow,
        // which makes a number positive.
        while (whole >= dividend && whole < 0)
        {
            whole += divisor;
            result--;
        }

        if (sign > 0)
        {
            // Ditto to the negative identity
            // divisor check.
            return result == int.MinValue ? int.MaxValue : -result;
        }
        else
        {
            return result;
        }
    }
}
