// RESULTS:
//      Submitted on 05 July 2026 at 18:38
//
//      178 / 178 testcases passed.
//
//      Runtime:    2 ms
//      Memory:     57.54 MB
//
// Directly borrowed from 45_JumpGameII, but
// it is simplified to check for the impossibility
// of reaching the end of the given array.

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Returns a <see cref="bool"/> value if a
    /// pointer at the start of the
    /// <paramref name="nums"/> array can reach
    /// the end given that they can only jump
    /// forward by the value of the current
    /// element it is on.
    /// </summary>
    /// <param name="nums">The <see cref="int"/> array to check.</param>
    /// <returns><see langword="true"/> if it can reach the end; otherwise <see langword="false"/>.</returns>
    public bool CanJump(int[] nums)
    {
        int endTarget = nums.Length - 1;
        if (nums[0] >= endTarget)
        {
            // The nums array has a length of
            // 1 or the first value in the
            // nums array can reach the end
            // already.
            return true;
        }

        int i = 0;
        while (true)
        {
            int furthestEndpoint = i + nums[i];
            int furthestIndex = i;
            bool isImpossible = true;
            for (int j = furthestEndpoint; j > i; j--)
            {
                int endpoint = j + nums[j];
                if (endpoint > furthestEndpoint)
                {
                    // Check if endpoint can reach
                    // the end of the nums array.
                    if (endpoint >= endTarget)
                    {
                        return true;
                    }

                    isImpossible = false;
                    furthestEndpoint = endpoint;
                    furthestIndex = j;
                }
            }

            // If the furthestEndpoint stays
            // the same regardless of all the
            // elements it can jump to, then
            // it is impossible to reach the
            // end of the nums array.
            if (isImpossible)
            {
                return false;
            }

            i = furthestIndex;
        }
    }
}
