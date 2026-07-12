// RESULTS:
//      Submitted on 24 June 2026 at 12:26
//
//      316 / 316 testcases passed.
//
//      Runtime:    418 ms
//      Memory:     75.00 MB
//
// 3Sum is a hard problem that is conjectured
// to take a time complexity of at least O(n^2).
// The fastest solution seems to use a dual
// pointer approach.

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Finds all distinct triplets in an <see cref="int"/>
    /// array <paramref name="nums"/> whose sum is 0.
    /// </summary>
    /// <param name="nums">The array to look over.</param>
    /// <returns>The array of triplets.</returns>
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        // Count how many occurrences for
        // each number in the nums array.
        Dictionary<int, int> occurrences = [];
        foreach (int num in nums)
        {
            if (occurrences.TryGetValue(num, out int value))
            {
                occurrences[num] = value + 1;
            }
            else
            {
                occurrences[num] = 1;
            }
        }

        // Pivot one element in the array,
        // and find two pairs that sum to
        // the complement to find triplets.
        HashSet<(int, int, int)> triplets = [];
        int[] occurrenceArray = [.. occurrences.Keys];
        for (int i = 0; i < occurrenceArray.Length; i++)
        {
            int firstValue = occurrenceArray[i];
            occurrences[firstValue]--;

            for (int j = i; j < occurrenceArray.Length; j++)
            {
                if (i == j && occurrences[firstValue] == 0)
                {
                    continue;
                }

                int secondValue = occurrenceArray[j];
                int complement = 0 - firstValue - secondValue;

                occurrences[secondValue]--;

                if (occurrences.TryGetValue(complement, out int count) && count > 0)
                {
                    triplets.Add(OrderTriplets(firstValue, secondValue, complement));
                }

                occurrences[secondValue]++;
            }

            occurrences[firstValue]++;
        }

        // Convert into a list of list of integers.
        IList<IList<int>> results = [];
        foreach ((int a, int b, int c) in triplets.Distinct())
        {
            results.Add([a, b, c]);
        }

        return results;


        // Orders the triplets to check if other
        // triples contain the same values.
        static (int, int, int) OrderTriplets(int a, int b, int c)
        {
            if (a >= b && a >= c)
            {
                return b >= c ? (a, b, c) : (a, c, b);
            }
            else if (b >= a && b >= c)
            {
                return a >= c ? (b, a, c) : (b, c, a);
            }
            else
            {
                return a >= b ? (c, a, b) : (c, b, a);
            }
        }
    }
}
