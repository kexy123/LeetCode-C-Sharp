// RESULTS:
//      Submitted on 01 September 2026 at 19:52
//
//      76 / 76 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     42.60 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Finds a local maximum in the <paramref name="nums"/> array where all elements don't have
    /// neighbors of equal value, and the ends of the array are implied to be negative infinity.
    /// </summary>
    /// <param name="nums">The <see langword="int"/> array.</param>
    /// <returns>The index of a local maximum that was found in <paramref name="nums"/>.</returns>
    public int FindPeakElement(int[] nums)
    {
        int left = 0, right = nums.Length - 1;

        while (true)
        {
            int mid = left + (right - left >> 1);

            bool gLeft = mid is > 0 && nums[mid] < nums[mid - 1];
            bool gRight = mid < nums.Length - 1 && nums[mid] < nums[mid + 1];

            if (!gLeft && !gRight)
            {
                // The element at mid is a peak element (a local maximum), so it can be returned.
                return mid;
            }

            // If the element is not a local maximum, then it must be part of a downwards or upwards
            // slope. In which case, binary search can try to find the local maximum in one half by
            // checking what the slope is at the midpoint. For example, for [3, 4, 3, 2, 1] where
            // mid = 2:
            //
            //   ^
            //  / \
            //   # \
            //  ### \
            //  #### \
            //  #####
            //  -----
            //
            // the slope is downwards, meaning that the left neighbor is greater than the midpoint. We
            // should be checking for a local maximum in this half. Additionally, a segment on the
            // other half probably does not have a local maximum either, so we must avoid that half.
            // Because the ends of the array are negative infinity, the array will always have a point
            // where it ascends before it descends, giving a local maximum. For an array
            // like [3, 2, 1, 2, 3]:
            //
            // ^   ^
            //  \ /
            // # | #
            // ## ##
            // #####
            // -----
            //
            // The midpoint is a local minimum. Both halves of the array therefore have a local
            // maximum, so we can simply check one side all the time, which is the right side in
            // this implementation.
            if (gLeft)
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }
    }
}
