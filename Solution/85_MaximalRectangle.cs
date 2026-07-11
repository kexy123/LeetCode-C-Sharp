// RESULTS:
//      Submitted on 10 July 2026 at 19:25
//
//      76 / 76 testcases passed.
//
//      Runtime:    12 ms
//      Memory:     53.56 MB
//
// This problem directly inherits from 84_LargestRectangleInHistogram.
// However, I didn't come to that relation so I looked at some
// discussion posts.

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Finds the area of the largest rectangle in the
    /// <see cref="char"/> <paramref name="matrix"/>
    /// of zeroes and ones that only consists of ones.
    /// </summary>
    /// <param name="matrix">The <see cref="char"/> matrix of zeroes and ones.</param>
    /// <returns>The largest area in the <paramref name="matrix"/> that consists of only ones.</returns>
    public int MaximalRectangle(char[][] matrix)
    {
        int maxArea = 0;

        // Essentially convert the matrix into a
        // histogram and compute the largest
        // rectangle in it.
        int[] histogram = new int[matrix[0].Length];
        Stack<(int index, int height)> areas = new(histogram.Length);
        foreach (char[] row in matrix)
        {
            for (int col = 0; col < row.Length; col++)
            {
                if (row[col] == '0')
                {
                    // Reset the histogram's column.
                    histogram[col] = 0;
                }
                else
                {
                    // Increment the column height.
                    histogram[col]++;
                }
            }

            LargestRectangleArea();
        }

        return maxArea;


        // Directly borrowed from 84_LargestRectangleInHistogram.
        void LargestRectangleArea()
        {
            areas.Clear();

            for (int i = 0; i < histogram.Length; i++)
            {
                int height = histogram[i];

                int lastIndex = i;
                while (areas.TryPeek(out (int index, int height) entry) && entry.height > height)
                {
                    areas.Pop();
                    maxArea = Math.Max(maxArea, entry.height * (i - entry.index));
                    lastIndex = entry.index;
                }

                areas.Push((lastIndex, height));
            }

            while (areas.TryPop(out (int index, int height) entry))
            {
                maxArea = Math.Max(maxArea, entry.height * (histogram.Length - entry.index));
            }
        }
    }
}
