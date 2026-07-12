// RESULTS:
//      Submitted on 09 July 2026 at 22:42
//
//      285 / 285 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     46.10 MB
//
// Borrowed from 33_SearchInRotatedArray but,
// at worst, this algorithm is O(n) because
// of the potential ambiguity between the left,
// the right, and the middle values and which
// side to go for, so it simply moves the left
// and right pointers closer together.

namespace Solution.SearchInRotatedSortedArrayII_81;

public partial class Solution
{
    /// <summary>
    /// Checks if the <paramref name="target"/> exists
    /// in the sorted <see cref="int"/> array
    /// <paramref name="nums"/> where the array
    /// is/is not right-rotated by an unknown amount
    /// and can contain duplicates.
    /// </summary>
    /// <param name="nums">The <see cref="int"/> array to search through.</param>
    /// <param name="target">The target <see cref="int"/> to find.</param>
    /// <returns><see langword="true"/> if it does exist in <paramref name="nums"/>; otherwise <see langword="false"/>.</returns>
    public bool Search(int[] nums, int target)
    {
        int left = 0, right = nums.Length - 1;
        while (left < right)
        {
            int mid = left + (right - left >> 1);

            int difference = target - nums[mid];
            if (difference == 0)
            {
                return true;
            }
            // This tests if both the left, the
            // right, and the middle pointers
            // are all the same. In this case,
            // it is ambiguous to which side to
            // go to, so we have to move the left
            // and right pointers closer together.
            else if (nums[left] == nums[mid] && nums[mid] == nums[right])
            {
                left++;
                right--;
            }
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

        return nums[left] == target;
    }
}
