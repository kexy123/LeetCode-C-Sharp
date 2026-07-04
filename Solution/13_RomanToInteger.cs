// RESULTS:
//      Submitted on 23 June 2026 at 20:44
//
//      3999 / 3999 testcases passed.
//
//      Runtime:    1 ms
//      Memory:     49.20 MB

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Converts a Roman numeral <see cref="string"/>
    /// <paramref name="s"/> to an <see cref="int"/>.
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
    /// <param name="s">The <see cref="string"/> to convert.</param>
    /// <returns>The <see cref="int"/> value.</returns>
    /// <exception cref="NotImplementedException"/>
    public int RomanToInt(string s)
    {
        int sum = 0;

        int prev = int.MaxValue;
        foreach (char c in s)
        {
            int value = RomanCharToInt(c);

            // Find cases such as "IX", "XL", etc.
            if (value > prev)
            {
                // The sum already has a value,
                // so we must subtract by prev * 2;
                // (sum + prev + value - prev - prev)
                // = (sum + value - prev).
                //
                // prev << 1 compiles into less
                // instructions than prev * 2.
                sum += value - (prev << 1);
            }
            else
            {
                // Simply add to the sum.
                sum += value;
            }

            prev = value;
        }

        return sum;


        // This is quicker than having a
        // Dictionary<char, int>. Additionally,
        // the Dictionary object cannot be
        // constant despite its contents.
        static int RomanCharToInt(char c)
        {
            return c switch
            {
                'M' => 1000,
                'D' => 500,
                'C' => 100,
                'L' => 50,
                'X' => 10,
                'V' => 5,
                'I' => 1,
                _ => throw new NotImplementedException($"Did not implement Roman numeral '{c}'"),
            };
        }
    }
}
