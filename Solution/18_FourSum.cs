// RESULTS:
//      Submitted on 24 June 2026 at 20:17
//
//      294 / 294 testcases passed.
//
//      Runtime:    42 ms
//      Memory:     51.10 MB

public partial class Solution
{
    /// <summary>
    /// Finds value-distinct quadruplet values in
    /// an <see cref="int"/> array <paramref name="nums"/>
    /// whose sum adds to <paramref name="target"/>.
    /// </summary>
    /// <param name="nums">The array to inspect.</param>
    /// <param name="target">The target <see cref="int"/> sum.</param>
    /// <returns>The four numbers that sum to <paramref name="target"/>.</returns>
    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        // Sort the array. Ditto to
        // 16_ThreeSumClosest (3Sum Closest).
        nums.Sort();

        // This HashSet will make sure that
        // duplicate quadruplets will be
        // ignored.
        HashSet<(int, int, int, int)> quadruplets = [];
        for (int i = 0; i < nums.Length - 3; i++)
        {
            for (int j = i + 1; j <= nums.Length - 3; j++)
            {
                // Use long instead of int to
                // avoid integer underflow cases.
                long complementary = (long)target - nums[i] - nums[j];

                // Use dual-pointer approach.
                int left = j + 1;
                int right = nums.Length - 1;

                while (left != right)
                {
                    long difference = (long)complementary - nums[left] - nums[right];
                    if (difference == 0)
                    {
                        quadruplets.Add((nums[i], nums[j], nums[left], nums[right]));
                    }

                    if (difference > 0)
                    {
                        // The difference is too
                        // high, so go to a bigger
                        // element.
                        left++;
                    }
                    else
                    {
                        // The difference is too low,
                        // so go to a smaller element.
                        right--;
                    }
                }
            }
        }

        // Convert HashSet to list.
        IList<IList<int>> result = [];
        foreach ((int q0, int q1, int q2, int q3) in quadruplets)
        {
            result.Add([q0, q1, q2, q3]);
        }

        return result;
    }
}
