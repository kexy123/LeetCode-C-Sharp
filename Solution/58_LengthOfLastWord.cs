// RESULTS:
//      Submitted on 05 July 2026 at 22:35
//
//      60 / 60 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     39.41 MB

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Gets the length of the last valid
    /// word in <paramref name="s"/>.
    /// </summary>
    /// <param name="s">The <see cref="string"/> to search.</param>
    /// <returns>The length of the last word.</returns>
    public int LengthOfLastWord(string s)
    {
        // Find the first character that
        // is not a space. Note that s
        // will always contain at least
        // one word.
        int i = s.Length - 1;
        char c = s[i];
        while (c == ' ')
        {
            c = s[--i];
        }

        // Find the first character that
        // is a space, or reach the end
        // of the string.
        int wordBegin = i;
        while (c != ' ')
        {
            if (--i < 0)
            {
                // We reached the end of the
                // string, so we simply return
                // wordBegin + 1 as strings are
                // 0-indexed.
                return wordBegin + 1;
            }

            c = s[i];
        }

        // Subtract wordBegin from i.
        return wordBegin - i;
    }
}
