// RESULTS:
//      Submitted on 06 July 2026 at 14:10
//
//      200 / 200 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     40.24 MB
//
// After watching a video on how a permutation
// is formed by backtracking, I spotted an
// invariant when they were lexicographically
// ordered.

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Gets the <paramref name="k"/>th
    /// permutation from an <see cref="int"/>
    /// array of <paramref name="n"/> elements
    /// beginning as the sorted form.
    /// </summary>
    /// <param name="n">The number of elements.</param>
    /// <param name="k">The permutation to get.</param>
    /// <returns>The permutation concatenated as a string of digits.</returns>
    public string GetPermutation(int n, int k)
    {
        // Permutations are 0-indexed in
        // this algorithm.
        k--;

        // Compute n-factorial and preset
        // the digits list.
        int factorial = 1;
        List<char> digits = [];
        for (int i = 1; i <= n; i++)
        {
            factorial *= i;
            digits.Add((char)(i + '0'));
        }

        char[] permutation = new char[n];

        int j = n;
        for (int i = 0; i < n; i++)
        {
            // Decrement j and then divide by j.
            factorial /= j--;

            // Dividing k by the factorial result,
            // the remainder is the new value of
            // k, and the digit is the digit in
            // the current digits List to use for
            // the permutation array. k is then
            // decreased for finding the next digit.
            (int digit, k) = Math.DivRem(k, factorial);

            // Use then remove the used digit.
            permutation[i] = digits[digit];
            digits.RemoveAt(digit);
        }

        return new string(permutation);
    }
}
