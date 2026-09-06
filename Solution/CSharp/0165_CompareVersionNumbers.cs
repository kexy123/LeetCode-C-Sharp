// RESULTS:
//      Submitted on 06 September 2026 at 19:25
//
//      91 / 91 testcases passed.
//
//      Runtime:    1 ms
//      Memory:     39.02 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Compares two versions formatted by numbers separated by full stops and ignores leading zeroes
    /// in each revision number and trailing revision zeroes. If both versions are the same, then it
    /// returns 0; otherwise 1 if <paramref name="version2"/> is greater than
    /// <paramref name="version1"/>; otherwise -1.
    /// </summary>
    /// <param name="version1">The first version.</param>
    /// <param name="version2">The second version.</param>
    /// <returns>0 if both versions are the same; otherwise 1 if <paramref name="version2"/> is greater; otherwise -1.</returns>
    public int CompareVersion(string version1, string version2)
    {
        // Split both versions by their full stops.
        string[] v1Nums = version1.Split('.'), v2Nums = version2.Split('.');

        int longestVersion = Math.Max(v1Nums.Length, v2Nums.Length);
        for (int i = 0; i < longestVersion; i++)
        {
            // Get the revision number if it exists; otherwise 0.
            int rev1 = i < v1Nums.Length ? int.Parse(v1Nums[i]) : 0;
            int rev2 = i < v2Nums.Length ? int.Parse(v2Nums[i]) : 0;

            if (rev1 == rev2)
            {
                // Both revisions are the same.
                continue;
            }

            // Two versions are compared by their most-significant to least-significant
            // revision number.
            return rev1 > rev2 ? 1 : -1;
        }

        // Both revisions have the same numbers regardless of trailing zeroes.
        return 0;
    }
}
