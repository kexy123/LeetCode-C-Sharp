// RESULTS:
//      Submitted on 09 July 2026 at 21:59
//
//      170 / 170 testcases passed.
//
//      Runtime:    143 ms
//      Memory:     52.96 MB
//
// TODO: After personal case testing, this O(n)
// solution should only take a few dozen microseconds
// at best, however LeetCode says that it is over
// 100 ms, with the fact that other solutions in C#
// have spread-out runtimes between the 100-180 ms
// range as well. Resubmit if they have fixed this
// issue.

namespace Solution.RemoveDuplicatesFromSortedArrayII_80;

public partial class Solution
{
    /// <summary>
    /// Removes all duplicates in <paramref name="nums"/>
    /// in-place such that each element will only appear
    /// at most twice.
    /// </summary>
    /// <param name="nums">The <see cref="int"/> array to remove duplicates from.</param>
    /// <returns>The new length of the <paramref name="nums"/> array.</returns>
    public int RemoveDuplicates(int[] nums)
    {
        // Track duplicates and the value
        // of the previous element in nums.
        bool hasDuplicate = false;
        int old = nums[0];

        int left = 1;
        for (int right = 1; right < nums.Length; right++)
        {
            int rightNum = nums[right];
            if (rightNum == old)
            {
                if (hasDuplicate)
                {
                    // This will only happen if
                    // the element appeared more
                    // than twice, so ignore this
                    // element and only move the
                    // right pointer.
                    continue;
                }

                // This will happen if the first
                // duplicate was found.
                hasDuplicate = true;
            }
            else
            {
                // Reset hasDuplicate and old.
                old = rightNum;
                hasDuplicate = false;
            }

            // Move the rightNum to the
            // index of the left.
            nums[left] = rightNum;
            left++;
        }

        // The new length of the nums
        // array is the left pointer.
        return left;
    }
}
