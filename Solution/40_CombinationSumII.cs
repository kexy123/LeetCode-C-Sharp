// RESULTS:
//      Submitted on 03 July 2026 at 11:04
//
//      176 / 176 testcases passed.
//
//      Runtime:    7 ms
//      Memory:     47.89 MB
//
// This is a recursive approach compared to
// a stack-based approach because of time
// limit issues.

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Finds all unique combinations of numbers in
    /// <paramref name="candidates"/> whose sum is
    /// the <paramref name="target"/>. Duplicates
    /// of combinations do not count, although it
    /// can use elements that appear multiple times.
    /// </summary>
    /// <param name="candidates">An <see cref="int"/> array that can contain duplicate elements.</param>
    /// <param name="target">The target <see cref="int"/> to sum to.</param>
    /// <returns>The <see cref="IList{IList{int}}"/> of unique combinations.</returns>
    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        // Sort the array so that duplicates
        // are next to each other.
        Array.Sort(candidates);

        int old = 0;

        IList<int> combination = [];
        IList<IList<int>> result = [];
        for (int i = 0; i < candidates.Length; i++)
        {
            int value = candidates[i];
            if (value == old)
            {
                // This prevents any duplicate combinations.
                continue;
            }

            combination.Add(value);
            DFSCombinationSum(i, value);
            combination.Clear();

            old = value;
        }

        return result;


        // Depth-first search combination sum
        // method. It ignores all duplicates.
        void DFSCombinationSum(int candidateIndex, int sum)
        {
            // The sum is already the target,
            // so add it to result.
            if (sum == target)
            {
                result.Add([.. combination]);
                return;
            }

            int old = 0;
            for (int i = candidateIndex + 1; i < candidates.Length; i++)
            {
                int value = candidates[i];
                if (value == old)
                {
                    // This prevents any duplicate
                    // combinations form happening.
                    continue;
                }

                int predictedSum = sum + value;
                if (predictedSum <= target)
                {
                    combination.Add(value);
                    DFSCombinationSum(i, predictedSum);
                    combination.RemoveAt(combination.Count - 1);
                }

                old = value;
            }
        }
    }
}
