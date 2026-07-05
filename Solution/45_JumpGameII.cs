// RESULTS:
//      Submitted on 04 July 2026 at 20:00
//
//      111 / 111 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     45.64 MB
//
// First thought was a backtracking algorithm
// similar to 44_WildcardMatching, until I
// discovered an invariant of the array that
// made the algorithm a simple linear pass,
// that being the biggest range of a number
// at a given point is related to the shortest
// path to take.

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Calculates the number of jumps of the
    /// shortest path between the start and
    /// end of the <paramref name="nums"/> array
    /// given that the elements in the array
    /// determine how far it can jump forward,
    /// given that it is guaranteed for the
    /// array to be traversable to the end.
    /// </summary>
    /// <param name="nums">The <see cref="int"/> array.</param>
    /// <returns>The number of jumps to get to the end.</returns>
    public int Jump(int[] nums)
    {
        int endTarget = nums.Length - 1;
        if (nums[0] >= endTarget)
        {
            // The very first number already
            // reaches the end of the array,
            // so return 1 jump, but if the
            // nums array only has one
            // element, then return 0 jumps.
            return 0 < endTarget ? 1 : 0;
        }

        int count = 1;
        int i = 0;
        while (i < endTarget)
        {
            // Jumps to the number whose
            // range's endpoint is the
            // furthest from all the
            // numbers of the current
            // range that i can go to.
            int furthestEndpoint = i + nums[i];
            int furthestIndex = i;
            for (int j = furthestEndpoint; j > i; j--)
            {
                int endpoint = j + nums[j];
                if (endpoint > furthestEndpoint)
                {
                    if (endpoint >= endTarget)
                    {
                        // Account for the predicted
                        // jump that can reach the
                        // end of the nums array.
                        return count + 1;
                    }

                    // Update furthest endpoint.
                    furthestEndpoint = endpoint;
                    furthestIndex = j;
                }
            }

            i = furthestIndex;
            count++;
        }

        // This code is unreachable.
        return 0;
    }
}
