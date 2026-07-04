// RESULTS:
//      Submitted on 04 July 2026 at 20:12
//
//      26 / 26 testcases passed.
//
//      Runtime:    1 ms
//      Memory:     47.64 MB
//
// I simply borrowed from 31_NextPermutation
// to solve this problem.

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Returns all permutation clones after
    /// <paramref name="nums"/> before going
    /// back to itself.
    /// </summary>
    /// <param name="nums">The distinct <see cref="int"/> array to permute.</param>
    /// <returns>The array of permutations.</returns>
    public IList<IList<int>> Permute(int[] nums)
    {
        IList<IList<int>> results = [[.. nums]];

        // Calculate how many permutations there
        // are for the given number of elements
        // in nums. It is equal to the factorial
        // of nums.Length.
        int numPermutations = 1;
        for (int i = 2; i <= nums.Length; i++)
        {
            numPermutations *= i;
        }

        // Skip the first permutation we have,
        // which is the original nums array,
        // which is why i = 1.
        for (int i = 1; i < numPermutations; i++)
        {
            NextPermutation();
            results.Add([.. nums]);
        }

        return results;


        // Borrowed method from 31_NextPermutation.
        void NextPermutation()
        {
            int k = -1, l = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i < nums.Length - 1 && nums[i] < nums[i + 1] && i > k)
                {
                    k = i;
                }
                else if (i > l && k >= 0 && nums[i] > nums[k])
                {
                    l = i;
                }
            }

            if (k == -1)
            {
                Reverse(0);
                return;
            }

            (nums[k], nums[l]) = (nums[l], nums[k]);
            Reverse(k + 1);
        }

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
