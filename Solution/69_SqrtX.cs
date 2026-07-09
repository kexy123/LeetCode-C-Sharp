// RESULTS:
//      Submitted on 07 July 2026 at 15:51
//
//      1019 / 1019 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     29.43 MB
//
// My first submission was at worst O(n)
// time because it combined both a binary
// search O(log n) and a linear search O(n),
// which made the binary search irrelevant.
// After removing all division from the
// method and figuring out quirks about
// binary search, the algorithm now has
// O(log n) time complexity.

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Computes the square root of
    /// <paramref name="x"/> rounded down
    /// to the nearest <see cref="int"/>,
    /// given that <paramref name="x"/> is
    /// positive.
    /// </summary>
    /// <param name="x">A positive <see cref="int"/>.</param>
    /// <returns>The square root of <paramref name="x"/>.</returns>
    public int MySqrt(int x)
    {
        if (x == 0)
        {
            // Avoid a DivideByZeroException from
            // the binary search.
            return 0;
        }

        int left = 0;
        int right = 1;

        // Double right until x / right is
        // greater than right, meaning that
        // the square root cannot be greater
        // than or equal to right.
        while (x >= (long)right * right)
        {
            left = right;
            right <<= 1;

            if (x == (long)right * right)
            {
                // x is a perfect square whose
                // square root is a power of 2.
                return right;
            }
        }

        // Binary search from left to right
        // the square root of x rounded down
        // to the nearest integer.
        while (right > left + 1)
        {
            // Compute the midpoint between the
            // left and right pointers, square
            // midpoint (as a long to avoid
            // overflow), and check if it is
            // greater than, equal to, or less
            // than x.
            int midpoint = left + (right - left >> 1);
            long difference = x - (long)midpoint * midpoint;

            switch (difference)
            {
                case 0:
                    // x is a perfect square.
                    return midpoint;
                case > 0:
                    // Move left pointer.
                    left = midpoint;
                    break;
                case < 0:
                    // Move right pointer.
                    right = midpoint;
                    break;
            }
        }

        // Check which number is higher and valid.
        return (long)right * right > x ? left : right;
    }
}
