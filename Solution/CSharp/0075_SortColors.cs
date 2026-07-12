// RESULTS:
//      Submitted on 08 July 2026 at 14:13
//
//      89 / 89 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     46.58 MB
//
// The most common solution is the Dutch National
// Flag algorithm, which simply pushes all the
// reds (0) to the left and all the blues (2) to
// the right, indirectly causing the whites (1)
// to be in the middle. However, the solution I
// made is a variation of Counting sort, which
// keeps track of the three colors and technically
// still performs a single-pass albeit at worst
// is at most O(3n), which simplifies to O(n).
// However, this method is scalable to more
// colors unlike the Dutch National Flag method.

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Sorts red (0), white (1), and blue (2)
    /// in the <paramref name="nums"/> array
    /// in ascending order.
    /// </summary>
    /// <param name="nums">The <see cref="int"/> array of colors to order.</param>
    /// <exception cref="NotImplementedException"/>
    public void SortColors(int[] nums)
    {
        int red = 0, white = 0, blue = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            ref int color = ref nums[i];
            IncrementColor(color);

            while (!IsInSection(color, i))
            {
                int target = GetLastOfSection(color);

                // Swap current element to target index.
                (color, nums[target]) = (nums[target], color);
            }
        }


        // Gets the index of the last item in
        // the known color section.
        int GetLastOfSection(int color)
        {
            return color switch
            {
                0 => red - 1,
                1 => red + white - 1,
                2 => red + white + blue - 1,
                _ => throw new NotImplementedException($"Did not implement color {color}")
            };
        }

        // Determines if the given color at
        // that index is in its color section.
        bool IsInSection(int color, int index)
        {
            return color switch
            {
                0 => index < red,
                1 => index < red + white,
                2 => index < red + white + blue,
                _ => throw new NotImplementedException($"Did not implement color {color}")
            };
        }

        // Increments the given color.
        void IncrementColor(int color)
        {
            switch (color)
            {
                case 0:
                    red++;
                    break;
                case 1:
                    white++;
                    break;
                case 2:
                    blue++;
                    break;
            }
        }
    }
}
