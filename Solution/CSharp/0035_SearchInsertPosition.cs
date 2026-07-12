// RESULTS:
//      Submitted on 28 June 2026 at 23:26
//
//      66 / 66 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     43.21 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Searches for the occurrence of <paramref name="target"/>
    /// in the distinct sorted <see cref="int"/> array
    /// <paramref name="nums"/>. If not, returns the index of
    /// where the item would be inserted at.
    /// </summary>
    /// <param name="nums">The distinct sorted <see cref="int"/> array.</param>
    /// <param name="target">The target <see cref="int"/> to search for.</param>
    /// <returns>The index of the occurrence, otherwise the index of where it should be inserted at.</returns>
    public int SearchInsert(int[] nums, int target)
    {
        // Binary search approach.
        int left = 0, right = nums.Length - 1;
        while (left < right)
        {
            int mid = left + (right - left >> 1);
            int difference = target - nums[mid];
            switch (difference)
            {
                case 0:
                    return mid;
                case > 0:
                    left = mid + 1;
                    break;
                case < 0:
                    right = mid - 1;
                    break;
            }
        }

        // We need to find where the number
        // would be inserted at now. At
        // this point, left == right.
        // If nums[left] < target, then
        // it must be next to the left
        // pointer. Otherwise, it is the
        // left pointer.
        return nums[left] < target ? left + 1 : left;
    }
}
