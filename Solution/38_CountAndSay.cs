// RESULTS:
//      Submitted on 02 July 2026 at 01:24
//
//      30 / 30 testcases passed.
//
//      Runtime:    10 ms
//      Memory:     44.43 MB
//
// This question is designed where the
// simplest solution would be a recursive
// method, with the follow-up question
// asking for an iterative approach.

using System.Text;

public partial class Solution
{
    /// <summary>
    /// Repetitively performs run-length encoding on
    /// the base string <c>"1"</c> <paramref name="n"/>
    /// times.
    /// </summary>
    /// <param name="n">A positive <see cref="int"/> value that determines how many times to encode.</param>
    /// <returns>The resulting <see cref="string"/>.</returns>
    public string CountAndSay(int n)
    {
        string result = "1";

        // Skip the base case, as result is
        // already the base case.
        for (int i = 1; i < n; i++)
        {
            StringBuilder iterated = new("");

            // Perform run-length encoding on
            // iterated.
            int count = 0;
            char unique = result[0];
            foreach (char c in result)
            {
                if (c == unique)
                {
                    count++;
                }
                else
                {
                    // Reset counter, append count
                    // and unique character to
                    // run-length encoding string.
                    iterated.Append(count);
                    iterated.Append(unique);
                    count = 1;
                    unique = c;
                }
            }
            iterated.Append(count);
            iterated.Append(unique);

            result = iterated.ToString();
        }

        return result;
    }
}
