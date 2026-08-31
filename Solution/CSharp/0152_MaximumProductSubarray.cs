// RESULTS:
//      Submitted on 31 August 2026 at 19:33
//
//      191 / 191 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     43.09 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Finds the maximum product that can be made from a contiguous subarray of the
    /// <paramref name="nums"/> array.
    /// </summary>
    /// <param name="nums">The <see langword="int"/> array to inspect.</param>
    /// <returns>The maximum possible product.</returns>
    public int MaxProduct(int[] nums)
    {
        int max = int.MinValue;

        bool firstNegative = false;
        int product = 1, productAfterFirstNegative = 1;
        foreach (int num in nums)
        {
            if (num is 0)
            {
                // Any subarray that contains 0 will always have a product of 0. The max number could
                // be negative though, so apply Math.Max to 0. In this case, the nums array splits into
                // subarrays separated by zeroes. Each subarray will be called a partition.
                max = Math.Max(max, 0);

                firstNegative = false;
                product = 1;
                productAfterFirstNegative = 1;
                continue;
            }

            // Because it is a product, the subarray will always be as greedy as possible as long as it
            // also consumes an even number of negative integers (because (-1) * (-1) is 1). If a
            // partition has an even number of negative integers, then the maximum product is the
            // entire partition. Otherwise, it's either the right of the partition, removing the
            // leftmost negative integer, or the left of the partition, removing the rightmost negative
            // integer, such as:
            //  [(1, 2, -3, 4, -5, 2), -6, 2, 3] = 240          // Ignoring -6.
            //  [1, 2, -3, (4, -5, 2, -6, 2, 3)] = 1440         // Ignoring -3.
            //
            // The productAfterFirstNegative computes the
            // right side of the partition ignoring the leftmost negative integer if there ever is an
            // odd number of negative integers. For the left side of the partition, that's naturally
            // calculated by the product variable as it will exclude the rightmost negative integer,
            // therefore both sides are accounted for.
            product *= num;
            if (firstNegative)
            {
                productAfterFirstNegative *= num;
                max = Math.Max(max, productAfterFirstNegative);
            }
            else if (num is < 0)
            {
                // Flag the first negative and begin the productAfterFirstNegative.
                firstNegative = true;
            }

            max = Math.Max(max, product);
        }

        return max;
    }
}
