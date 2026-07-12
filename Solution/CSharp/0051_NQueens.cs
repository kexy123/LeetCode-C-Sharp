// RESULTS:
//      Submitted on 05 July 2026 at 13:08
//
//      9 / 9 testcases passed.
//
//      Runtime:    5 ms
//      Memory:     53.88 MB
//
// The question says distinct solutions,
// but all solutions of the N-queens are
// distinct anyway.
// TODO: Use matrix instead of single array.

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Returns all solutions of the N-queens
    /// puzzle, that being all solutions where
    /// you can place <paramref name="n"/>-queens
    /// in a square chessboard of <paramref name="n"/>
    /// width and <paramref name="n"/> height
    /// such that they do not attack each other.
    /// </summary>
    /// <param name="n">The size of the chessboard and the number of queens to place.</param>
    /// <returns>All solutions, each one being a string array.</returns>
    public IList<IList<string>> SolveNQueens(int n)
    {
        IList<IList<string>> solutions = [];

        char[] queens = new char[n * n];

        // Prepare the backtrackStack with
        // all the coordinates of the first
        // row.
        Stack<(int x, int y)> backtrackStack = [];
        for (int x = 0; x < n; x++)
        {
            backtrackStack.Push((x, 0));
        }

        while (backtrackStack.TryPop(out (int x, int y) queen))
        {
            // Add queen to chessboard.
            ZeroOut(queen.y);
            queens[queen.y * n + queen.x] = 'Q';

            // Check if we reached the required
            // number of queens, which corresponds
            // to if we reached the end of the
            // chessboard.
            int newY = queen.y + 1;
            if (newY == n)
            {
                solutions.Add(SerializeSolution());
                continue;
            }

            // Check for every position in the row
            // if it is not being attacked and
            // push to the backtrackStack.
            for (int x = 0; x < n; x++)
            {
                if (!IsBeingAttacked(x, newY))
                {
                    backtrackStack.Push((x, newY));
                }
            }
        }

        return solutions;


        // Clears all queens in the given row.
        void ZeroOut(int row)
        {
            for (int i = row * n; i < (row + 1) * n; i++)
            {
                queens[i] = '.';
            }
        }

        // Checks if the current position
        // is being attacked by an existing
        // queen. We can ignore the current
        // row and the rows below it as
        // they will contain no queens.
        bool IsBeingAttacked(int x, int y)
        {
            // Vertical pass.
            int tempX = x;
            int tempY = y - 1;
            while (TryGetTile(tempX, tempY, out char tile))
            {
                if (tile == 'Q')
                {
                    return true;
                }

                tempY--;
            }

            // Top-left diagonal pass.
            tempX = x - 1;
            tempY = y - 1;
            while (TryGetTile(tempX, tempY, out char tile))
            {
                if (tile == 'Q')
                {
                    return true;
                }

                tempX--;
                tempY--;
            }

            // Top-right diagonal pass.
            tempX = x + 1;
            tempY = y - 1;
            while (TryGetTile(tempX, tempY, out char tile))
            {
                if (tile == 'Q')
                {
                    return true;
                }

                tempX++;
                tempY--;
            }

            return false;
        }

        // Gets the queen tile at the given
        // coordinates and writes to tile.
        // If out of bounds, return false.
        bool TryGetTile(int x, int y, out char tile)
        {
            if (x < 0 || y < 0 || x >= n || y >= n)
            {
                tile = '.';
                return false;
            }

            tile = queens[y * n + x];
            return true;
        }

        // Turns the solution char array into
        // a list of n strings of n length
        // that contain the positions of the
        // queens on the chessboard.
        IList<string> SerializeSolution()
        {
            IList<string> solution = [];
            for (int i = 0; i < n; i++)
            {
                solution.Add(new string(queens, i * n, n));
            }

            return solution;
        }
    }
}
