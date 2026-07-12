// RESULTS:
//      Submitted on 05 July 2026 at 22:25
//
//      158 / 158 testcases passed.
//
//      Runtime:    1 ms
//      Memory:     51.26 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Inserts and merges the <paramref name="newInterval"/>
    /// into the <paramref name="intervals"/>.
    /// </summary>
    /// <param name="intervals">The intervals array to insert <paramref name="newInterval"/> into.</param>
    /// <param name="newInterval">The interval.</param>
    /// <returns>The new interval array with the inserted interval.</returns>
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        List<int[]> result = [];

        bool isMerging = false, added = false;
        int mergeLeft = 0, mergeRight = 0;
        foreach (int[] entry in intervals)
        {
            if (isMerging)
            {
                // Check if the left of entry is
                // within the right of newInterval,
                // in which case it should be part
                // of the merge.
                if (entry[0] <= newInterval[1])
                {
                    mergeRight = Math.Max(entry[1], mergeRight);
                    continue;
                }

                // It has exited the merge, so
                // add the merged interval to
                // the result and conclude that
                // the interval has been inserted.
                isMerging = false;
                added = true;
                result.Add([mergeLeft, mergeRight]);
            }

            // Check if the left of newInterval
            // is outside the right of entry.
            if (added || newInterval[0] > entry[1])
            {
                result.Add(entry);
            }
            else if (entry[0] > newInterval[1])
            {
                // The entirety of the entry exists
                // outside of newInterval, so there
                // is no merge to begin; you can
                // simply add the newInterval before
                // the entry.
                result.Add(newInterval);
                result.Add(entry);
                added = true;
            }
            else
            {
                // The entry is within newInterval,
                // so begin the merge process.
                mergeLeft = Math.Min(entry[0], newInterval[0]);
                mergeRight = Math.Max(entry[1], newInterval[1]);

                isMerging = true;
            }
        }

        if (isMerging)
        {
            // Add the merged interval if still
            // in the merging process.
            result.Add([mergeLeft, mergeRight]);
        }
        else if (!added)
        {
            // Add the interval if it exists at
            // the end and didn't begin any
            // merging process.
            result.Add(newInterval);
        }

        return [.. result];
    }
}
