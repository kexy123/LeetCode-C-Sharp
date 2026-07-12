// RESULTS:
//      Submitted on 23 June 2026 at 09:12
//
//      11511 / 11511 testcases passed.
//
//      Runtime:    2 ms
//      Memory:     36.77 MB

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Determines if a number in base-10 is
    /// a palindrome, meaning that it can be
    /// written forwards and backwards (e.g.
    /// "racecar"). Negative numbers will
    /// return <see langword="false"/>.
    /// </summary>
    /// <param name="x">The number to check in base-10.</param>
    /// <returns><see cref="true"/> if it is a palindrome; otherwise <see cref="false"/>.</returns>
    public bool IsPalindrome(int x)
    {
        switch (x)
        {
            // If number is negative, the
            // sign will make it not a
            // palindrome.
            case < 0:
                return false;
            // Any number with one digit
            // will always be a palindrome.
            case < 10:
                return true;
        }

        // There can only be at most 10
        // base-10 digits in an int.
        byte[] digits = new byte[10];

        // Get each base-10 digit from x.
        int left = 0;
        while (x > 0)
        {
            digits[left++] = (byte)(x % 10);
            x /= 10;
        }

        // Check if it is a palindrome.
        // Cancel early if the left is
        // not equal to the right. We
        // only need to check half of
        // the digits due to the symmetry.
        int halfLength = left / 2;
        for (int right = 0; right <= halfLength; right++)
        {
            if (digits[--left] != digits[right])
            {
                return false;
            }
        }

        return true;
    }
}
