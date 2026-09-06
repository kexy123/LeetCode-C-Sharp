// RESULTS:
//      Submitted on 06 September 2026 at 12:26
//
//      46 / 46 testcases passed.
//
//      Runtime:    31 ms
//      Memory:     62.77 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Finds the maximum gap between two consecutive elements in <paramref name="nums"/> as if it
    /// was sorted.
    /// </summary>
    /// <param name="nums">The <see langword="int"/> array.</param>
    /// <returns>The maximum gap.</returns>
    public int MaximumGap(int[] nums)
    {
        if (nums.Length is 1)
        {
            // No possible gap can be found in an array of only one element.
            return 0;
        }

        // Implementation of Radix sort LSD: https://en.wikipedia.org/wiki/Radix_sort
        // The follow-up question asks to solve this problem in linear time and linear extra space. To
        // find the maximum gap, the array would be sorted beforehand. A linear algorithm would be
        // Counting sort, but has a major weakness when it comes to the range of numbers. Radix sort is
        // an extension of that sorting algorithm, with a time complexity of O(n log16(k + 1)) where k
        // is the maximum value in the nums array. It is log16 because of the basePower and numberBase,
        // but it can be of any other base. Note that the time complexity is only a multiple of n,
        // while other sorting algorithms may have a best time complexity of O(n log(n)) which is not
        // linear. Radix sort also uses only one linear auxiliary array.
        const int basePower = 4;
        const int numberBase = 1 << basePower;

        int[] auxiliary = new int[nums.Length];
        int max = nums.Max();
        int digit = 0;
        while (DigitCountingSort(digit))
        {
            digit++;
        }

        int maxGap = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            maxGap = Math.Max(maxGap, nums[i] - nums[i - 1]);
        }

        return maxGap;


        // A counting sort pass designed for Radix sort LSD. Sorts the nums array with the digit place
        // being the digit and the base being the basePower. Because the basePower is 4, this function
        // sorts every 4 bits in the integer, meaning that at most only 9 sorting passes are made.
        // Returns true if a sorting pass was made; otherwise false.
        bool DigitCountingSort(int digit)
        {
            long div = 1L << (basePower * digit); // The ninth sorting pass cannot fit in an int.
            if (max < div)
            {
                return false;
            }

            // Count each digit frequency from 0 to 15.
            Span<int> digitCount = stackalloc int[numberBase];
            for (int i = 0; i < nums.Length; i++)
            {
                int num = nums[i];

                digitCount[(int)(num / div) % numberBase]++;
                auxiliary[i] = num;
            }

            // Convert to cumulative frequency, which stores the last position of each digit in the
            // nums array.
            for (int i = 1; i < numberBase; i++)
            {
                digitCount[i] += digitCount[i - 1];
            }

            // Each number will be positioned from right-to-left, so sort the array from right-to-left.
            for (int i = auxiliary.Length - 1; i >= 0; i--)
            {
                int auxNum = auxiliary[i];

                ref int count = ref digitCount[(int)(auxNum / div) % numberBase];
                count--;
                nums[count] = auxNum;
            }

            return true;
        }
    }
}
