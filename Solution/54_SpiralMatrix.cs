// RESULTS:
//      Submitted on 05 July 2026 at 18:02
//
//      27 / 27 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     46.75 MB

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Returns an <see cref="int"/> array of the
    /// outward-in clockwise spiral that would be
    /// formed from the given <paramref name="matrix"/>.
    /// </summary>
    /// <param name="matrix">The <see cref="int"/> matrix.</param>
    /// <returns>The spiral transformed to an array.</returns>
    public IList<int> SpiralOrder(int[][] matrix)
    {
        int matrixWidth = matrix[0].Length;
        int matrixHeight = matrix.Length;

        int[] spiral = new int[matrixHeight * matrixWidth];

        // Prepare bounds of inward spiral.
        int top = 0, right = matrixWidth - 1, bottom = matrixHeight - 1, left = 0;
        int x = 0, y = 0;

        // If the matrix has a width of 1,
        // go down instead of right to
        // avoid an IndexOutOfBoundsException.
        byte direction = (byte)(matrixWidth == 1 ? 1 : 0);
        for (int i = 0; i < matrixHeight * matrixWidth; i++)
        {
            spiral[i] = matrix[y][x];
            switch (direction)
            {
                // Spiral is moving right.
                case 0:
                    x++;
                    if (x == right)
                    {
                        top++;
                        direction = 1;
                    }
                    break;
                // Spiral is moving down.
                case 1:
                    y++;
                    if (y == bottom)
                    {
                        right--;
                        direction = 2;
                    }
                    break;
                // Spiral is moving left.
                case 2:
                    x--;
                    if (x == left)
                    {
                        bottom--;
                        direction = 3;
                    }
                    break;
                // Spiral is moving up.
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

        return spiral;
    }
}
