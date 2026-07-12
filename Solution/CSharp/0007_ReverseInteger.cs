// RESULTS:
//      Submitted on 22 June 2026 at 23:24
//
//      1045 / 1045 testcases passed.
//
//      Runtime:    19 ms
//      Memory:     42.23 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Reverses a number in base-10. If the
    /// reversal process can cause an
    /// integer overflow, return 0. The sign
    /// of the integer is kept the same.
    /// </summary>
    /// <param name="x">The <see cref="int"/> to reverse.</param>
    /// <returns>The reversed number.</returns>
    public int Reverse(int x)
    {
        // Math.Abs(x) will cause an
        // IntegerOverflowException as
        // x.MaxValue = 2,147,483,647
        // while |x.MinValue| = 2,147,483,648,
        // so return 0.
        if (x == int.MinValue)
        {
            return 0;
        }

        // An int can only have at most ten
        // base-10 digits.
        byte[] digits = new byte[10];

        // Assign each base-10 digit from x.
        int i = 0;
        int xAbs = Math.Abs(x);
        while (xAbs > 0)
        {
            digits[i++] = (byte)(xAbs % 10);
            xAbs /= 10;
        }

        // If x > 999,999,999 (a.k.a. a billion)
        // and the last digit of x is more than 2,
        // it will cause an integer overflow.
        if (x > 999_999_999 && digits[0] > 2)
        {
            return 0;
        }

        // Reverse the digits by adding by a
        // power of ten.
        int result = 0;
        int exp = 1;
        for (int j = i - 1; j >= 0; j--)
        {
            int reversedDigit = digits[j] * exp;

            // Check if the difference between
            // int.MaxValue and current result is
            // less than the reversedDigit. If it
            // is, it will cause an integer
            // overflow, so return 0.
            if (int.MaxValue - result < reversedDigit)
            {
                return 0;
            }

            result += digits[j] * exp;
            exp *= 10;
        }

        return int.CopySign(result, x);
    }
}
