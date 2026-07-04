// RESULTS:
//      Submitted on 21 June 2026 at 22:44
//
//      988 / 988 testcases passed.
//
//      Runtime:    4 ms
//      Memory:     43.00 MB

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Returns the length of the longest substring
    /// in <paramref name="s"/> that only contains
    /// distinct characters.
    /// </summary>
    /// <param name="s">The <see cref="string"/> to inspect.</param>
    /// <returns>The length of the longest substring without repeating characters.</returns>
    public int LengthOfLongestSubstring(string s)
    {
        // If s.Length is 0 or 1, simply return
        // its length.
        if (s.Length < 2)
        {
            return s.Length;
        }

        // This is a sliding window approach.

        int longest = 0;
        int left = 0;

        for (int right = 0; right < s.Length; right++)
        {
            char c = s[right];
            for (int leftTest = right - 1; leftTest >= left; leftTest--)
            {
                if (s[leftTest] == c)
                {
                    // Move the sliding window.
                    left = leftTest + 1;
                    break;
                }
            }

            // Value numbering optimization automatically
            // reuses subtraction operation.
            if (right - left > longest)
            {
                longest = right - left;
            }
        }

        // The longest will be one short of the actual value.
        return longest + 1;
    }
}