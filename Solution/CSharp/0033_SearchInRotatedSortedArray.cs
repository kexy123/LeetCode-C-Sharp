// RESULTS:
//      Submitted on 28 June 2026 at 22:06
//
//      196 / 196 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     42.11 MB
//
// Looked at a few discussion posts since
// I got stuck.

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Uses a binary search algorithm to search
    /// for <paramref name="target"/> through a
    /// sorted distinct <see cref="int"/> array
    /// <paramref name="nums"/> that is/is not
    /// left-rotated by an arbitrary amount.
    /// </summary>
    /// <param name="nums">The distinct sorted but left-rotated <see cref="int"/> array.</param>
    /// <param name="target">The target <see cref="int"/> to search for.</param>
    /// <returns>The index of where the captured element is; otherwise -1 if not.</returns>
    public int Search(int[] nums, int target)
    {
        // Binary search algorithm.
        int left = 0, right = nums.Length - 1;
        while (left < right)
        {
            // Get the midpoint between the
            // two pointers. Ties to the
            // left pointer.
            int mid = left + (right - left >> 1);

            int difference = target - nums[mid];
            if (difference == 0)
            {
                // target == nums[mid] in this case.
                return mid;
            }
            // Check if the range left..mid is sorted
            // but does not contain the pivot, or
            // check if the range mid..right is sorted
            // and contains the pivot. The rotation
            // property of the nums array makes it easy
            // to check if a segment of the array is
            // sorted by comparing the values of the
            // left and right pointers of the array.
            else if ((nums[left] <= nums[mid] && (target < nums[left] || difference > 0))
                || (nums[mid] <= nums[right] && difference > 0 && target <= nums[right]))
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        // Check if it is equal to the target,
        // otherwise return -1 since there was
        // no capture.
        return nums[left] == target ? left : -1;
    }
}
