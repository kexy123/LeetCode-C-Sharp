// RESULTS:
//      Submitted on 07 July 2026 at 14:14
//
//      29 / 29 testcases passed.
//
//      Runtime:    2 ms
//      Memory:     47.38 MB

using System.Text;

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Returns an <see cref="IList{T}"/> of
    /// <see cref="string"/> that fully justifies
    /// the given <paramref name="words"/>,
    /// left-aligning single-words and the
    /// last line formed. Each word in each
    /// line, if justified, will have an equal
    /// number of spaces, otherwise an extra
    /// space is added to the leftmost words.
    /// </summary>
    /// <param name="words">An array of <see cref="string"/> to concatenate.</param>
    /// <param name="maxWidth">The <see cref="int"/> width of the lines.</param>
    /// <returns>The <see cref="IList{T}"/> of <see cref="string"/>.</returns>
    public IList<string> FullJustify(string[] words, int maxWidth)
    {
        IList<string> results = [];

        int start = 0;

        // Track the width of the words only
        // and the width of what the line
        // would be with a single space between
        // the words.
        int wordOnlyWidth = 0;
        int shortWidth = 0;
        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];

            // Add the word's length, and
            // prepend with a space if it
            // isn't the first word in the
            // line.
            int length = word.Length + (shortWidth > 0 ? 1 : 0);

            if (shortWidth + length > maxWidth)
            {
                // Another word cannot be put
                // into width, so compute the
                // string for the words.
                results.Add(JustifyLine(i).ToString());

                // We need to decrement i so
                // that the same word will
                // actually be processed in
                // the next line, and reset
                // line width variables.
                start = i--;
                wordOnlyWidth = 0;
                shortWidth = 0;
            }
            else
            {
                wordOnlyWidth += word.Length;
                shortWidth += length;
            }
        }

        if (shortWidth > 0)
        {
            // If there are left-out words,
            // add a final line that
            // left-aligns them. Note that
            // the final line is only
            // justified if its shortWidth
            // is equal to the maxWidth,
            // in which case only one single
            // space will need to be added
            // between the words, making it
            // identical to the LeftAlignLine
            // method.
            results.Add(LeftAlignLine(start).ToString());
        }

        return results;


        // Adds equal spacing between the
        // words from start to the given
        // index i. If spacing is not
        // divisible, add single spaces to
        // the leftmost words.
        StringBuilder JustifyLine(int i)
        {
            // The complement is the number of
            // spaces that can be in the line.
            int complement = maxWidth - wordOnlyWidth;
            StringBuilder line = new(maxWidth, maxWidth);
            if (i - start > 1)
            {
                // Compute the number of equal spaces
                // between each word and the number of
                // left words that need an extra space.
                // Note to avoid the fencepost error.
                (int spacing, int extraSpace) = Math.DivRem(complement, i - start - 1);

                for (int j = start; j < i - 1; j++)
                {
                    // Append both the word and the
                    // number of spaces, adding in
                    // the extra space if needed.
                    line.Append(words[j]);
                    line.Append(new string(' ', spacing + (extraSpace > 0 ? 1 : 0)));
                    extraSpace--;
                }
            }

            // Add the final word without spaces.
            // However, if that's the only word
            // in the line, add trailing spaces.
            line.Append(words[i - 1]);
            line.Append(new string(' ', maxWidth - line.Length));

            return line;
        }

        // Left-aligns the words by adding
        // a single space between the words
        // from start to the end of the
        // word list.
        StringBuilder LeftAlignLine(int start)
        {
            StringBuilder line = new(maxWidth, maxWidth);
            for (int j = start; j < words.Length - 1; j++)
            {
                // Append the word and the final line.
                line.Append(words[j]);
                line.Append(' ');
            }

            // Add the final word and append
            // trailing spaces. Also avoids
            // an ArgumentOutOfRangeException
            // of the capacity of the StringBuilder.
            line.Append(words[^1]);
            line.Append(new string(' ', maxWidth - line.Length));

            return line;
        }
    }
}
