// RESULTS:
//      Submitted on 23 June 2026 at 19:47
//
//      65 / 65 testcases passed.
//
//      Runtime:    1 ms
//      Memory:     61.20 MB
//
// TODO: My first thought was the two-pointer
// approach, although I was concerned if
// there were edge cases to writing the
// method in this way. Looking at the
// title of a solution to disprove my
// suspicion is cheating, so I might take
// the effort to prove that it will always
// return the maximum rectangle.

public partial class Solution
{
    /// <summary>
    /// Returns the maximum area of water that can be
    /// contained between two columns, where every
    /// <see cref="int"/> in <paramref name="height"/>
    /// is a column of that height all spaced one unit
    /// apart such that they are on a horizontal line.
    /// </summary>
    /// <param name="height">The heights of the columns.</param>
    /// <returns>The maximum area of water that can be contained.</returns>
    public int MaxArea(int[] height)
    {
        // Set left and right pointers to the
        // ends of the height array.
        int left = 0, right = height.Length - 1;
        int maxArea = 0;

        // Once the left and right cross paths,
        // the algorithm will be symmetrical,
        // so end early.
        while (left != right)
        {
            // Update maxArea if needed. The area
            // is the lower element (as the height)
            // multiplied by the distance between
            // the pointers (as the width).
            int area = int.Min(height[left], height[right]) * (right - left);
            if (area > maxArea)
            {
                maxArea = area;
            }

            // We want to move a pointer to an
            // element that is potentially higher
            // than its previous.
            if (height[left] > height[right])
            {
                right--;
            }
            else
            {
                left++;
            }
        }

        return maxArea;
    }
}
