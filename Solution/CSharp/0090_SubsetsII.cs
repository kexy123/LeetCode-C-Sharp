// RESULTS:
//      Submitted on 11 July 2026 at 19:13
//
//      20 / 20 testcases passed.
//
//      Runtime:    3 ms
//      Memory:     47.43 MB
//
// Directly borrowed from 0078_Subsets, but adds a check
// to determine if a branch should be pushed or not.
// TODO: Additionally, DFS is better in this scenario
// compared to BFS, so rewrite to DFS when appropriate.
// The same applies to 0078_Subsets.

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Returns an <see cref="IList{T}"/> of all unique
    /// subsets in the <paramref name="nums"/> 
    /// <see cref="int"/> array that might contain
    /// duplicates, given that the duplicate items do
    /// not discount each other in the subsets.
    /// </summary>
    /// <param name="nums">The <see cref="int"/> array.</param>
    /// <returns>All unique subsets of <paramref name="nums"/>.</returns>
    public IList<IList<int>> SubsetsWithDup(int[] nums)
    {
        // Sort the nums array.
        nums.Sort();

        IList<IList<int>> combinations = [[]];

        List<int> subset = [];
        Stack<(int index, int numsIndex, int num)> backtrackStack = [];

        (int index, int numsIndex, int num) result = (-1, -1, 0);
        do
        {
            if (result.index >= 0)
            {
                subset.RemoveRange(result.index, subset.Count - result.index);
                subset.Add(result.num);
                combinations.Add([.. subset]);
            }

            for (int i = nums.Length - 1; i > result.numsIndex; i--)
            {
                if (i > result.numsIndex + 1 && nums[i] == nums[i - 1])
                {
                    // Do not push to backtrackStack since
                    // the same number will have already
                    // formed the subsets.
                    continue;
                }

                backtrackStack.Push((result.index + 1, i, nums[i]));
            }
        } while (backtrackStack.TryPop(out result));

        return combinations;
    }
}
