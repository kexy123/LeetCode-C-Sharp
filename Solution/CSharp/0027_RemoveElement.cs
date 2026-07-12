// RESULTS:
//      Submitted on 25 June 2026 at 22:06
//
//      116 / 116 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     46.59 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Removes all occurrences of the target <see cref="int"/>
    /// <paramref name="val"/> in array <paramref name="nums"/>
    /// and shifts all elements after it to take its place.
    /// </summary>
    /// <param name="nums">The <see cref="int"/> array to change.</param>
    /// <param name="val">The target <see cref="int"/> to remove.</param>
    /// <returns>How many elements there are now.</returns>
    public int RemoveElement(int[] nums, int val)
    {
        int i = 0;

        for (int j = 0; j < nums.Length; j++)
        {
            // Ditto to 0026_RemoveDuplicatesFromSortedArray;
            // it is guaranteed for i <= j, so nums[j] won't
            // be affected by nums[i].
            if (nums[j] != val)
            {
                nums[i++] = nums[j];
            }
        }

        // Return the length of distinct
        // elements, which is i.
        return i;
    }
}
