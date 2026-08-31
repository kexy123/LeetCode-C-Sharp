// RESULTS:
//      Submitted on 31 August 2026 at 22:58
//
//      150 / 150 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     42.40 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Uses a binary search algorithm to find the lowest element in a sorted distinct
    /// <see langword="int"/> array <paramref name="nums"/> that is/is not left-rotated by an
    /// arbitrary amount.
    /// </summary>
    /// <param name="nums">The distinct sorted left-rotated <see langword="int"/> array.</param>
    /// <returns>The lowest element in <paramref name="nums"/></returns>
    public int FindMin(int[] nums)
    {
        // Similar to 0033_SearchInRotatedSortedArray, but we attempt to keep track of the lowest
        // element from the very left, mid, and right parts of the nums array.

        int left = 0, right = nums.Length - 1;
        int lowest = nums[0];

        while (left < right)
        {
            if (nums[left] < nums[right])
            {
                // The subarray from left..right is normal, so nums[left] is guaranteed to be the
                // lowest in this subarray, but a lower element may have been found.
                return Math.Min(lowest, nums[left]);
            }

            int mid = left + (right - left >> 1);
            if (nums[right] < nums[mid])
            {
                // Considering this rotated subarray:
                //  [3, 4, 5, 1, 2]
                //   L     M     R
                //
                // where L, M, and R are the left, middle, and right indices of the array respectively,
                // we need to find invariants that guide us to the correct subarray to close in on. In
                // a rotated sorted array, if the array is ever rotated, then L > R, which would not
                // happen in an ascending array. Since M > R, then the subarray L..(M - 1) has elements
                // bigger than (M + 1)..R, so we should close in on this part of the subarray instead.
                // We also update the lowest to the element at R, and we don't need to do so for M
                // and L.

                lowest = Math.Min(lowest, nums[right]);
                left = mid + 1;
            }
            else
            {
                // For a rotated subarray like this:
                //  [5, 1, 2, 3, 4]
                //   L     M     R
                //
                // M < R in this case, and R < L, so M is the lowest element. We update the lowest to
                // the element at M if possible and close in on L..(M - 1), in hopes of finding a lower
                // element in that subarray. There are cases where this wouldn't happen, such as:
                //  [4, 5, 1, 2, 3]
                //   L     M     R
                //
                // in which case the subarray L..(M - 1) actually has bigger elements than (M + 1)..R.

                lowest = Math.Min(lowest, Math.Min(nums[left], nums[mid]));
                right = mid - 1;
            }
        }

        return lowest;
    }
}
