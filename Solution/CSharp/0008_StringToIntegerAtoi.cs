// RESULTS:
//      Submitted on 22 June 2026 at 23:58
//
//      1096 / 1096 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     41.15 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Converts a <see cref="string"/> <paramref name="s"/>
    /// to an <see cref="int"/> by reading until the number
    /// stream is invalid, i.e. non-leading whitespace,
    /// invalid characters, decimal point, and invalid sign
    /// operation placement. The number is clamped from
    /// <see cref="int.MinValue"/> to <see cref="int.MaxValue"/>.
    /// </summary>
    /// <param name="s">The <see cref="string"/> to convert.</param>
    /// <returns>The integer returned.</returns>
    public int MyAtoi(string s)
    {
        int result = 0;
        int sign = 0;
        bool isLeading = true;

        for (int i = 0; i < s.Length; i++)
        {
            switch (s[i])
            {
                case >= '0' and <= '9':
                    isLeading = false;

                    // Ensure that leading sign operations
                    // will terminate the stream.
                    if (sign == 0)
                    {
                        sign = 1;
                    }

                    int digit = s[i] - '0';

                    // Check if the result, when multiplied
                    // by 10 and added by digit, will cause
                    // an integer overflow.
                    if ((int.MaxValue - digit) / 10 < result)
                    {
                        return sign == -1 ? int.MinValue : int.MaxValue;
                    }

                    // Shift the base-10 digits to the left
                    // and add the digit.
                    result *= 10;
                    result += digit;

                    break;
                case '+':
                case '-':
                    isLeading = false;

                    // Use sign variable as indication that
                    // the sign operation is leading or not.
                    if (sign != 0)
                    {
                        return int.CopySign(result, sign);
                    }

                    sign = s[i] == '-' ? -1 : 1;

                    break;
                case ' ':
                    // Only leading whitespaces are ignored.
                    if (!isLeading)
                    {
                        return int.CopySign(result, sign);
                    }

                    break;
                default:
                    // Any other characters will terminate
                    // the stream read.
                    return int.CopySign(result, sign);
            }
        }

        return int.CopySign(result, sign);
    }
}
