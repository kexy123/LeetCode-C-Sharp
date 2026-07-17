// RESULTS:
//      Submitted on 17 July 2026 at 22:50
//
//      490 / 490 testcases passed.
//
//      Runtime:    1 ms
//      Memory:     44.71 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Checks if the given <see cref="string"/> <paramref name="s"/>
    /// is a palindrome with case-insensitivity and only accounting
    /// for alphanumeric characters (Latin characters and digits).
    /// </summary>
    /// <param name="s">The <see cref="string"/> to inspect.</param>
    /// <returns><see langword="true"/> if it is a palindrome; otherwise <see langword="false"/>.</returns>
    public bool IsPalindrome(string s)
    {
        int left = 0;
        int right = s.Length - 1;

        // We only need to check if the string is a
        // palindrome by going over half of the
        // string and simply checking the other end.
        while (left < right)
        {
            char leftC = s[left], rightC = s[right];
            if (!IsAlphanumeric(leftC))
            {
                left++;
                continue;
            }
            else if (!IsAlphanumeric(rightC))
            {
                right--;
                continue;
            }

            // Uppercase Latin characters in ASCII in
            // binary form are prefixed with 010, while
            // lowercase Latin characters are prefixed
            // with 011, so the bitwise AND operation
            // transforms all lowercase characters to
            // uppercase characters automatically.
            if (leftC is >= 'a' and <= 'z')
            {
                leftC &= (char)0b01011111;
            }
            if (rightC is >= 'a' and <= 'z')
            {
                rightC &= (char)0b01011111;
            }

            if (leftC != rightC)
            {
                // The characters on the left and right
                // are not the same, so the string is
                // not a palindrome.
                return false;
            }

            // Move the two pointers.
            left++;
            right--;
        }

        return true;


        // Checks if the given character c is alphanumeric,
        // which means that it is either an uppercase Latin
        // character, a lowercase Latin character, or a digit.
        static bool IsAlphanumeric(char c) => c is >= 'A' and <= 'Z' or >= 'a' and <= 'z' or >= '0' and <= '9';
    }
}
