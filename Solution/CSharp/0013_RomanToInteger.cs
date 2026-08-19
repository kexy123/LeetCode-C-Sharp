// RESULTS:
//      Submitted on 23 June 2026 at 20:44
//
//      3999 / 3999 testcases passed.
//
//      Runtime:    1 ms
//      Memory:     49.20 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Converts a Roman numeral <see langword="string"/> <paramref name="s"/> to an
    /// <see langword="int"/>.
    /// </summary>
    /// <param name="s">The <see langword="string"/> to convert.</param>
    /// <returns>The <see langword="int"/> value.</returns>
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
                // The sum already has a value, so we must subtract by prev * 2;
                // (sum + prev + value - prev - prev) = (sum + value - prev).
                //
                // prev << 1 compiles into less instructions than prev * 2.
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


        // This is quicker than having a Dictionary<char, int>. Additionally, the Dictionary object
        // cannot be constant despite its contents.
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
