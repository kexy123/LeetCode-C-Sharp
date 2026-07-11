// RESULTS:
//      Submitted on 11 July 2026 at 20:08
//
//      269 / 269 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     38.75 MB
//
// This problem was originally solved with dynamic
// programming using a simple array, which took O(n)
// time and space complexity. However, it was simplified
// more as there only needed to be three values to
// look at per iteration, making it O(n) time complexity
// with O(1) space.

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Computes the number of ways to decode a
    /// non-delimited <see cref="string"/>
    /// <paramref name="s"/> of base-10 digits
    /// where the numbers 1 to 26 are assigned
    /// to the letters of the English alphabet
    /// (A = 1, B = 2, ..., Z = 26).
    /// </summary>
    /// <param name="s">A non-delimited <see cref="string"/> of digits.</param>
    /// <returns>The number of ways to decode the ambiguous <see cref="string"/> <paramref name="s"/>.</returns>
    public int NumDecodings(string s)
    {
        int a = 1, b = 1, c;
        for (int i = s.Length - 1; i >= 0; i--)
        {
            c = b;
            b = a;

            int digit10 = s[i] - '0';
            int digit1 = i + 1 < s.Length ? s[i + 1] - '0' : 27;

            if (digit10 == 0)
            {
                // There are zero possible ways to
                // decode a letter where the starting
                // digit is 0 or the only digit is 0.
                a = 0;
            }
            else if (digit10 * 10 + digit1 <= 26)
            {
                // There are two possible ways to
                // decode the two digits, either by
                // digit10 * 10 + digit1 or simply
                // digit10 itself. Add b and c
                // together as they represent the
                // number of possible ways for each
                // one.
                a = b + c;
            }
            else
            {
                // There is only one possible way
                // as digit1 causes the number
                // digit10 * 10 + digit1 to be
                // greater than 26, so simply set
                // it to b as it represents the
                // number of possible ways for
                // that one.
                a = b;
            }
        }

        return a;
    }
}
