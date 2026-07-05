// RESULTS:
//      Submitted on 05 July 2026 at 17:19
//
//      210 / 210 testcases passed.
//
//      Runtime:    1 ms
//      Memory:     63.77 MB
//
// First solution was a two-pointer approach
// combined with backtracking until it
// exceeded LeetCode's time limit. In the
// discussion of the problem they were
// referring to Joseph Born Kadane's algorithm
// on the maximum subarray, providing an O(n)
// time complexity with O(1) space, exploiting
// a very hidden invariant that I did not spot:
// https://en.wikipedia.org/wiki/Maximum_subarray_problem#Kadane's_algorithm

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Returns the largest sum that can be
    /// formed in a contiguous subarray of
    /// the <paramref name="nums"/> array.
    /// </summary>
    /// <param name="nums">The <see cref="int"/> array to inspect.</param>
    /// <returns>The largest possible sum in a subarray of <paramref name="nums"/>.</returns>
    public int MaxSubArray(int[] nums)
    {
        int maxSum = int.MinValue;
        int currentSum = 0;

        foreach (int element in nums)
        {
            // If the element + sum of our subarray
            // is less than the current element,
            // the current subarray's sum will always
            // be less than the new element, so
            // restart the currentSum at that point.
            currentSum = Math.Max(element, currentSum + element);

            // Update the maximum sum.
            maxSum = Math.Max(maxSum, currentSum);
        }

        return maxSum;
    }
}
