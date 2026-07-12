// RESULTS:
//      Submitted on 06 July 2026 at 19:54
//
//      42 / 42 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     41.09 MB
//
// This one uses dynamic programming compared to
// 0062_UniquePaths. The time complexity for this
// algorithm is O(mn) where m and n are the
// dimensions of obstacleGrid.

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// From the given <paramref name="obstacleGrid"/>,
    /// computes the number of unique paths from the
    /// top-left to the bottom-right corner given that
    /// you can only move right or down.
    /// </summary>
    /// <param name="obstacleGrid">The <see cref="int"/> matrix to go over.</param>
    /// <returns>The number of unique possible paths.</returns>
    public int UniquePathsWithObstacles(int[][] obstacleGrid)
    {
        int xEnd = obstacleGrid[0].Length - 1;
        int yEnd = obstacleGrid.Length - 1;

        ref int bottomRight = ref obstacleGrid[yEnd][xEnd];
        if (bottomRight == 1)
        {
            // The bottom-right corner is blocked
            // by an obstacle, so simply return
            // 0 possible unique paths.
            return 0;
        }
        else
        {
            // Declare it as the bottom-right corner.
            bottomRight = -1;
        }

        for (int y = yEnd; y >= 0; y--)
        {
            for (int x = xEnd; x >= 0; x--)
            {
                switch (obstacleGrid[y][x])
                {
                    case -1:
                        // Bottom-right corner.
                        obstacleGrid[y][x] = 1;
                        break;
                    case 1:
                        // An obstacle.
                        obstacleGrid[y][x] = 0;
                        break;
                    case 0:
                        // Compute the sum of the bottom
                        // and right tiles adjacent to
                        // this one. This adds the number
                        // of possible paths to get to
                        // the bottom-right corner together.
                        obstacleGrid[y][x] = (x < xEnd ? obstacleGrid[y][x + 1] : 0)
                                           + (y < yEnd ? obstacleGrid[y + 1][x] : 0);
                        break;
                }
            }
        }

        // The top-left corner will be the
        // number of possible paths.
        return obstacleGrid[0][0];
    }
}
