// RESULTS:
//      Submitted on 24 June 2026 at 20:53
//
//      103 / 103 testcases passed.
//
//      Runtime:    2 ms
//      Memory:     42.01 MB

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Checks if a stream of open and closing
    /// parentheses (round brackets, square brackets,
    /// and curly brackets) in <paramref name="s"/>
    /// are malformed or not.
    /// </summary>
    /// <param name="s">The <see cref="string"/> to inspect.</param>
    /// <returns><see langword="true"/> if the brackets are not malformed; otherwise <see langword="false"/>.</returns>
    public bool IsValid(string s)
    {
        Stack<char> parentheses = [];
        foreach (char c in s)
        {
            switch (c)
            {
                // Push the closing bracket
                // to the parentheses.
                case '(':
                    parentheses.Push(')');
                    break;
                case '[':
                    parentheses.Push(']');
                    break;
                case '{':
                    parentheses.Push('}');
                    break;
                default:
                    // Simply check if there are too
                    // many closing parentheses via
                    // Stack<T>.TryPop(out T), or
                    // the popped parenthesis is not
                    // the current closing one.
                    if (!parentheses.TryPop(out char result) || result != c)
                    {
                        return false;
                    }
                    break;
            }
        }

        // If the number of parentheses is
        // unbalanced (too many opening
        // parentheses), check at the end
        // of this method as well by looking
        // at the count of the Stack.
        return parentheses.Count == 0;
    }
}
