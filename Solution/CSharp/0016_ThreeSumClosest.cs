// RESULTS:
//      Submitted on 24 June 2026 at 15:55
//
//      109 / 109 testcases passed.
//
//      Runtime:    19 ms
//      Memory:     42.97 MB
//
// Ditto to 0015_ThreeSum; finding a triplet whose
// sum adds to target or is closest to target is
// conjectured to be at least O(n^2).

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Finds a triplet in <see cref="nums"/> whose sum
    /// is closest to <see cref="target"/>.
    /// </summary>
    /// <param name="nums">The array of <see cref="int"/> to inspect.</param>
    /// <param name="target">The target sum.</param>
    /// <returns>The closest <see cref="int"/> to that sum.</returns>
    public int ThreeSumClosest(int[] nums, int target)
    {
        // Sort the array so that the lowest
        // elements are on the left and the
        // highest elements are on the right.
        nums.Sort();

        int closestSum = 0;
        int closestDifference = int.MaxValue;

        // Make an element a pivot and do a
        // dual-pointer approach.
        for (int i = 0; i < nums.Length - 2; i++)
        {
            int left = i + 1;
            int right = nums.Length - 1;
            while (left != right)
            {
                int sum = nums[left] + nums[right] + nums[i];
                int difference = sum - target;
                if (difference < 0)
                {
                    // Go to a higher element to reduce
                    // the difference if possible.
                    left++;
                }
                else
                {
                    // Go to a lower element to reduce
                    // the difference if possible.
                    right--;
                }

                // There is a triplet whose sum is
                // exactly the target, so terminate
                // early.
                if (difference == 0)
                {
                    return target;
                }

                // Check if it is closer to
                // closestDifference.
                int posDifference = Math.Abs(difference);
                if (posDifference < closestDifference)
                {
                    closestSum = sum;
                    closestDifference = posDifference;
                }
            }
        }

        return closestSum;
    }
}
