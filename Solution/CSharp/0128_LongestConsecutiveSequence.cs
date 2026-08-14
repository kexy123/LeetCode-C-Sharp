// RESULTS:
//      Submitted on 13 August 2026 at 14:38
//
//      85 / 85 testcases passed.
//
//      Runtime:    18 ms
//      Memory:     64.99 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Returns the length of the longest sequence of consecutive numbers in the
    /// <paramref name="nums"/> array.
    /// </summary>
    /// <param name="nums">The <see langword="int"/> array to inspect.</param>
    /// <returns>The length of the longest sequence of consecutive numbers.</returns>
    public int LongestConsecutive(int[] nums)
    {
        // Convert the nums array into a HashSet. This is an O(n) operation.
        // Note that HashSet<int>.Contains(int) is an O(1) operation.
        HashSet<int> existed = [.. nums];

        // Loop through every number in the HashSet once. This is at worst O(1).
        int longestStreak = 0;
        foreach (int num in existed)
        {
            if (existed.Contains(num - 1))
            {
                // We ignore numbers that are not the start of a sequence as
                // they have or could be visited in other numbers.
                continue;
            }

            // Find the end of the consecutive sequence, and check if it is higher than
            // the longest consecutive sequence that was found.
            int current = num + 1, streak = 1;
            while (existed.Contains(current))
            {
                current++;
                streak++;
            }
            longestStreak = Math.Max(longestStreak, streak);
        }

        return longestStreak;
    }
}
