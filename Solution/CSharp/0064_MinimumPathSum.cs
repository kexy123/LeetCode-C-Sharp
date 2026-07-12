// RESULTS:
//      Submitted on 06 July 2026 at 20:13
//
//      66 / 66 testcases passed.
//
//      Runtime:    1 ms
//      Memory:     45.78 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Computes the lowest sum that can be
    /// taken from top-left to bottom-right
    /// given that you can only move right
    /// or down.
    /// </summary>
    /// <param name="grid">The <see cref="int"/> matrix to observe.</param>
    /// <returns>The lowest sum of the possible path.</returns>
    public int MinPathSum(int[][] grid)
    {
        int xEnd = grid[0].Length - 1;
        int yEnd = grid.Length - 1;

        for (int y = yEnd; y >= 0; y--)
        {
            for (int x = xEnd; x >= 0; x--)
            {
                if (y == yEnd && x == xEnd)
                {
                    // Note that the bottom-right cell
                    // will add the following number:
                    // Math.Min(int.MaxValue, int.MaxValue) =
                    // int.MaxValue, so escape it before
                    // it happens.
                    continue;
                }

                // Add the minimum of the bottom
                // or right tile it can go to.
                grid[y][x] += Math.Min(x < xEnd ? grid[y][x + 1] : int.MaxValue,
                                       y < yEnd ? grid[y + 1][x] : int.MaxValue);
            }
        }

        // The top-left will contain the sum.
        return grid[0][0];
    }
}
