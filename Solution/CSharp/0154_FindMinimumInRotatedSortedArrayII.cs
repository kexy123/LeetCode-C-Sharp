// RESULTS:
//      Submitted on 31 August 2026 at 23:13
//
//      193 / 193 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     43.77 MB
//
// Directly borrowed from 0153_FindMinimumInRotatedSortedArray, except with an extra case to check for
// duplicate left and right elements.

namespace Solution.CSharp.FindMinimumInRotatedSortedArrayII_0154;

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
        int left = 0, right = nums.Length - 1;
        int lowest = nums[0];

        while (left < right)
        {
            if (nums[left] < nums[right])
            {
                return Math.Min(lowest, nums[left]);
            }
            else if (nums[left] == nums[right])
            {
                // The extra case added here compared to 0153_FindMinimumInRotatedSortedArray is in a
                // subarray such as:
                //  [2, 2, 3, 4, 2]
                //   L     M     R
                //
                // where L and R have the same value. In which case, the only best way is to close it
                // on the middle, by moving the L and R pointers closer together, and updating the
                // lowest element if possible:
                //  [2, 2, 3, 4, 2]
                //      L  M  R
                left++;
                right--;
                lowest = Math.Min(lowest, nums[left]);

                continue;
            }

            int mid = left + (right - left >> 1);
            if (nums[right] < nums[mid])
            {
                lowest = Math.Min(lowest, nums[right]);
                left = mid + 1;
            }
            else
            {
                lowest = Math.Min(lowest, Math.Min(nums[left], nums[mid]));
                right = mid - 1;
            }
        }

        return lowest;
    }
}
