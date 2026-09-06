// RESULTS:
//      Submitted on 06 September 2026 at 20:02
//
//      42 / 42 testcases passed.
//
//      Runtime:    3 ms
//      Memory:     39.40 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Divides the <paramref name="numerator"/> by the <paramref name="denominator"/> and returns the
    /// non-repeating decimal expansion, wrapping the repeating decimal form in parentheses.
    /// </summary>
    /// <param name="numerator">The numerator.</param>
    /// <param name="denominator">The nonzero denominator.</param>
    /// <returns>The decimal expansion of the fraction.</returns>
    public string FractionToDecimal(int numerator, int denominator)
    {
        if (numerator is 0)
        {
            return "0";
        }

        StringBuilder result = new();

        // Implementation of long division, an elementary method used to commonly divide two whole
        // numbers together.
        bool hasDecimal = false, zeroSkipped = false;

        // A dictionary of visited remainders after the decimal point used to detect a cycle.
        Dictionary<long, int> visited = [];

        // We need to work with positive values.
        long newDenominator = Math.Abs((long)denominator);
        long quotient, remainder = Math.Abs((long)numerator);
        while (remainder is > 0)
        {
            long oldRemainder = remainder;
            if (hasDecimal && visited.TryGetValue(remainder, out int position))
            {
                // A cycle has been detected.
                result.Insert(position - 1, '(');
                result.Append(')');
                break;
            }

            (quotient, remainder) = Math.DivRem(remainder, newDenominator);
            if (quotient is 0)
            {
                // The remainder is too small for the denominator now.
                remainder *= 10;

                if (!hasDecimal)
                {
                    if (result.Length is 0)
                    {
                        // Make it a "0." for result.
                        result.Append('0');
                    }

                    result.Append('.');
                    hasDecimal = true;
                }
                
                if (zeroSkipped)
                {
                    result.Append('0');
                }
                else
                {
                    // When we multiply by ten once, we skip adding a zero once.
                    zeroSkipped = true;
                }
                continue;
            }

            zeroSkipped = false;
            result.Append(quotient);
            if (hasDecimal)
            {
                visited[oldRemainder] = result.Length;
            }
        }

        if (Math.Sign(numerator) != Math.Sign(denominator))
        {
            // Add the negative sign if either the numerator or denominator is negative.
            result.Insert(0, '-');
        }

        return result.ToString();
    }
}
