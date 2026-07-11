// RESULTS:
//      Submitted on 11 July 2026 at 18:18
//
//      16 / 16 testcases passed.
//
//      Runtime:    1 ms
//      Memory:     57.64 MB
//
// Finding the value for bit cannot be found in
// O(1) time complexity, so the time complexity
// of the whole solution varies depending on the
// value of i.

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Returns a valid sequence of unique <see cref="int"/>
    /// values from 0 to 2^<paramref name="n"/> - 1 where
    /// every adjacent number in its binary representation
    /// differs by one bit. This also includes the difference
    /// between the start and end of the sequence, and this
    /// sequence always starts at 0.
    /// </summary>
    /// <param name="n">A <see cref="int"/> that represents a power of two of the number of values in the sequence.</param>
    /// <returns>A valid distinct <see cref="int"/> sequence.</returns>
    public IList<int> GrayCode(int n)
    {
        // Prepare the sequence array.
        int[] sequence = new int[1 << n];

        int num = 0;
        for (int i = 0; i < sequence.Length - 1; i++)
        {
            // https://oeis.org/A007814
            // Find the minimum power of two that
            // is divisible by i, also known as
            // the least-significant bit that is 0.
            int bit = 0;
            while ((i & 1 << bit) != 0)
            {
                bit++;
            }

            // XOR the current number at that bit. This
            // ensures that only one bit is changed per
            // iteration.
            num ^= 1 << bit;
            sequence[i + 1] = num;
        }

        return sequence;
    }
}
