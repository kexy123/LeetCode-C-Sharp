// RESULTS:
//      Submitted on 04 July 2026 at 15:23
//
//      1812 / 1812 testcases passed.
//
//      Runtime:    267 ms
//      Memory:     52.84 MB
//
// This recursive approach uses memoization,
// a technique which I have not used.
// However, the fastest solution exploits
// more invariants that I didn't discover.

namespace Solution.CSharp.WildcardMatching_0044;

public partial class Solution
{
    /// <summary>
    /// Determines if the pattern <paramref name="p"/>
    /// greedily matches the entire <see cref="string"/>
    /// <paramref name="s"/>, given the question mark ('?')
    /// is a wildcard and the asterisk ('*') greedily matches
    /// any sequence of characters, including an empty sequence.
    /// </summary>
    /// <param name="s">The <see cref="string"/> to go through.</param>
    /// <param name="p">The <see cref="string"/> pattern.</param>
    /// <returns><see langword="true"/> if the pattern <paramref name="p"/> matched; otherwise <see langword="false"/>.</returns>
    public bool IsMatch(string s, string p)
    {
        HashSet<(int iS, int iP)> invalidMatches = [];

        return Match(0, 0);


        // A recursive string pattern matching algorithm.
        // This method will halt and return true if and
        // only if the indexers for s and p reached the
        // end at the same time.
        bool Match(int iS, int iP)
        {
            for (; iP < p.Length; iP++)
            {
                char pChar = p[iP];
                switch (pChar)
                {
                    // Greedily match any sequence
                    // of characters until it finds
                    // the biggest possible match.
                    case '*':
                        (char? branch, int minNextMatchLength) = TrackForTarget(ref iP);
                        if (branch is null)
                        {
                            // Pattern ends in a sequence of
                            // asterisks, so the match will
                            // be true nonetheless.
                            return true;
                        }

                        for (int i = iS; i <= s.Length - minNextMatchLength; i++)
                        {
                            if (branch == '?' || s[i] == branch)
                            {
                                if (!invalidMatches.Contains((i, iP)) && Match(i, iP))
                                {
                                    // The rest of s was captured
                                    // in p by the Match method.
                                    return true;
                                }
                                else
                                {
                                    // Add the invalid state to
                                    // invalidMatches to not go
                                    // through this point again.
                                    invalidMatches.Add((i, iP));
                                }
                            }
                        }

                        return false;
                    // Wildcard character.
                    case '?':
                        if (iS >= s.Length)
                        {
                            // iS already reached the end
                            // while iP didn't.
                            return false;
                        }
                        break;
                    // Check for char equality.
                    default:
                        // Check if in range and
                        // is equal to pChar.
                        if (iS >= s.Length || s[iS] != pChar)
                        {
                            return false;
                        }
                        break;
                }
                iS++;
            }

            // iP reached the end now, so we
            // check if iS also reached the
            // end of the string.
            return iS == s.Length;
        }

        // Skips all asterisks in the stream
        // until it finds a wildcard or a
        // regular character. If s ends in
        // asterisks, return null, which
        // indicates that p entirely captures
        // s already. The int that returns
        // is the minimum number of characters
        // to keep at the end of the stream
        // when trying to find a match.
        (char? branch, int minNextMatchLength) TrackForTarget(ref int iP)
        {
            int nextMatchLength = 0;
            char? selectedForm = null;
            int? selectedIP = null;

            for (int i = iP; i < p.Length; i++)
            {
                if (p[i] != '*')
                {
                    selectedForm ??= p[i];
                    selectedIP ??= i;
                    nextMatchLength++;
                }
            }

            iP = selectedIP ?? iP;
            return (selectedForm, nextMatchLength);
        }
    }
}
