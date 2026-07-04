// RESULTS:
//      Submitted on 02 July 2026 at 21:45
//
//      160 / 160 testcases passed.
//
//      Runtime:    11 ms
//      Memory:     49.64 MB

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Finds all unique combinations of numbers in
    /// <paramref name="candidates"/> whose sum is
    /// the <paramref name="target"/>. Duplicates
    /// of combinations can be applied.
    /// </summary>
    /// <param name="candidates">A distinct <see cref="int"/> array.</param>
    /// <param name="target">The target <see cref="int"/> to sum to.</param>
    /// <returns>The <see cref="IList{IList{int}}"/> of unique combinations.</returns>
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        IList<IList<int>> result = [];

        // Prepare the backtrackStack with a list
        // of possible states to go to.
        Stack<(int combinationIndex, int candidateIndex, int sum)> backtrackStack = [];
        for (int i = 0; i < candidates.Length; i++)
        {
            int value = candidates[i];
            if (value == target)
            {
                // All elements in candidates are
                // >= 2, so one of the combinations
                // is itself.
                result.Add([value]);
                continue;
            }
            else if (value < target)
            {
                backtrackStack.Push((0, i, value));
            }
        }

        // Backtrack stack algorithm.
        IList<int> combination = [];
        while (backtrackStack.Count > 0)
        {
            (int combinationIndex, int candidateIndex, int sum) = backtrackStack.Pop();
            TrimCombination(combinationIndex);

            combination.Add(candidates[candidateIndex]);

            for (int i = candidates.Length - 1; i >= candidateIndex; i--)
            {
                int predictedSum = sum + candidates[i];
                if (predictedSum < target)
                {
                    // There is another possible state
                    // for the algorithm to peek through.
                    backtrackStack.Push((combinationIndex + 1, i, predictedSum));
                }
                else if (predictedSum == target)
                {
                    // The element is the final one that
                    // sums to target, so simply add all
                    // combination items and the extra
                    // element to the result.
                    result.Add([.. combination, candidates[i]]);
                }
            }
        }

        return result;


        // Removes the elements at and after index
        // in the IList<int> combination.
        void TrimCombination(int index)
        {
            int nItemsToRemove = combination.Count - index;
            int count = combination.Count - 1;

            for (int i = 0; i < nItemsToRemove; i++)
            {
                combination.RemoveAt(count--);
            }
        }
    }
}
