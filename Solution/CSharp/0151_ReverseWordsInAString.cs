// RESULTS:
//      Submitted on 29 August 2026 at 12:00
//
//      62 / 62 testcases passed.
//
//      Runtime:    5 ms
//      Memory:     45.63 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Removes leading, trailing, and extra spaces in-between the <see langword="string"/>
    /// <paramref name="s"/>, and reverses all the words in <paramref name="s"/>.
    /// </summary>
    /// <param name="s">The <see langword="string"/> whose words to reverse.</param>
    /// <returns>The reversed result.</returns>
    public string ReverseWords(string s)
    {
        StringBuilder reversed = new();

        bool hasSpace = true; // Prevent leading whitespace.
        int pointer = 0;
        for (int i = s.Length - 1; i >= 0; i--)
        {
            char c = s[i];
            if (c is ' ')
            {
                if (hasSpace)
                {
                    // Don't include an extra space.
                    continue;
                }

                hasSpace = true;

                reversed.Append(' ');
                pointer = reversed.Length;
            }
            else
            {
                // Insert the character at the pointer which stays the same until there's a whitespace
                // to keep the characters themselves the same.
                hasSpace = false;
                reversed.Insert(pointer, c);
            }
        }

        // If there was a space that was added at the end of the reversed result, trim it.
        return reversed.ToString()[0..^(hasSpace ? 1 : 0)];
    }
}
