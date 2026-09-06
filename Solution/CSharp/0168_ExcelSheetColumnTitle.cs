// RESULTS:
//      Submitted on 06 September 2026 at 21:15
//
//      22 / 22 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     39.23 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Converts a <paramref name="columnNumber"/> to a bijective base-26 number system with the digits
    /// being the letters of the English alphabet.
    /// </summary>
    /// <param name="columnNumber">The <see langword="int"/> to convert.</param>
    /// <returns>The resulting <see langword="string"/>.</returns>
    public string ConvertToTitle(int columnNumber)
    {
        // This naming scheme is exactly the same as Excel and Google Spreadsheets in their columns.
        // It is bijective base-26 which does not contain a digit representing 0, with 'A' being 1, 'B'
        // being 2, etc., up to 'Z' being 26.
        int quotient = columnNumber;
        StringBuilder result = new();
        while (quotient is not <= 0)
        {
            (quotient, int remainder) = Math.DivRem(quotient, 26);
            switch (remainder)
            {
                case 0:
                    // Again, there is no digit representing 0, so we ensure that this remainder is
                    // represented properly by changing the quotient.
                    result.Insert(0, 'Z');
                    quotient--;
                    break;
                case >= 1 and <= 25:
                    result.Insert(0, (char)('A' + remainder - 1));
                    break;
            }
        }

        return result.ToString();
    }
}
