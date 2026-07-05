// RESULTS:
//      Submitted on 05 July 2026 at 19:57
//
//      172 / 172 testcases passed.
//
//      Runtime:    4 ms
//      Memory:     57.18 MB

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Merges all overlapping intervals in
    /// <paramref name="intervals"/>.
    /// </summary>
    /// <param name="intervals">The array of intervals (a starting and ending <see cref="int"/>) to merge.</param>
    /// <returns>The merged intervals.</returns>
    public int[][] Merge(int[][] intervals)
    {
        // Sort by starting index in ascending order.
        intervals.Sort((a, b) => a[0].CompareTo(b[0]));

        List<int[]> merged = [];
        int start = intervals[0][0], end = intervals[0][1];
        for (int i = 1; i < intervals.Length; i++)
        {
            if (intervals[i][0] > end)
            {
                // The start of this interval does
                // not overlap with the current
                // interval the algorithm is holding,
                // so add the interval and make the
                // new interval this entry.
                merged.Add([start, end]);
                start = intervals[i][0];
            }

            // Expand or reset the interval.
            end = Math.Max(end, intervals[i][1]);
        }

        // Add the final interval to the
        // merged array.
        merged.Add([start, end]);

        return [.. merged];
    }
}
