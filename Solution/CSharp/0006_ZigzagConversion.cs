// RESULTS:
//      Submitted on 22 June 2026 at 22:20
//
//      1157 / 1157 testcases passed.
//
//      Runtime:    6 ms
//      Memory:     46.12 MB

using System.Text;

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Shifts the characters in <paramref name="s"/>
    /// when forming as a zigzag from top-bottom
    /// left-right and bottom-top diagonally.
    /// </summary>
    /// <param name="s">The <see cref="string"/> to shift.</param>
    /// <param name="numRows">The number of rows in each segment.</param>
    /// <returns>The returned <see cref="string"/>.</returns>
    public string Convert(string s, int numRows)
    {
        // The entire string will be in a single
        // column/row, so simply return the string
        // as is.
        if (s.Length <= numRows || numRows == 1)
        {
            return s;
        }

        // Looking at example 2:
        //
        // Convert("PAYPALISHIRING", 4)
        //   => P  I  N
        //      A LS IG
        //      YA HR
        //      P  I
        //   => "PINALSIGYAHRPI"
        //
        // The top and bottom rows will always
        // contain one character per segment,
        // each segment being numRows and
        // numRows - 1 columns.
        //
        // There is also at most two characters
        // in every row of each segment.

        int charsPerSegment = (numRows << 1) - 2;

        // Using a regular string will take 
        StringBuilder result = new(s.Length);

        ZigzagLastRow(0); // First row.

        for (int row = 1; row < numRows - 1; row++)
        {
            int zigzagNext = (numRows - row << 1) - 2;

            // Extension of ZigzagLastRow(int) for
            // two characters in each segment.
            int i = row;
            while (i < s.Length)
            {
                result.Append(s[i]);

                i += zigzagNext;

                // Alternate zigzagNext between itself
                // and its complement.
                zigzagNext = charsPerSegment - zigzagNext;
            }
        }

        ZigzagLastRow(numRows - 1); // Last row.

        return result.ToString();


        // Adjoin the single characters in the
        // top or bottom row of each segment.
        void ZigzagLastRow(int i)
        {
            while (i < s.Length)
            {
                result.Append(s[i]);
                i += charsPerSegment;
            }
        }
    }
}
