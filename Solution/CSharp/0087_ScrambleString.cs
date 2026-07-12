// RESULTS:
//      Submitted on 11 July 2026 at 17:08
//
//      290 / 290 testcases passed.
//
//      Runtime:    14 ms
//      Memory:     43.56 MB
//
// Despite the use of a 3D cube of boolean values,
// my submission surpasses 66% in terms of memory.

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Checks if <paramref name="s1"/> is a scramble
    /// of <paramref name="s2"/> given the recursive
    /// algorithm:
    /// <list type="number">
    /// <item>
    /// Split the given <see cref="string"/> into two
    /// nonempty substrings at a random position in
    /// the string. If the <see cref="string"/> has a
    /// length of 1, simply do nothing.
    /// </item>
    /// <item>
    /// Randomly decide to swap the two substrings
    /// around or not.
    /// </item>
    /// <item>
    /// Repeat steps 1 to 3 with the two substrings.
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="s1">The first <see cref="string"/>.</param>
    /// <param name="s2">The second <see cref="string"/>.</param>
    /// <returns><see langword="true"/> if they are equal scrambles to each other; otherwise <see langword="false"/>.</returns>
    public bool IsScramble(string s1, string s2)
    {
        // Keep track of the starting index of s1, s2,
        // and their length.
        bool?[,,] scramblePasses = new bool?[s1.Length, s1.Length, s1.Length];

        return CheckScramble(s1.AsSpan(), s2.AsSpan(), 0, 0);


        // Checks if the slice of s1 and s2 at the given
        // s1Start and s2Start are equal scrambles of
        // each other. An equal scramble is where s1Slice
        // and s2Slice are equal, or if you sliced both
        // into two segments each at index i, the left
        // segments are equal scrambles and the right
        // segments are equal scrambles, or if you sliced
        // s1 at i and s2 at s2.Length - i, the left
        // segment of s1 is an equal scramble to the
        // right segment of s2 and vice versa.
        bool CheckScramble(ReadOnlySpan<char> s1Slice, ReadOnlySpan<char> s2Slice, int s1Start, int s2Start)
        {
            ref bool? computedResult = ref scramblePasses[s1Start, s2Start, s1Slice.Length - 1];
            if (computedResult is not null)
            {
                // Return the already computed result.
                return (bool)computedResult;
            }

            // Check if both slices are equal or
            // if they are one character long.
            bool isEqual = s1Slice.SequenceEqual(s2Slice);
            if (s1Slice.Length == 1 || isEqual)
            {
                computedResult = isEqual;
                return isEqual;
            }

            // Slice s1 and s2 into nonempty substrings
            // at every possible index.
            for (int i = 1; i < s1Slice.Length; i++)
            {
                // Consider test case s1 = AB and s2 = BA. All slices
                // will be separated by the vertical pipe '|'.

                ReadOnlySpan<char> s1Left = s1Slice[0..i], s1Right = s1Slice[i..^0];

                // Check if the A in A|B and the B in B|A are equal scrambles,
                // and the B in A|B and the A in B|A are equal scrambles.
                if (CheckScramble(s1Left, s2Slice[0..i], s1Start, s2Start)
                 && CheckScramble(s1Right, s2Slice[i..^0], s1Start + i, s2Start + i)
                // Check if the A in A|B and the A in B|A are equal scrambles,
                // and the B in A|B and the B in B|A are equal scrambles.
                 || CheckScramble(s1Left, s2Slice[^i..^0], s1Start, s2Start + (s1Slice.Length - i))
                 && CheckScramble(s1Right, s2Slice[0..^i], s1Start + i, s2Start))
                {
                    // We found a segment split that are equal
                    // scrambles of each other either in crossed
                    // or parallel form, so return true.
                    computedResult = true;
                    return true;
                }
            }

            // No substring scrambled equality was found,
            // so return false.
            computedResult = false;
            return false;
        }
    }
}
