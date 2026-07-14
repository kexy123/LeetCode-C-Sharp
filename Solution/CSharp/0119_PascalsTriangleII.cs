// RESULTS:
//      Submitted on 14 July 2026 at 23:37
//
//      34 / 34 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     39.94 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Gets the row of Pascal's triangle.
    /// </summary>
    /// <param name="rowIndex">The row of Pascal's triangle to get.</param>
    /// <returns>The <see cref="int"/> array.</returns>
    public IList<int> GetRow(int rowIndex)
    {
        // Set all elements in the row to 1.
        int[] row = new int[rowIndex + 1];
        for (int i = 0; i <= rowIndex; i++)
        {
            row[i] = 1;
        }

        for (int i = 2; i <= rowIndex; i++)
        {
            // Keep track of the previous element
            // before it got its sum to compute
            // Pascal's triangle. Note that
            // row[0] = 1.
            int previous = 1;
            for (int j = 1; j < i; j++)
            {
                (previous, row[j]) = (row[j], row[j] + previous);
            }
        }

        return row;
    }
}
