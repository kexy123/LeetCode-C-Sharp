// RESULTS:
//      Submitted on 10 July 2026 at 16:26
//
//      99 / 99 testcases passed.
//
//      Runtime:    6 ms
//      Memory:     59.26 MB
//
// I unfortunately had to look up how a
// monotonic Stack would be used in this
// problem. Conceptualizing the algorithm
// for this problem was also not easy.

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Computes the area of the largest rectangle
    /// that can fit within the columns of the
    /// <see cref="int"/> array <paramref name="heights"/>
    /// if it was arranged as a histogram where
    /// the values represented the heights of each
    /// unit column.
    /// </summary>
    /// <param name="heights">The <see cref="int"/> array of column heights.</param>
    /// <returns>The area of the largest rectangle.</returns>
    public int LargestRectangleArea(int[] heights)
    {
        int maxArea = 0;

        // Keeps track of the last index
        // and its height. This Stack is
        // monotonic.
        Stack<(int index, int height)> areas = new(heights.Length);
        for (int i = 0; i < heights.Length; i++)
        {
            int height = heights[i];

            int lastIndex = i;
            while (areas.TryPeek(out (int index, int height) entry) && entry.height > height)
            {
                // Pops the last elements in the areas
                // Stack whose height is greater than
                // the current height. This is because
                // that entry strictly cannot grow any
                // larger, so simply compute its area
                // and check if it is bigger.
                areas.Pop();

                // Because the height is bigger than
                // this, the index can be moved back
                // as the rectangle for the current
                // column can also fit in the columns
                // on the left to it.
                maxArea = Math.Max(maxArea, entry.height * (i - entry.index));
                lastIndex = entry.index;
            }

            areas.Push((lastIndex, height));
        }

        // Compute maximum area with the
        // final elements in the stack.
        while (areas.TryPop(out (int index, int height) entry))
        {
            maxArea = Math.Max(maxArea, entry.height * (heights.Length - entry.index));
        }

        return maxArea;
    }
}
