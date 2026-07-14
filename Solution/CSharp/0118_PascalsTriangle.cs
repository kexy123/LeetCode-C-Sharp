// RESULTS:
//      Submitted on 14 July 2026 at 23:23
//
//      30 / 30 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     40.12 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Generates the sequence of Pascal's
    /// triangle divided into its rows as
    /// a triangular array.
    /// </summary>
    /// <param name="numRows">The number of rows to generate.</param>
    /// <returns>The <see cref="IList{T}"/> of rows of Pascal's triangle.</returns>
    public IList<IList<int>> Generate(int numRows)
    {
        IList<IList<int>> rows = [];

        int[] prevRow = [1];
        for (int i = 1; i < numRows; i++)
        {
            rows.Add(prevRow);

            // The first and last elements of
            // the row are always 1.
            int[] row = new int[i + 1];
            row[0] = 1;
            row[^1] = 1;

            for (int j = 1; j < row.Length - 1; j++)
            {
                // 1
                // 1 1
                // 1 # 1
                // 1 # # 1
                //
                // The # are the numbers that are to be
                // computed, which is the sum of its top
                // and top-left adjacent elements in the
                // diagram.
                row[j] = prevRow[j - 1] + prevRow[j];
            }

            prevRow = row;
        }

        // Prevent unnecessary computation of
        // the next row.
        rows.Add(prevRow);

        return rows;
    }
}
