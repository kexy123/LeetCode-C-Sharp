// RESULTS:
//      Submitted on 21 June 2026 at 21:30
//
//      63 / 63 testcases passed.
//
//      Runtime:    5 ms
//      Memory:     50.19 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Returns the only two indices whose <see langword="int"/> values in <paramref name="args"/>
    /// sum to <paramref name="target"/>.
    /// </summary>
    /// <param name="args">An <see langword="int"/> array to search for the two sum.</param>
    /// <param name="target">The target <see langword="int"/> sum to find.</param>
    /// <returns>A two-integer array containing the indices of the two numbers that add up to <see cref="target"/>.</returns>
    public int[] TwoSum(int[] args, int target)
    {
        if (args.Length == 2)
        {
            // Simply return the indices; they are guaranteed to sum to target.
            return [0, 1];
        }

        // Use a Dictionary as array accesses are considered O(1).
        Dictionary<int, int> complementLocations = [];
        for (int i = 0; i < args.Length; i++)
        {
            int value = args[i];
            if (complementLocations.TryGetValue(value, out int j))
            {
                // Another pattern we can exploit is the fact that there can only ever exist two
                // duplicate values, and it's either that they are/are not the solution.
                //
                // For example, if args = [2, 4, 4] and target = 6, these arguments are invalid
                // as there are two solutions.
                //
                // If args = [2, 4, 4, 3] and target = 5, it is guaranteed that the two fours do
                // not sum to 5, so we remove them in the Dictionary.
                //
                // If args = [2, 4, 4, 3] and target = 8, we can check early if the duplicate 4s
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

        // Check if the complement for each value in args exists in complementLocations
        // except itself.
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