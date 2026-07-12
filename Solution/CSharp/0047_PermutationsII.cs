// RESULTS:
//      Submitted on 04 July 2026 at 20:57
//
//      33 / 33 testcases passed.
//
//      Runtime:    341 ms
//      Memory:     51.51 MB
//
// TODO: A backtracking recursive algorithm
// was the fastest solution, and the intended
// topic this question hinted on was backtracking,
// so rewrite this algorithm when appropriate.

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Returns all unique permutations after
    /// <paramref name="nums"/> before going
    /// back to itself.
    /// </summary>
    /// <param name="nums">The <see cref="int"/> array that can contain duplicates to permute.</param>
    /// <returns>The array of unique permutations.</returns>
    public IList<IList<int>> PermuteUnique(int[] nums)
    {
        IList<IList<int>> results = [[.. nums]];

        // Ditto to 0046_Permutations.
        int numPermutations = 1;
        for (int i = 2; i <= nums.Length; i++)
        {
            numPermutations *= i;
        }

        // Create the base permutation array
        // which is the first lexicographical
        // array in the permutation sequence,
        // that being a sorted-ascending array.
        int[] basePermutation = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            basePermutation[i] = i;
        }

        // Check uniqueness if the conversion to
        // HashSet<int> removed duplicates in the
        // nums array. If unique, simply add all
        // permutations.
        bool isUnique = nums.ToHashSet().Count == nums.Length;

        for (int i = 1; i < numPermutations; i++)
        {
            NextPermutation();
            TryAdd();
        }

        return results;


        // Borrowed method from 0031_NextPermutation,
        // but uses basePermutation as a mask to
        // swap nums array.
        void NextPermutation()
        {
            int k = -1, l = -1;
            for (int i = 0; i < basePermutation.Length; i++)
            {
                if (i < basePermutation.Length - 1 && basePermutation[i] < basePermutation[i + 1] && i > k)
                {
                    k = i;
                }
                else if (i > l && k >= 0 && basePermutation[i] > basePermutation[k])
                {
                    l = i;
                }
            }

            if (k == -1)
            {
                Reverse(0);
                return;
            }

            Swap(k, l);
            Reverse(k + 1);
        }

        void Reverse(int start)
        {
            int j = basePermutation.Length - 1;
            for (int i = 0; i < (basePermutation.Length - start) / 2; i++)
            {
                Swap(i + start, j--);
            }
        }

        // Swaps both elements in the basePermutation
        // and the nums array.
        void Swap(int i, int j)
        {
            (nums[i], nums[j]) = (nums[j], nums[i]);
            (basePermutation[i], basePermutation[j]) = (basePermutation[j], basePermutation[i]);
        }

        // Attempts to add the current permutation
        // of the nums array to the results array
        // which must satisfy uniqueness.
        void TryAdd()
        {
            if (!isUnique)
            {
                for (int i = 0; i < results.Count; i++)
                {
                    // This implementation is quicker than
                    // nums.SequenceEquals(results[i]);
                    // and avoids the check for length equality.

                    // Check for value equality in
                    // each element of both arrays.
                    IList<int> permutation = results[i];
                    for (int j = 0; j < nums.Length; j++)
                    {
                        if (nums[j] != permutation[j])
                        {
                            goto NotEqual;
                        }
                    }
                    return;
                    // Avoid the return statement.
                NotEqual:;
                }
            }

            // If none of the arrays in results
            // contains the current permutation
            // of nums, add to the result.
            results.Add([.. nums]);
        }
    }
}
