// RESULTS:
//      Submitted on 28 June 2026 at 23:54
//
//      507 / 507 testcases passed.
//
//      Runtime:    2 ms
//      Memory:     49.36 MB

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Checks if the current cells in the Sudoku
    /// <paramref name="board"/> are valid; each
    /// of the nine rows, columns, and 3x3 regions
    /// have distinct numbers from 1 to 9. Unfilled
    /// cells are marked with <c>'.'</c>.
    /// </summary>
    /// <param name="board">The 9x9 <see cref="char"/> double array to inspect.</param>
    /// <returns><see langword="true"/> if the board is valid with the current cells; otherwise <see langword="false"/>.</returns>
    public bool IsValidSudoku(char[][] board)
    {
        // In a 9x9 Sudoku grid, there are
        // 9 columns, 9 rows, and 9 3x3
        // regions that all must have distinct
        // numbers from 1 to 9. Therefore
        // there are 27 distinct groups to
        // track. Here are their locations in
        // the array:
        //      0..8   -> the columns.
        //      9..17  -> the rows.
        //      18..26 -> the 3x3 regions.
        HashSet<char>[] distinctGroups = new HashSet<char>[27];
        for (int i = 0; i < 27; i++)
        {
            // Initialize all HashSet<char>.
            distinctGroups[i] = [];
        }

        for (int col = 0; col < 9; col++)
        {
            // Fortunately .NET 10.0 CoreCLR does not
            // transform x / 3 * 3 -> x during compilation.
            int groupIndex = col / 3 * 3 + 18;

            char[] rowArray = board[col];
            HashSet<char> distinctRow = distinctGroups[col];
            for (int row = 0; row < 9; row++)
            {
                char cell = rowArray[row];
                if (cell == '.')
                {
                    continue;
                }

                // Check if the current cell is present
                // in the row, column, and 3x3 region,
                // otherwise add the cell to all of them.
                if (!distinctRow.Add(cell)
                    || !distinctGroups[row + 9].Add(cell)
                    || !distinctGroups[groupIndex + row / 3].Add(cell))
                {
                    return false;
                }
            }
        }

        return true;
    }
}
