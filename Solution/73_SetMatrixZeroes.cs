// RESULTS:
//      Submitted on 07 July 2026 at 23:19
//
//      203 / 203 testcases passed.
//
//      Runtime:    2 ms
//      Memory:     54.73 MB
//
// My first thought was trying to zero out
// the matrix on the first O(mn) pass, where
// m and n are the dimensions of the matrix.
// However, there were many edge cases that
// I couldn't figure out. Looking at the
// discussion, they simply said to use the
// first column and row to check which
// columns and rows should be zeroed out,
// with only two extra boolean values to
// determine if these rows themselves should
// be zeroed out at the end. This results in
// the worst case being O(n^2 + 4n) which
// simplifies to O(n^2) anyway.

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Zeroes out all rows and columns
    /// of the given <see cref="int"/>
    /// <paramref name="matrix"/> that
    /// contains a zero.
    /// </summary>
    /// <param name="matrix">The <see cref="int"/> matrix to zero out.</param>
    public void SetZeroes(int[][] matrix)
    {
        int width = matrix[0].Length;
        int height = matrix.Length;

        // We are using the first row and
        // first column to determine which
        // rows and columns to zero out,
        // and these rows themselves might
        // have to be zeroed out too.
        bool zeroFirstCol = false;
        bool zeroFirstRow = false;

        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                if (matrix[row][col] == 0)
                {
                    if (col == 0)
                    {
                        zeroFirstCol = true;
                    }

                    if (row == 0)
                    {
                        zeroFirstRow = true;
                    }

                    // Add the zero to the first of
                    // its column and row.
                    matrix[0][col] = 0;
                    matrix[row][0] = 0;
                }
            }
        }

        // Zero out all the columns under
        // the cells of the first row that
        // are a 0.
        for (int row = 1; row < height; row++)
        {
            int[] matrixRow = matrix[row];
            if (matrixRow[0] == 0)
            {
                for (int col = 1; col < width; col++)
                {
                    matrixRow[col] = 0;
                }
            }
        }

        // Zero out all the rows under
        // the cells of the first column
        // that are a 0.
        for (int col = 1; col < width; col++)
        {
            if (matrix[0][col] == 0)
            {
                for (int row = 1; row < height; row++)
                {
                    matrix[row][col] = 0;
                }
            }
        }

        if (zeroFirstCol)
        {
            // Zero out the first column.
            for (int row = 0; row < height; row++)
            {
                matrix[row][0] = 0;
            }
        }

        if (zeroFirstRow)
        {
            // Zero out the first row.
            for (int col = 0; col < width; col++)
            {
                matrix[0][col] = 0;
            }
        }
    }
}
