// RESULTS:
//      Submitted on 28 June 2026 at 12:48
//
//      235 / 235 testcases passed.
//
//      Runtime:    5 ms
//      Memory:     42.01 MB

public partial class Solution
{
    /// <summary>
    /// Finds the longest substring of a valid
    /// sequence of open and closing parentheses.
    /// </summary>
    /// <param name="s">The <see cref="string"/> to inspect.</param>
    /// <returns>The length of the longest valid substring.</returns>
    public int LongestValidParentheses(string s)
    {
        // Trim any starting closing parentheses ')'
        // as they can never form a valid sequence.
        int left = 0;
        TruncateLeft(ref left);

        // Ditto to the first loop, but for the
        // end, trimming ending opening parentheses.
        int right = s.Length - 1;
        while (right >= 0 && s[right] != ')')
        {
            right--;
        }

        int length = right - left + 1;

        // Check if s contains only open or closing
        // parentheses, not both. Additionally, check
        // if the length is less than 2, which can
        // never form a valid sequence of parentheses.
        if (left >= s.Length || right < 0 || length < 2)
        {
            return 0;
        }

        // A stack of indices and the last net
        // of parentheses at that point. 
        Stack<(int index, int lastNet)> increasingBalance = [];

        // The net parentheses in the stream.
        int netAmount = 0;
        int longest = 0;
        int maxBalance = -1;
        for (int i = left; i <= right; i++)
        {
            if (s[i] == '(')
            {
                netAmount++;
                // This is to prevent elements from
                // increasingBalance from being discarded
                // by other elements with the same
                // netAmount.
                if (netAmount > maxBalance)
                {
                    maxBalance = netAmount;
                    increasingBalance.Push((i, netAmount));
                }
            }
            else // if (s[i] == ')')
            {
                netAmount--;

                if (netAmount < 0)
                {
                    // The pointer i reached an invalid
                    // stream of closing parentheses ')'
                    // that cannot form a pair, so skip
                    // all of them until it reaches an
                    // open parentheses '(' and reset
                    // appropriate variables.
                    increasingBalance.Clear();
                    TruncateLeft(ref i);
                    i--;

                    maxBalance = -1;
                    netAmount = 0;
                }
                else
                {
                    bool peeked = increasingBalance.TryPeek(out var result);
                    // Check if lastBalance of the first element
                    // in the Stack overshoots the netAmount.
                    // If so, we discard that element.
                    if (peeked && result.lastNet > netAmount + 1)
                    {
                        maxBalance--;
                        increasingBalance.Pop();
                        peeked = increasingBalance.TryPeek(out result);
                    }

                    // Check if the difference between now
                    // and the last point of the same net
                    // parentheses is longer than the longest
                    // capture found so far.
                    if (peeked && i - result.index > longest)
                    {
                        // Note that i - result.index is one
                        // off from the actual substring length.
                        longest = i - result.index;
                    }
                }
            }
        }

        return longest + 1;


        // Move the left pointer i until it
        // finds an open parenthesis '('.
        void TruncateLeft(ref int i)
        {
            while (i < s.Length && s[i] != '(')
            {
                i++;
            }
        }
    }
}
