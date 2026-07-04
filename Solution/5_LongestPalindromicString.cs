// RESULTS:
//      Submitted on 22 June 2026 at 20:56
//
//      143 / 143 testcases passed.
//
//      Runtime:    18 ms
//      Memory:     48.68 MB

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Returns the longest substring in <paramref name="s"/>
    /// that is a palindrome.
    /// </summary>
    /// <remarks>
    /// A palindrome is a word that can be spelt backwards
    /// and forwards, e.g. "racecar".
    /// </remarks>
    /// <param name="s">The <see cref="string"/> to inspect.</param>
    /// <returns>The longest palindromic substring in <paramref name="s"/>.</returns>
    public string LongestPalindrome(string s)
    {
        // Simply return the string as is because
        // a string with one or zero letters is a
        // palindrome, although the task restricts
        // any strings being less than one character
        // long.
        if (s.Length < 2)
        {
            return s;
        }

        // There is no explicit type to convert
        // char to string; use string interpolation.
        string result = s[0].ToString();

        // Because we are checking for the longest
        // palindromic substring, we can end the loop
        // early if it is guaranteed to not yield a
        // palindrome longer than result. This sentinel
        // must update when result is updated.
        int sentinel = 0;
        for (int i = 0; i < s.Length - sentinel; i++)
        {
            // This expands outward, checking if each character
            // at the start and end of both indices match.
            // oddPalindrome must start at a single character
            // even though it will always equal itself to avoid
            // an IndexOutOfRange exception when i = 0.
            string oddPalindrome = Expand(i, i);
            // There are cases where a palindrome has an even
            // string length, e.g. "abba", so we need to check
            // for both cases. In most cases, one or the other
            // can terminate early because of the structure of
            // the substring, so this doesn't necessarily waste
            // performance.
            string evenPalindrome = Expand(i, i + 1);

            // Check which valid palindrome is longer in length,
            // and check if it is longer than the result, and
            // update the sentinel and try updating the current
            // letter index if possible.
            string target = evenPalindrome.Length > oddPalindrome.Length ? evenPalindrome : oddPalindrome;
            if (target.Length > result.Length)
            {
                result = target;

                // The actual formula for sentinel.
                // x >> 1 is equivalent to x / 2 iff x isn't
                // negative, which can never be. However, C#
                // doesn't notice this during compilation.
                sentinel = result.Length >> 1;

                if (i < sentinel)
                {
                    // Note that i++ will be executed after this
                    // iteration.
                    i = sentinel - 1;
                }
            }
        }

        return result;

        // Expands the two indices and checks until their
        // characters of the string s are not the same.
        // Then, returns the substring of that range.
        // left and right should be at most one space
        // away to check for palindromes.
        string Expand(int left, int right)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }

            return s.Substring(left + 1, right - left - 1);
        }
    }
}
