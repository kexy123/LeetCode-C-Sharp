// RESULTS:
//      Submitted on 28 June 2026 at 23:16
//
//      88 / 88 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     49.31 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Finds the range in the sorted <see cref="int"/>
    /// array <paramref name="nums"/> that captures all
    /// duplicates of the <paramref name="target"/>
    /// number.
    /// </summary>
    /// <param name="nums">The sorted <see cref="int"/> array to inspect.</param>
    /// <param name="target">The target <see cref="int"/>.</param>
    /// <returns>The left and right indices of the range.</returns>
    public int[] SearchRange(int[] nums, int target)
    {
        // This binary search loop finds the
        // right-most element that has the
        // same value as target, hence why
        // it moves left pointer even when
        // it found an existing capture already.
        int rightOccurrence = -1, leftOccurrence = 0;
        int left = 0, right = nums.Length - 1;
        while (left <= right)
        {
            int mid = left + (right - left >> 1);
            int difference = target - nums[mid];
            switch (difference)
            {
                case 0:
                    rightOccurrence = mid;
                    left = mid + 1;
                    break;
                case < 0:
                    right = mid - 1;
                    break;
                default:
                    // Additionally, we can reduce the
                    // search space for the second loop
                    // by updating leftOccurrence.
                    leftOccurrence = mid;
                    left = mid + 1;
                    break;
            }
        }

        // Check if there was no occurrence
        // in the nums array at all. If so,
        // return [-1, -1].
        if (rightOccurrence < 0)
        {
            return [-1, -1];
        }

        // Search for the leftmost occurrence.
        // Note that two binary search loops
        // will at most be O(2 log n) which
        // asymptotically simplifies to O(log n),
        // satisfying the task's constraint.
        left = leftOccurrence;
        right = rightOccurrence;
        while (left <= right)
        {
            int mid = left + (right - left >> 1);
            int difference = target - nums[mid];
            switch (difference)
            {
                case 0:
                    leftOccurrence = mid;
                    right = mid - 1;
                    break;
                case < 0:
                    right = mid - 1;
                    break;
                default:
                    left = mid + 1;
                    break;
            }
        }

        // Return the range of the occurrence.
        return [leftOccurrence, rightOccurrence];
    }
}
