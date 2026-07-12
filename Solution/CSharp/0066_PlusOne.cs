// RESULTS:
//      Submitted on 06 July 2026 at 20:43
//
//      114 / 114 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     46.66 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Increments 1 to the given <paramref name="digits"/>
    /// <see cref="int"/> array.
    /// </summary>
    /// <param name="digits">The <see cref="int"/> digits to affect.</param>
    /// <returns>The new incremented value.</returns>
    public int[] PlusOne(int[] digits)
    {
        // Move to the least-significant
        // digit that isn't a 9, while
        // setting all the 9's after it
        // to 0. 9 + 1 = 10, which
        // overflows to the next digit.
        int i = digits.Length - 1;
        while (i >= 0 && digits[i] == 9)
        {
            digits[i] = 0;
            i--;
        }

        if (i < 0)
        {
            // We need to prepend a new digit.
            return [1, .. digits];
        }

        // Simply add one to the digit.
        digits[i]++;
        return digits;
    }
}
