// RESULTS:
//      Submitted on 21 June 2026 at 23:49
//
//      2098 / 2098 testcases passed.
//
//      Runtime:    1 ms
//      Memory:     55.70 MB

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Finds the median of two arrays, <paramref name="nums1"/>
    /// and <paramref name="nums2"/>, as if they were merged and
    /// sorted.
    /// </summary>
    /// <remarks>
    /// This assumes that the given <see cref="int[]"/> arguments
    /// are already sorted in the first place.
    /// </remarks>
    /// <param name="nums1">The first array.</param>
    /// <param name="nums2">The second array.</param>
    /// <returns>The median of both arrays if they were merged.</returns>
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        int size = nums1.Length + nums2.Length;

        // evenMedian is the element directly before oddMedian.
        int evenMedian = 0, oddMedian = 0;

        // These are nested if-statements, but this is for
        // simplification.
        int i1 = 0, i2 = 0;
        for (int i = 0; i < size / 2 + 1; i++)
        {
            evenMedian = oddMedian;
            if (i1 < nums1.Length && i2 < nums2.Length)
            {
                if (nums1[i1] < nums2[i2])
                {
                    oddMedian = nums1[i1++];
                }
                else
                {
                    oddMedian = nums2[i2++];
                }
            }
            else
            {
                if (i1 < nums1.Length)
                {
                    oddMedian = nums1[i1++];
                }
                else
                {
                    oddMedian = nums2[i2++];
                }
            }
        }

        // Solve for median case where there are
        // an even number of elements in the merged
        // array.
        //
        // The even-check bitwise formula gets inlined
        // during compilation:
        // (size & 1) == 0
        if (int.IsEvenInteger(size))
        {
            return (oddMedian + evenMedian) / 2.0;
        }

        // Otherwise, return the oddMedian.
        return oddMedian;
    }
}
