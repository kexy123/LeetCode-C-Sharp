// RESULTS:
//      Submitted on 17 August 2026 at 20:04
//
//      61 / 61 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     46.77 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Finds the only number that doesn't have a duplicate in <paramref name="nums"/>.
    /// </summary>
    /// <param name="nums">The array to inspect, where every other number has exactly one duplicate.</param>
    /// <returns>The number that has no duplicate.</returns>
    public int SingleNumber(int[] nums)
    {
        int result = 0;
        foreach (int num in nums)
        {
            // Since every other number has exactly one duplicate, the bitwise-XOR on two exact values
            // yields 0. XOR is associative and commutative, and XOR has an identity value of 0.
            // Looking at this example:
            //  [4, 1, 2, 1, 2]
            //
            // This turns into 4 ^ 1 ^ 2 ^ 1 ^ 2
            //               = 4 ^ 1 ^ 1 ^ 2 ^ 2    // After rearranging
            //               = 4 ^ 0 ^ 0            // After cancelling out
            //               = 4                    // After removing the identity
            //
            // which is the only number that has no duplicate. XOR forms an abelian group with an
            // exponent of 2 where every element reaches the identity when the operation is applied
            // once to itself: a XOR a = 0.

            result ^= num;
        }

        return result;
    }
}
