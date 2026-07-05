// RESULTS:
//      Submitted on 05 July 2026 at 22:46
//
//      20 / 20 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     39.90 MB
//
// Directly borrowed from 54_SpiralMatrix.

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Generates a <paramref name="n"/> by
    /// <paramref name="n"/> matrix where
    /// numbers from 1 to <paramref name="n"/>-squared
    /// are arranged in an outward-in clockwise
    /// spiral.
    /// </summary>
    /// <param name="n">The size of the matrix.</param>
    /// <returns>The generated spiral matrix.</returns>
    public int[][] GenerateMatrix(int n)
    {
        // Prepare the square matrix.
        int[][] matrix = new int[n][];
        for (int i = 0; i < n; i++)
        {
            matrix[i] = new int[n];
        }

        int top = 0, right = n - 1, bottom = n - 1, left = 0;
        int x = 0, y = 0;

        byte direction = (byte)(n == 1 ? 1 : 0);
        for (int i = 1; i <= n * n; i++)
        {
            matrix[y][x] = i;

            switch (direction)
            {
                case 0:
                    x++;
                    if (x == right)
                    {
                        top++;
                        direction = 1;
                    }
                    break;
                case 1:
                    y++;
                    if (y == bottom)
                    {
                        right--;
                        direction = 2;
                    }
                    break;
                case 2:
                    x--;
                    if (x == left)
                    {
                        bottom--;
                        direction = 3;
                    }
                    break;
                case 3:
                    y--;
                    if (y == top)
                    {
                        left++;
                        direction = 0;
                    }
                    break;
            }
        }

        return matrix;
    }
}
