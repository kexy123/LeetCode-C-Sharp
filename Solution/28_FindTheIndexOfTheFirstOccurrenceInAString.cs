// RESULTS:
//      Submitted on 25 June 2026 at 22:15
//
//      85 / 85 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     39.97 MB

namespace Solution;

public partial class Solution
{
    public int StrStr(string haystack, string needle)
    {
        int needleLength = needle.Length;

        // We can cut off early as any
        // index greater than
        // haystack.Length - needleLength
        // will not have a size big enough
        // for needle to match.
        for (int i = 0; i <= haystack.Length - needleLength; i++)
        {
            // Check if the substring is equal to the needle.
            if (haystack.Substring(i, needleLength) == needle)
            {
                return i;
            }
        }

        // Return -1 if a match was not found.
        return -1;
    }
}
