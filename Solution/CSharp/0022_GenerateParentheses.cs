// RESULTS:
//      Submitted on 25 June 2026 at 00:20
//
//      8 / 8 testcases passed.
//
//      Runtime:    3 ms
//      Memory:     49.99 MB
//
// Used to struggle at this. Thought of a
// recursive approach using a tree, but
// then saw that it was a state backtracking
// and pruning problem.

using System.Text;

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Returns all correctly-formed <see cref="string"/>
    /// for <paramref name="n"/> pairs of parentheses.
    /// </summary>
    /// <param name="n">The number of pairs of parentheses.</param>
    /// <returns>All correct <see cref="string"/> containing <paramref name="n"/> pairs of parentheses.</returns>
    public IList<string> GenerateParenthesis(int n)
    {
        IList<string> results = [];

        // The length of each correct string
        // is double n because it represents
        // how many pairs of parentheses there
        // are.
        int parenthesesLength = n << 1;

        // This is a backtracking approach to
        // creating the parentheses.
        Stack<(int, int, int)> stack = [];

        StringBuilder current = new(new string(')', parenthesesLength));
        current[0] = '(';

        stack.Push((1, 0, 0));
        while (stack.Count > 0)
        {
            (int count, int closing, int startingPoint) = stack.Pop();
            current[startingPoint] = startingPoint++ == 0 ? '(' : ')';

            // Add opening parentheses until
            // it reaches n.
            while (count < n)
            {
                // If a closing parenthesis
                // can be added, add a state
                // to that point.
                if (closing < count)
                {
                    stack.Push((count, closing + 1, startingPoint));
                }

                // Add an opening parenthesis.
                current[startingPoint++] = '(';
                count++;
            }

            // Add closing parentheses to
            // match the length. This will
            // guarantee a correct stream
            // of parentheses.
            while (startingPoint < parenthesesLength)
            {
                current[startingPoint++] = ')';
            }

            results.Add(current.ToString());
        }

        return results;
    }
}
