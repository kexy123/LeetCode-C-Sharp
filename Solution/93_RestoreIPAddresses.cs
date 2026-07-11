// RESULTS:
//      Submitted on 11 July 2026 at 23:14
//
//      146 / 146 testcases passed.
//
//      Runtime:    11 ms
//      Memory:     48.38 MB

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Returns an <see cref="IList{T}"/> of all possible
    /// <see href="https://en.wikipedia.org/wiki/IPv4">IPv4</see>
    /// addresses from the given <see cref="string"/> of
    /// digits <paramref name="s"/>.
    /// </summary>
    /// <param name="s">A <see cref="string"/> of base-10 digits.</param>
    /// <returns>An <see cref="IList{T}"/> of all possible addresses.</returns>
    public IList<string> RestoreIpAddresses(string s)
    {
        // An IPv4 address without its full stops
        // must be between 4 to 12 characters in
        // length, otherwise no valid IP can be
        // restored.
        if (s.Length < 4 || s.Length > 12)
        {
            return [];
        }

        IList<string> addresses = [];

        // There are only four segments (octets)
        // in an IPv4 address.
        Span<Range> segments = stackalloc Range[4];

        Stack<(int index, int segmentIndex, Range? range)> backtrackStack = [];
        backtrackStack.Push((0, -1, null));

        while (backtrackStack.TryPop(out (int index, int segmentIndex, Range? range) entry))
        {
            // Ignore the very first backtrack entry.
            if (entry.range is not null)
            {
                segments[entry.segmentIndex] = (Range)entry.range;
            }

            if (entry.segmentIndex == 3)
            {
                // We reached the end of the segments
                // array already. However, those segments
                // must take up the entirety of s as
                // well in order to be added.
                if (entry.index >= s.Length)
                {
                    addresses.Add($"{s[segments[0]]}.{s[segments[1]]}.{s[segments[2]]}.{s[segments[3]]}");
                }

                continue;
            }

            int num = 0;
            for (int i = entry.index; i < entry.index + 3; i++)
            {
                if (i >= s.Length)
                {
                    // Prevent IndexOutOfRangeException.
                    break;
                }

                int digit = s[i] - '0';
                num *= 10;
                num += digit;

                if (num > 255)
                {
                    // Octets in an IPv4 address must be
                    // between 0 to 255.
                    break;
                }

                backtrackStack.Push((i + 1, entry.segmentIndex + 1, entry.index..(i + 1)));

                if (i == entry.index && digit == 0)
                {
                    // Leading zeroes are invalid except
                    // for 0 itself.
                    break;
                }
            }
        }

        return addresses;
    }
}
