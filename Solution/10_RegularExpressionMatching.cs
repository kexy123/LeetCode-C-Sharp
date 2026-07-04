// RESULTS:
//      Submitted on 23 June 2026 at 16:32
//
//      354 / 354 testcases passed.
//
//      Runtime:    329 ms
//      Memory:     58.87 MB
//
// TODO: Was very difficult for me to gauge and
// figure out patterns. Fastest solution
// was a recursive search call instead of
// a stack. Might rewrite later.

public partial class Solution
{
    /// <summary>
    /// Checks if the pattern <paramref name="p"/>
    /// matches the entire <see cref="string"/>
    /// <paramref name="s"/>. The wildcard <c>.</c>
    /// captures any single letter, and the
    /// quantifier <c>*</c> suffixing a
    /// character/wildcard captures many of that
    /// character as possible. If that quantifier
    /// can't capture any characters, it is ignored.
    /// </summary>
    /// <param name="s">The <see cref="string"/> to check.</param>
    /// <param name="p">The pattern to go against.</param>
    /// <returns><see langword="true"/> if the capture is entirely <paramref name="s"/>, otherwise <see langword="false"/>.</returns>
    public bool IsMatch(string s, string p)
    {
        // The tuple (int, int) is (1) The index of s
        // and (2) The index of p to backtrack to if
        // it finds a path that is invalid from
        // wildcard quantifiers.
        Stack<(int, int)> possibleStates = new();

        // Goes through the pattern p and tries to
        // find the biggest valid match. iS is the
        // index for s, and iP is the index for p.
        int iS = 0, iP = 0;
        while (iP < p.Length)
        {
            char patternChar = p[iP];

            // Check if there is a '*' quantifier after
            // patternChar.
            if (iP + 1 < p.Length && p[iP + 1] == '*')
            {
                iP += 2;
                // If this returns 1 or -1, then
                // GreedyMatch() proved that it
                // has captured s entirely, or
                // that s cannot be captured.
                switch (GreedyMatch(patternChar))
                {
                    case -1:
                        return false;
                    case 1:
                        return true;
                }
            }
            else if (patternChar == '.') // Wildcard character.
            {
                // Check if wildcard capture can be applied.
                // A wildcard doesn't work iff it has reached
                // the end of s.
                if (iS >= s.Length)
                {
                    if (!Backtrack())
                    {
                        return false;
                    }
                }
                else
                {
                    iS++;
                    iP++;
                }
            }
            else // Regular character.
            {
                // Check if regular character can be matched.
                if (iS >= s.Length || s[iS] != patternChar)
                {
                    if (!Backtrack())
                    {
                        return false;
                    }
                }
                else
                {
                    iS++;
                    iP++;
                }
            }
        }

        // The capture must be as long as s.
        return iS == s.Length;


        // Greedy matching can branch off to different
        // possible paths. For example, for
        // "abcdefgdefg", checking for "a.*efg" could
        // either be "abcdefg" or "abcdefgdefg". The
        // The goal is to get the biggest match, so
        // the possibleStates is a Stack (FIFO) where
        // largest captures from that quantifier are
        // checked first.
        //
        // Returns -1 if deemed impossible, 1 if
        // captures entire string, and 0 if should
        // continue anyway.
        sbyte GreedyMatch(char patternChar)
        {
            bool isWildcard = patternChar == '.';

            // A HashSet of characters that can diverge
            // into different possible capture paths.
            // This is because of cases such as ".*a*c",
            // against "bacc". We must check for any
            // occurrences of 'a' or 'c' to push to the
            // stack. Even then, there could be no 'a'
            // in "bacc" and it is instead ".*a*c"
            // against "bcc", which should be true as
            // well.
            HashSet<char> divergeIndicators = [];

            // Get every possible diverge character
            // indicator until it reaches a required
            // non-quantified character.
            int tempIP = iP;
            bool containsWildcard = false;
            while (tempIP < p.Length && p[tempIP - 1] == '*')
            {
                divergeIndicators.Add(p[tempIP]);
                if (p[tempIP] == '.')
                {
                    containsWildcard = true;
                    break;
                }

                tempIP += 2;
            }

            // Go through the rest of the characters in
            // s and push possible states. Note that
            // divergeIndicators can also contain a
            // wildcard '.'
            int tempIS;
            for (tempIS = iS; tempIS < s.Length; tempIS++)
            {
                if (containsWildcard || divergeIndicators.Contains(s[tempIS]))
                {
                    possibleStates.Push((tempIS, iP));
                }

                if (!isWildcard && s[tempIS] != patternChar)
                {
                    break;
                }
            }

            // The pattern segment ends with a completely
            // optional character pattern sequence.
            bool isCompletelyOptional = tempIP >= p.Length && p[^1] == '*';

            // If there are no required diverge indicators
            // and the character selector reached the
            // end of the string, return 1 as the
            // capture is complete.
            if (tempIS >= s.Length && (isCompletelyOptional || divergeIndicators.Count == 0))
            {
                return 1;
            }

            // Go to the largest capture state if
            // possible, otherwise return -1 because
            // the capture is impossible.
            return (sbyte)(Backtrack() ? 0 : -1);
        }

        // If the current state of the capture
        // reaches an impossible match, attempt
        // to go to the next possible state to
        // capture, and return true if possible,
        // otherwise false.
        bool Backtrack()
        {
            if (possibleStates.TryPop(out (int newIS, int newIP) state) is bool result)
            {
                iS = state.newIS;
                iP = state.newIP;
            }

            return result;
        }
    }
}
