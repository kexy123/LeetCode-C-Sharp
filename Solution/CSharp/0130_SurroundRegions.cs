// RESULTS:
//      Submitted on 13 August 2026 at 21:18
//
//      59 / 59 testcases passed.
//
//      Runtime:    1 ms
//      Memory:     64.04 MB
//
// My first attempt for some reason was using a HashSet to store the coordinates of
// 'O' characters that were not surrounded, and I did not realize that I could simply
// use the matrix itself to check if a cell should be filled with an 'O' or an 'X'.

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Fills all 'O' character regions surrounded by 'X' in the <paramref name="board"/>. A
    /// region connects all 'O' characters that are cardinally adjacent to each other, and a
    /// region is not surrounded if it has 'O' characters that are on the edge of the
    /// <paramref name="board"/>.
    /// </summary>
    /// <param name="board">The <see langword="char"/> matrix to modify.</param>
    public void Solve(char[][] board)
    {
        int rows = board.Length, columns = board[0].Length;

        // Check for outside 'O' characters. They are the only ones that cannot be surrounded.

        // The top and bottom of the matrix.
        for (int i = 0; i < columns; i++)
        {
            ExpandEscaping(0, i);
            ExpandEscaping(rows - 1, i);
        }

        // The left and right of the matrix, not calling ExpandEscaping for the corners as
        // they have already been visited.
        for (int i = 1; i < rows - 1; i++)
        {
            ExpandEscaping(i, 0);
            ExpandEscaping(i, columns - 1);
        }

        for (int col = 0; col < columns; col++)
        {
            for (int row = 0; row < rows; row++)
            {
                ref char cell = ref board[row][col];
                switch (cell)
                {
                    case 'O':
                        // The cell is an 'O' that is surrounded; its region doesn't touch the
                        // edges of the matrix.
                        cell = 'X';
                        break;
                    case 'E':
                        // The cell is an 'O' that touches the edge, so turn it back to an 'O'.
                        cell = 'O';
                        break;
                }
            }
        }


        // A fill algorithm that marks cells that are 'O' as 'E' and checks for adjacent
        // 'O' characters. This recursive subroutine should be first called at the edges
        // of the board.
        void ExpandEscaping(int row, int col)
        {
            if (row is < 0 || col is < 0 || row >= rows || col >= columns)
            {
                // Position is out of bounds.
                return;
            }

            ref char cell = ref board[row][col];
            if (cell is 'O')
            {
                cell = 'E';
                ExpandEscaping(row, col - 1); // North
                ExpandEscaping(row + 1, col); // East
                ExpandEscaping(row, col + 1); // South
                ExpandEscaping(row - 1, col); // West
            }
        }
    }
}
