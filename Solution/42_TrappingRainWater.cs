// RESULTS:
//      Submitted on 03 July 2026 at 14:13
//
//      324 / 324 testcases passed.
//
//      Runtime:    1 ms
//      Memory:     46.18 MB

public partial class Solution
{
    /// <summary>
    /// Calculates the amount of water that can
    /// be trapped in the <paramref name="height"/>
    /// array if the values were the heights of
    /// columns of a unit width.
    /// </summary>
    /// <param name="height">An <see cref="int"/> array.</param>
    /// <returns>The amount of water that can be contained.</returns>
    public int Trap(int[] height)
    {
        int pivot = 0, pivotValue = height[0];
        int sum = 0;

        for (int i = 1; i < height.Length; i++)
        {
            if (height[i] >= pivotValue)
            {
                // Reached the end of the rainwater
                // area, so accumulate rainwater.
                AccumulateRainWater(pivot, i);
                pivot = i;
                pivotValue = height[i];
            }
        }

        // The pivot would be the highest
        // element. Since we accumulated
        // water on the left of the highest
        // pivot, we now check for the right
        // side of the array.
        int highestPivot = pivot;
        pivot = height.Length - 1;
        pivotValue = height[^1];
        for (int i = height.Length - 1; i >= highestPivot; i--)
        {
            if (height[i] >= pivotValue)
            {
                AccumulateRainWater(i, pivot);
                pivot = i;
                pivotValue = height[i];
            }
        }

        return sum;


        // Accumulates by the complement of the lower
        // column from the left and right columns.
        void AccumulateRainWater(int left, int right)
        {
            int min = Math.Min(height[left], height[right]);

            for (int i = left + 1; i < right; i++)
            {
                sum += min - height[i];
            }
        }
    }
}
