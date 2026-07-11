// RESULTS:
//      Submitted on 08 July 2026 at 19:54
//
//      10 / 10 testcases passed.
//
//      Runtime:    2 ms
//      Memory:     46.63 MB
//
// Similar to 77_Combine, but with an added
// numsIndex in the backtrackStack.

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Returns an <see cref="IList{T}"/> of all unique
    /// subsets in the distinct <paramref name="nums"/>
    /// <see cref="int"/> array.
    /// </summary>
    /// <param name="nums">The distinct <see cref="int"/> array.</param>
    /// <returns>All unique subsets of the <paramref name="nums"/> array.</returns>
    public IList<IList<int>> Subsets(int[] nums)
    {
        // The empty subset will always exist in
        // any nums array.
        IList<IList<int>> combinations = [[]];

        // Keep track of the current subset.
        List<int> subset = [];
        Stack<(int index, int numsIndex, int num)> backtrackStack = [];

        (int index, int numsIndex, int num) result = (-1, -1, 0);
        do
        {
            if (result.index >= 0)
            {
                // Add number to subset and add that
                // combination to combinations.
                subset.RemoveRange(result.index, subset.Count - result.index);
                subset.Add(result.num);
                combinations.Add([.. subset]);
            }

            // Push more subsets. These will always
            // be unique subsets.
            for (int i = nums.Length - 1; i > result.numsIndex; i--)
            {
                backtrackStack.Push((result.index + 1, i, nums[i]));
            }
        } while (backtrackStack.TryPop(out result));

        return combinations;
    }
}
