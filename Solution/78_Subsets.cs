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
    public IList<IList<int>> Subsets(int[] nums)
    {
        IList<IList<int>> combinations = [[]];

        // Keep track of the current subset.
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
                backtrackStack.Push((result.index + 1, i, nums[i]));
            }
        } while (backtrackStack.TryPop(out result));

        return combinations;
    }
}
