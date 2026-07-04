// RESULTS:
//      Submitted on 02 July 2026 at 01:00
//
//      8 / 8 testcases passed.
//
//      Runtime:    45 ms
//      Memory:     48.64 MB
//
// This was a hard question to purely think
// about; some drawing and careful instruction
// planning had to be done. However, this
// Sudoku solver beats 97% of people who have
// submitted their answer to this problem.

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Solves the given Sudoku <paramref name="board"/>
    /// by filling in the period characters <c>'.'</c>
    /// with the valid digits.
    /// </summary>
    /// <param name="board">The 9x9 Sudoku <see cref="char"/> matrix.</param>
    public void SolveSudoku(char[][] board)
    {
        // Table of Unicode codepoints for reference:
        // '%' = 37 | '&' = 38 | '\'' = 39 | '(' = 40
        // ')' = 41 | '*' = 42 | '+' = 43  | ',' = 44
        // '-' = 45 | '.' = 46
        //
        // '0' = 48 | '1' = 49 | '2' = 50 | '3' = 51
        // '4' = 52 | '5' = 53 | '6' = 54 | '7' = 55
        // '8' = 56

        // Preset the distinctGroups with the numbers
        // that already exist in the Sudoku board.
        // The last nine bits of the int represent
        // the existence of a digit within that group.
        int[] distinctGroups = new int[27];
        for (int row = 0; row < 9; row++)
        {
            char[] boardRow = board[row];
            for (int col = 0; col < 9; col++)
            {
                char cell = boardRow[col];
                if (cell == '.')
                {
                    // Number is not given, so skip it.
                    continue;
                }
                ToggleDistinct(row, col, cell - '1');
            }
        }

        // Keep a backtrack of possible numbers to
        // try out when the current state is invalid.
        Stack<(int newIndex, int newDigit)> backtrackStack = [];
        for (int i = 0; i < 81; i++)
        {
            // Get cell, row, and column.
            (int row, int col) = GetRowAndColumn(i);
            char cell = board[row][col];
            if (cell > '.')
            {
                continue;
            }

            // Push possible digits to the backtrackStack.
            int existingNumbers = MergeDistinct(row, col);
            for (int digit = 0; digit < 9; digit++)
            {
                if ((existingNumbers & (1 << digit)) == 0)
                {
                    backtrackStack.Push((i, digit));
                }
            }

            // Get the latest one.
            (int newI, int newDigit) = backtrackStack.Pop();
            if (newI != i)
            {
                // We reached an invalid state because there
                // were no valid digits at i that we could
                // try out, so backtrack to a previous state.
                Backtrack(ref i, newI);
                (row, col) = GetRowAndColumn(newI);
            }

            // Assign the digit.
            ToggleDistinct(row, col, newDigit);
            board[row][col] = (char)(newDigit + '%');
        }

        // The predicted digits are not the correct
        // character codepoints, so shift them to
        // make sure that they are.
        for (int row = 0; row < 9; row++)
        {
            char[] boardRow = board[row];
            for (int col = 0; col < 9; col++)
            {
                ref char cell = ref boardRow[col];
                if (cell > '.')
                {
                    continue;
                }

                cell += (char)('1' - '%');
            }
        }


        // Toggles the existence of the digit in
        // the three distinctGroups: the row, the
        // column, and the 3x3 region that the cell
        // is in.
        void ToggleDistinct(int row, int col, int digit)
        {
            distinctGroups[row] ^= 1 << digit;
            distinctGroups[col + 9] ^= 1 << digit;
            distinctGroups[col / 3 * 3 + row / 3 + 18] ^= 1 << digit;
        }

        // Merges the row, the column, and the 3x3
        // region that the cell is in into one
        // distinct digit group, used to check for
        // any digits that are not present in that
        // group.
        int MergeDistinct(int row, int col)
        {
            return distinctGroups[row] | distinctGroups[col + 9] | distinctGroups[col / 3 * 3 + row / 3 + 18];
        }

        // Moves index i to the newI, reversing
        // any changes that were made to distinctGroups
        // and the board array.
        void Backtrack(ref int i, int newI)
        {
            for (; i >= newI; i--)
            {
                (int row, int col) = GetRowAndColumn(i);
                ref char cell = ref board[row][col];
                if (cell > '.')
                {
                    continue;
                }

                ToggleDistinct(row, col, cell - '%');
                cell = '.';
            }

            i++;
        }

        // Returns the row and column for a
        // given index i.
        static (int, int) GetRowAndColumn(int i)
        {
            return (i / 9, i % 9);
        }
    }
}
