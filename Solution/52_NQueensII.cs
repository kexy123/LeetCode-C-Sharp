// RESULTS:
//      Submitted on 05 July 2026 at 13:15
//
//      9 / 9 testcases passed.
//
//      Runtime:    6 ms
//      Memory:     30.66 MB
//
// Directly borrowed from 51_NQueens,
// except it is more efficient now that
// we only need to count the number of
// solutions, which also means we can
// reduce the char array into a BitArray
// for memory efficiency. This is
// somehow slower than 51_NQueens however.

using System.Collections;

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Returns the number of solutions of the
    /// N-queens puzzle, that being all solutions
    /// where you can place <paramref name="n"/>-queens
    /// in a square chessboard of <paramref name="n"/>
    /// width and <paramref name="n"/> height
    /// such that they do not attack each other.
    /// </summary>
    /// <param name="n">The size of the chessboard and the number of queens to place.</param>
    /// <returns>The number of solutions.</returns>
    public int TotalNQueens(int n)
    {
        int solutions = 0;

        BitArray queens = new(n * n);

        Stack<(int x, int y)> backtrackStack = [];
        for (int x = 0; x < n; x++)
        {
            backtrackStack.Push((x, 0));
        }

        while (backtrackStack.TryPop(out (int x, int y) queen))
        {
            ZeroOut(queen.y);
            queens[queen.y * n + queen.x] = true;

            int newY = queen.y + 1;
            if (newY == n)
            {
                solutions++;
                continue;
            }

            for (int x = 0; x < n; x++)
            {
                if (!IsBeingAttacked(x, newY))
                {
                    backtrackStack.Push((x, newY));
                }
            }
        }

        return solutions;


        void ZeroOut(int row)
        {
            for (int i = row * n; i < (row + 1) * n; i++)
            {
                queens[i] = false;
            }
        }

        bool IsBeingAttacked(int x, int y)
        {
            int tempX = x;
            int tempY = y - 1;
            while (TryGetTile(tempX, tempY, out bool tile))
            {
                if (tile)
                {
                    return true;
                }

                tempY--;
            }

            tempX = x - 1;
            tempY = y - 1;
            while (TryGetTile(tempX, tempY, out bool tile))
            {
                if (tile)
                {
                    return true;
                }

                tempX--;
                tempY--;
            }

            tempX = x + 1;
            tempY = y - 1;
            while (TryGetTile(tempX, tempY, out bool tile))
            {
                if (tile)
                {
                    return true;
                }

                tempX++;
                tempY--;
            }

            return false;
        }

        bool TryGetTile(int x, int y, out bool tile)
        {
            if (x < 0 || y < 0 || x >= n || y >= n)
            {
                tile = false;
                return false;
            }

            tile = queens[y * n + x];
            return true;
        }
    }
}
