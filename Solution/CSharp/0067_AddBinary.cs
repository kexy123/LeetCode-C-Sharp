// RESULTS:
//      Submitted on 06 July 2026 at 21:25
//
//      296 / 296 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     41.32 MB

using System.Text;

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Adds two binary <see cref="string"/>
    /// together.
    /// </summary>
    /// <param name="a">A binary <see cref="string"/>.</param>
    /// <param name="b">A binary <see cref="string"/>.</param>
    /// <returns>The resulting binary <see cref="string"/>.</returns>
    public string AddBinary(string a, string b)
    {
        if (b.Length > a.Length)
        {
            // Make a the longest number and b
            // the shortest number.
            (a, b) = (b, a);
        }

        // The resulting string will have
        // a length of at most the longest
        // number plus one.
        StringBuilder result = new(b.Length + 1);
        bool carry = false;
        for (int i = 1; i <= a.Length; i++)
        {
            // Check if the digit at a and b
            // are ones.
            bool aOne = a[^i] == '1';
            bool bOne = i <= b.Length && b[^i] == '1';

            // The XOR of carry, aOne, and bOne
            // essentially determines if the
            // digit to append to result is a
            // 1 or a 0. An even number of 1s
            // in any three variables is a 0,
            // otherwise it is a 1.
            result.Append(carry ^ aOne ^ bOne ? '1' : '0');

            // Check if any two of them are 1,
            // for which a carry digit must be
            // passed on.
            carry = aOne && bOne || aOne && carry || bOne && carry;
        }

        if (carry)
        {
            // There is one more carry digit.
            result.Append('1');
        }

        // Resulting string is in reverse.
        for (int i = 0; i < result.Length / 2; i++)
        {
            (result[i], result[^(i + 1)]) = (result[^(i + 1)], result[i]);
        }

        return result.ToString();
    }
}
