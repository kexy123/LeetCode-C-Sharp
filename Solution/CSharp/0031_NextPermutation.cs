// RESULTS:
//      Submitted on 26 June 2026 at 23:12
//
//      268 / 268 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     46.88 MB
//
// This LeetCode question was too vague and
// the pattern was too difficult for me, so
// I looked at the algorithm for generating
// the next permutation:
// https://en.wikipedia.org/wiki/Permutation#Generation_in_lexicographic_order

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Transforms to the next lexicographically greater
    /// permutation of the <paramref name="nums"/> array.
    /// </summary>
    /// <param name="nums">The <see cref="int"/> array to transform.</param>
    public void NextPermutation(int[] nums)
    {
        int k = -1, l = -1;
        for (int i = 0; i < nums.Length; i++)
        {
            // Find largest index k where
            // nums[k] < nums[k + 1].
            if (i < nums.Length - 1 && nums[i] < nums[i + 1] && i > k)
            {
                k = i;
            }
            // Find largest index l > k
            // where nums[l] > nums[k].
            else if (i > l && k >= 0 && nums[i] > nums[k])
            {
                l = i;
            }
        }

        // The array is reversed, which is
        // the final permutation, so make
        // it sorted by reversing it.
        if (k == -1)
        {
            Reverse(0);
            return;
        }

        // Swap k and l together.
        (nums[k], nums[l]) = (nums[l], nums[k]);
        // Reverse items after k.
        Reverse(k + 1);


        // Reverses the nums array
        // at a given index.
        void Reverse(int start)
        {
            int j = nums.Length - 1;
            for (int i = 0; i < (nums.Length - start) / 2; i++)
            {
                (nums[i + start], nums[j]) = (nums[j--], nums[i + start]);
            }
        }
    }
}
