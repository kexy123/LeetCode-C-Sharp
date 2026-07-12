// RESULTS:
//      Submitted on 06 July 2026 at 20:33
//
//      1499 / 1499 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     44.44 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Checks if the given <see cref="string"/>
    /// <paramref name="s"/> is a valid number.
    /// <para>
    /// A number is defined as an integer
    /// followed by an optional exponent, or a
    /// decimal followed by an optional exponent.
    /// An exponent is an integer prefixed with
    /// an 'E'. Both integers and decimals
    /// can have a leading plus or minus sign.
    /// Integers contain only digits, while
    /// decimals can either be:
    /// </para>
    /// <list type="number">
    /// <item>
    /// Digits followed by a decimal point,
    /// </item>
    /// <item>
    /// Digits followed by a decimal point followed
    /// by digits, or
    /// </item>
    /// <item>
    /// A decimal point followed by digits.
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="s">The <see cref="string"/> to inspect.</param>
    /// <returns><see langword="true"/> if <paramref name="s"/> is a valid number; otherwise <see langword="false"/>.</returns>
    public bool IsNumber(string s)
    {
        bool canPrefixSign = true;
        bool canUsePeriod = true;
        bool canUseScientific = true;
        bool digitRequired = true;

        foreach (char c in s)
        {
            switch (c)
            {
                case '+':
                case '-':
                    if (!canPrefixSign)
                    {
                        // Attempted to use a sign
                        // prefix at the wrong place,
                        // such as multiple signs
                        // or not being a prefix to
                        // a number or the exponent
                        // integer.
                        return false;
                    }

                    canPrefixSign = false;
                    break;
                case '.':
                    if (!canUsePeriod)
                    {
                        // Attempted to use a decimal
                        // point at the wrong place,
                        // such as being used multiple
                        // times or after an exponent.
                        return false;
                    }

                    // Digits aren't required after
                    // the decimal point.
                    canPrefixSign = false;
                    canUsePeriod = false;
                    break;
                case 'e':
                case 'E':
                    if (!canUseScientific || digitRequired)
                    {
                        // Attempted to use scientific E
                        // notation at the wrong place,
                        // such as when there's no numbers
                        // before it, or there are multiple
                        // E symbols.
                        return false;
                    }

                    // An integer must exist after
                    // the exponent.
                    canPrefixSign = true;
                    canUsePeriod = false;
                    canUseScientific = false;
                    digitRequired = true;
                    break;
                case >= '0' and <= '9':
                    canPrefixSign = false;
                    digitRequired = false;
                    break;
                default:
                    // Invalid number character.
                    return false;
            }
        }

        // If a digit was required, return false;
        // otherwise return true.
        return !digitRequired;
    }
}
