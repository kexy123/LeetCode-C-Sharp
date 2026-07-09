// RESULTS:
//      Submitted on 08 July 2026 at 19:31
//
//      27 / 27 testcases passed.
//
//      Runtime:    22 ms
//      Memory:     97.71 MB

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Returns all possible unique unordered
    /// combinations from a sorted list from 1
    /// to <paramref name="n"/> where you can
    /// choose <paramref name="k"/> elements.
    /// </summary>
    /// <param name="n">The number of elements.</param>
    /// <param name="k">The number of elements to choose.</param>
    /// <returns>All unique combinations.</returns>
    public IList<IList<int>> Combine(int n, int k)
    {
        IList<IList<int>> combinations = [];

        // Keep track of the current combination.
        int[] combination = new int[k];
        Stack<(int index, int num)> backtrackStack = [];

        (int index, int num) result = (-1, 0);
        do
        {
            if (result.index >= 0)
            {
                combination[result.index] = result.num;
                if (result.index == k - 1)
                {
                    // Reconstruct the elements in
                    // combination to prevent adding
                    // the reference instead of the
                    // values themselves.
                    combinations.Add([.. combination]);
                    continue;
                }
            }

            // Add the next possible choice after
            // result.num. Note that we can ignore
            // the elements left of result.num
            // because they are already chosen and
            // this set of combinations is unordered.
            for (int i = n; i > result.num; i--)
            {
                backtrackStack.Push((result.index + 1, i));
            }
        } while (backtrackStack.TryPop(out result));

        return combinations;
    }
}
