// RESULTS:
//      Submitted on 16 August 2026 at 00:25
//
//      40 / 40 testcases passed.
//
//      Runtime:    4 ms
//      Memory:     58.71 MB
//
// One of the comments on LeetCode hinted at the fact that, if a starting point can't reach a given
// target, any starting point between those two points also cannot reach target. By essentially
// creating a duplicate of the gas and cost arrays to connect the endpoints makes this problem similar
// to Kadane's algorithm, just like 0053_MaximumSubarray.

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Finds the starting point of a cyclic series of gas stations where a car can wrap all the way
    /// back to the starting point.
    /// <para>
    /// The car has a gas tank that gets filled up with the number in <paramref name="gas"/>, and the
    /// car moves to the next station, reducing the gas tank by the <paramref name="cost"/> from the
    /// previous station, and the car's gas tank must never fall below 0. If no possible starting point
    /// exists, -1 is returned.
    /// </para>
    /// </summary>
    /// <param name="gas">Numbers that can fill up the car's gas tank in each gas station.</param>
    /// <param name="cost">How much gas it takes to get to the next gas station.</param>
    /// <returns>The starting point of a possible circuit; otherwise -1.</returns>
    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        int length = gas.Length;

        int currentGas = gas[0];
        int endCycle = length;
        for (int i = 1; i < length * 2; i++)
        {
            currentGas -= cost[(i - 1) % length];
            if (currentGas is < 0)
            {
                // It is guaranteed that, since you can reach at most where i is now when starting from
                // endCycle - length, all stations between endCycle - length and i - 1 can't reach i,
                // so restart at i.
                currentGas = 0;
                endCycle = i + length;
            }
            else if (i >= endCycle)
            {
                // Retrieve the starting point by simply subtracting by the length.
                return endCycle - length;
            }

            currentGas += gas[i % length];
        }

        return -1;
    }
}
