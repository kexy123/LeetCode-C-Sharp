// RESULTS:
//      Submitted on 07 July 2026 at 23:50
//
//      133 / 133 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     44.54 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Searches for the given <paramref name="target"/>
    /// in a <paramref name="matrix"/> of sorted elements
    /// per row, given that the starting element of each
    /// row is greater than or equal to the ending element
    /// of the previous row.
    /// </summary>
    /// <param name="matrix">The <see cref="int"/> matrix to search through.</param>
    /// <param name="target">The item.</param>
    /// <returns><see langword="true"/> if <paramref name="target"/> exists in <paramref name="matrix"/>; otherwise <see langword="false"/>.</returns>
    public bool SearchMatrix(int[][] matrix, int target)
    {
        int width = matrix[0].Length;
        int height = matrix.Length;

        // Binary search algorithm. The matrix
        // is sorted like an array, just that
        // the indexing scheme is 2-dimensional.
        int left = 0, right = width * height - 1;
        while (right >= left)
        {
            int midpoint = left + (right - left >> 1);

            // The row is midpoint / width, while the
            // column is midpoint % width.
            int cell = matrix[midpoint / width][midpoint % width];
            if (cell == target)
            {
                return true;
            }
            else if (cell > target)
            {
                right = midpoint - 1;
            }
            else
            {
                left = midpoint + 1;
            }
        }

        return false;
    }
}
