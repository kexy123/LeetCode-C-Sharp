// RESULTS:
//      Submitted on 21 June 2026 at 21:30
//
//      63 / 63 testcases passed.
//
//      Runtime:    5 ms
//      Memory:     50.19 MB

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Returns the two indices whose <see cref="int"/>
    /// values in <paramref name="args"/> sum to
    /// <paramref name="target"/>.
    /// </summary>
    /// <remarks>
    /// This assumes that there only exists one
    /// solution, and the same element cannot be
    /// used twice.
    /// </remarks>
    /// <param name="args">An <see cref="int"/> array to search for the two sum.</param>
    /// <param name="target">The target <see cref="int"/> sum to find.</param>
    /// <returns>A two-integer array containing the indices of the two numbers that add up to <see cref="target"/>.</returns>
    public int[] TwoSum(int[] args, int target)
    {
        if (args.Length == 2)
        {
            // Simply return the indices; they are
            // guaranteed to sum to target.
            return [0, 1];
        }

        // Use a hash-map as it is considered O(1).
        Dictionary<int, int> complementLocations = [];
        for (int i = 0; i < args.Length; i++)
        {
            int value = args[i];
            if (complementLocations.TryGetValue(value, out int j))
            {
                // Another pattern we can exploit is the
                // fact that there can only ever exist two
                // duplicate values, and it's either that's
                // the solution, or isn't.
                //
                // For example, if args = [2, 4, 4] and
                // target = 6, these arguments are invalid
                // as there are two solutions.
                //
                // If args = [2, 4, 4, 3] and target = 5,
                // it is guaranteed that the two fours do
                // not sum to 5, so we remove them in the
                // hash-map.
                //
                // If args = [2, 4, 4, 3] and target = 8,
                // we can check early if the duplicate 4s
                // do sum to 8.
                if (value * 2 == target)
                {
                    return [j, i];
                }

                complementLocations.Remove(value);
            }
            else
            {
                complementLocations[value] = i;
            }
        }

        // Then check if the complement for each value
        // in args exists in complementLocations except
        // itself.
        for (int i = 0; i < args.Length; i++)
        {
            int complement = target - args[i];
            if (complementLocations.TryGetValue(complement, out int j) && j != i)
            {
                return [i, j];
            }
        }

        throw new ArgumentException("No solution", nameof(args));
    }
}