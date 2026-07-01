// RESULTS:
//      Submitted on 23 June 2026 at 20:16
//
//      3999 / 3999 testcases passed.
//
//      Runtime:    3 ms
//      Memory:     45.95 MB
//
// Is StringBuilder too inefficient in terms of
// time? Fastest solution used StringBuilder,
// although my implementation made the method
// slower.

public partial class Solution
{
    /// <summary>
    /// Converts an <see cref="int"/> <paramref name="num"/>
    /// to a <see cref="string"/> in Roman numerals.
    /// 
    /// For every power of ten ('I' for 1, 'X' for 10, 'C' for
    /// 100, 'M' for 1,000), there exists its multiple of five
    /// ('V' for 5, 'L' for 50, and 'D' for 50), and you simply
    /// append that character to add it by its value, e.g. "XIII"
    /// is 13.
    /// 
    /// If you put the digit before its multiple of five, i.e.
    /// "IV" or "XL", it represents four times that power of ten.
    /// For numbers greater than 4 times that power of ten, you
    /// write its multiple of five plus that power of ten to get
    /// to the number. If you reach 9 times that power of ten,
    /// you do the same for 4 times that power of ten, except
    /// with the power of ten after it, i.e. "IX" or "XC" for 9
    /// and 90 respectively.
    /// </summary>
    /// <param name="num">The <see cref="int"/> to convert.</param>
    /// <returns>The number in Roman numerals.</returns>
    public string IntToRoman(int num)
    {
        string roman = "";

        AppendRoman(1000, 'M', ' ', ' ');
        AppendRoman(100, 'C', 'D', 'M');
        AppendRoman(10, 'X', 'L', 'C');
        AppendRoman(1, 'I', 'V', 'X');

        return roman.ToString();


        // Every power of 10 has a pattern, which
        // means we can simply repeat this code.
        // We only need to do this for 'I', 'V',
        // 'X', 'L', 'C', 'D', and 'M'. The
        // divisor represents the power of ten.
        // The primary represents the primary digit,
        // and mul5 and mul10 represent the digits
        // for 5x and 10x of the primary digit.
        void AppendRoman(int divisor, char primary, char mul5, char mul10)
        {
            if (num < divisor)
            {
                return;
            }

            (int count, num) = Math.DivRem(num, divisor);

            roman += count switch
            {
                // Special case for decrement from mul10 i.e. "IX".
                9 =>             $"{primary}{mul10}",
                // Special case for decrement from mul5 i.e. "IV".
                4 =>             $"{primary}{mul5}",
                // Appending mul5 and how many are left i.e. "VIII".
                <= 8 and >= 5 => $"{mul5}{new string(primary, count - 5)}",
                // Appending the primary character i.e. "III".
                _ =>             new string(primary, count),
            };
        }
    }
}
