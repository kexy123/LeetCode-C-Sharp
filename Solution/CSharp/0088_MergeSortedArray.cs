// RESULTS:
//      Submitted on 11 July 2026 at 17:38
//
//      63 / 63 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     46.88 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Merges <paramref name="nums2"/> into <paramref name="nums1"/>
    /// retaining ascending sorting order given that <paramref name="nums1"/>
    /// has enough space for the elements in <paramref name="nums2"/>.
    /// </summary>
    /// <param name="nums1">The destination <see cref="int"/> array.</param>
    /// <param name="m">The actual number of elements in <paramref name="nums1"/>.</param>
    /// <param name="nums2">The source <see cref="int"/> array.</param>
    /// <param name="n">The number of elements in <paramref name="nums2"/>.</param>
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        int nums1Right = m - 1, nums2Right = n - 1;
        for (int right = m + n - 1; right >= 0; right--)
        {
            // Check if nums2Right is still in bounds and
            // nums1Right is out of bounds or the element
            // at nums1[nums1Right] is less than
            // nums2[nums2Right].
            if (nums2Right >= 0 && (nums1Right < 0 || nums1[nums1Right] < nums2[nums2Right]))
            {
                nums1[right] = nums2[nums2Right--];
            }
            else
            {
                nums1[right] = nums1[nums1Right--];
            }
        }
    }
}
