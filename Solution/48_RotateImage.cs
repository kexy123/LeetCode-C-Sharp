// RESULTS:
//      Submitted on 04 July 2026 at 21:15
//
//      21 / 21 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     46.47 MB

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Rotates a square <paramref name="matrix"/>
    /// 90-degrees clockwise.
    /// </summary>
    /// <param name="matrix">The <see cref="int"/> square matrix to transform.</param>
    public void Rotate(int[][] matrix)
    {
        // Diagram of which cells (in #) to
        // transform via the Rotate method.
        // This forms an upside-down pyramid,
        // and the perfectly-centered element
        // doesn't need to be rotated.
        //
        // ####0  ###0  ##0  #0  0
        // 0##00  0#00  000  00
        // 00000  0000  000
        // 00000  0000
        // 00000
        for (int y = 0; y < matrix.Length / 2; y++)
        {
            for (int x = y; x < matrix.Length - y - 1; x++)
            {
                Rotate(x, y);
            }
        }


        // Rotates the given cell's position
        // in the matrix by 90 degrees clockwise
        // at the matrix's origin by swapping
        // the other three cells.
        void Rotate(int x, int y)
        {
            ref int top = ref matrix[y][x];
            ref int right = ref matrix[x][^(y + 1)];
            ref int bottom = ref matrix[^(y + 1)][^(x + 1)];
            ref int left = ref matrix[^(x + 1)][y];

            int temp = top;
            top = left;
            left = bottom;
            bottom = right;
            right = temp;
        }
    }
}
