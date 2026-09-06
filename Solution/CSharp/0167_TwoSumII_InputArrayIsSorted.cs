// RESULTS:
//      Submitted on 06 September 2026 at 20:35
//
//      24 / 24 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     49.45 MB

namespace Solution.CSharp.TwoSumII_InputArrayIsSorted_0167;

public partial class Solution
{
    /// <summary>
    /// Returns the two 1-indexed indices of the sorted <paramref name="numbers"/> array such that
    /// they sum to the <paramref name="target"/>.
    /// </summary>
    /// <param name="numbers">The sorted <see langword="int"/> array.</param>
    /// <param name="target">The target sum.</param>
    /// <returns>The two indices.</returns>
    public int[] TwoSum(int[] numbers, int target)
    {
        int left = 0, right = numbers.Length - 1;
        while (numbers[left] + numbers[right] is int result && result != target)
        {
            if (result > target)
            {
                // The value at numbers[right] adds too much that it exceeds the target, so go to a
                // smaller number.
                right--;
            }
            else
            {
                // The value at numbers[left] adds too little, so go to a bigger number.
                left++;
            }
        }

        // Convert the indices to 1-indexed.
        return [left + 1, right + 1];
    }
}
