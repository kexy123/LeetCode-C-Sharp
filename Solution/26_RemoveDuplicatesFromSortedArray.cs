// RESULTS:
//      Submitted on 25 June 2026 at 22:01
//
//      362 / 362 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     51.02 MB

public partial class Solution
{
    /// <summary>
    /// Removes <see cref="int"/> duplicates from
    /// <paramref name="nums"/>.
    /// </summary>
    /// <param name="nums">The <see cref="int"/> array to change.</param>
    /// <returns>How many distinct elements there are.</returns>
    public int RemoveDuplicates(int[] nums)
    {
        int i = 1;

        // Set newValue to the first element
        // in the array. It is guaranteed that
        // there is at least one element.
        int newValue = nums[0];
        for (int j = 1; j < nums.Length; j++)
        {
            // Change newValue and write the new
            // nums[j] value to the nums array
            // at the index i and increment. It
            // is guaranteed that i <= j, so j
            // won't be affected by the changes
            // from nums[i].
            if (nums[j] != newValue)
            {
                newValue = nums[i++] = nums[j];
            }
        }

        // Return the length of distinct
        // elements, which is i.
        return i;
    }
}
