// RESULTS:
//      Submitted on 03 July 2026 at 13:25
//
//      179 / 179 testcases passed.
//
//      Runtime:    1 ms
//      Memory:     64.49 MB
//
// Special thanks to ez3r_ for contributing
// to the thinking process, and one of the
// solutions in the LeetCode problem.

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Finds the lowest <see cref="int"/> not in
    /// the <paramref name="nums"/> array that is
    /// greater than zero.
    /// </summary>
    /// <param name="nums">The <see cref="int"/> array to inspect.</param>
    /// <returns>The lowest positive <see cref="int"/> greater than zero that is not in <paramref name="nums"/>.</returns>
    public int FirstMissingPositive(int[] nums)
    {
        // Variation of Counting sort; sorts all
        // the numbers by swapping at their values
        // being indices. However, negative numbers
        // and numbers out of range of the nums
        // array are ignored.
        for (int i = 0; i < nums.Length; i++)
        {
            while (nums[i] - 1 != i
                && nums[i] > 0 && nums[i] - 1 < nums.Length
                && nums[nums[i] - 1] != nums[i])
            {
                // Swap the element at i with the target
                // index being nums[i].
                (nums[i], nums[nums[i] - 1]) = (nums[nums[i] - 1], nums[i]);
            }
        }

        // Check for the first occurrence where
        // Counting sort failed, in which case
        // the first positive number that's
        // missing in the nums array.
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] - 1 != i)
            {
                return i + 1;
            }
        }

        // The entire array contains all
        // the numbers from 1 to nums.Length,
        // so return nums.Length + 1.
        return nums.Length + 1;
    }
}
