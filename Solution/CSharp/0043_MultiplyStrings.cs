// RESULTS:
//      Submitted on 03 July 2026 at 18:56
//
//      311 / 311 testcases passed.
//
//      Runtime:    33 ms
//      Memory:     44.47 MB

using System.Text;

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Multiples two strings <paramref name="num1"/> and
    /// <paramref name="num2"/> together, given that they
    /// are positive whole numbers.
    /// </summary>
    /// <param name="num1">The first number.</param>
    /// <param name="num2">The second number.</param>
    /// <returns>The multiplicative result as a <see cref="string"/>.</returns>
    public string Multiply(string num1, string num2)
    {
        // Put the smaller number in num2.
        if (num2.Length > num1.Length)
        {
            (num1, num2) = (num2, num1);
        }

        // Multiplicative absorption.
        if (num2 == "0" || num1 == "0")
        {
            return "0";
        }

        // Multiplicative identity.
        if (num2 == "1")
        {
            return num1;
        }
        else if (num1 == "1")
        {
            return num2;
        }

        // The maximum length of a string
        // that is the product of two
        // other strings is the sum of the
        // digits plus 1.
        int maxLength = num1.Length + num2.Length + 1;
        StringBuilder result = new(new string('0', maxLength));

        int start = maxLength;
        foreach (char digit2 in num2.Reverse())
        {
            start--;
            int digit = digit2 - '0';
            if (digit == 0)
            {
                // Multiplicative identity; it
                // would be unnecessary to add
                // zeroes repetitively.
                continue;
            }

            int place = start;
            int carry = 0;
            foreach (char digit1 in num1.Reverse())
            {
                // The multiplication of two digits added
                // with a carry that is less than 10 will
                // always be at most 2 digits long.
                int productCarry = digit * (digit1 - '0') + carry;
                (carry, int prodDigit) = Math.DivRem(productCarry, 10);

                AddDigitAt(place, prodDigit);

                place--;
            }

            // Add the carry digit.
            if (carry > 0)
            {
                AddDigitAt(place, carry);
            }
        }

        // Trim leading zeroes.
        return result.ToString().TrimStart('0');


        // Adds a digit at a given index and
        // applies carry-on addition operations
        // to the digits behind it.
        void AddDigitAt(int index, int digit)
        {
            int carry = digit;
            while (carry > 0)
            {
                (carry, int resultDigit) = Math.DivRem(result[index] - '0' + carry, 10);
                result[index] = (char)(resultDigit + '0');

                index--;
            }
        }
    }
}
