// RESULTS:
//      Submitted on 14 July 2026 at 23:47
//
//      46 / 46 testcases passed.
//
//      Runtime:    4 ms
//      Memory:     43.78 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Computes the sum of the shortest path from the
    /// top to the bottom of the <paramref name="triangle"/>.
    /// </summary>
    /// <param name="triangle">A triangular <see cref="int"/> array.</param>
    /// <returns>The sum of the shortest path to get from the top to the bottom.</returns>
    public int MinimumTotal(IList<IList<int>> triangle)
    {
        // Traverse triangle from the bottom-up.
        for (int i = triangle.Count - 2; i >= 0; i--)
        {
            IList<int> row = triangle[i];
            IList<int> rowUnder = triangle[i + 1];

            for (int j = 0; j < row.Count; j++)
            {
                // Sum by the minimum of the
                // sum of the left and the
                // sum of the right.
                row[j] += Math.Min(rowUnder[j], rowUnder[j + 1]);
            }
        }

        return triangle[0][0];
    }
}
