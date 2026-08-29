// RESULTS:
//      Submitted on 29 August 2026 at 11:14
//
//      23 / 23 testcases passed.
//
//      Runtime:    5 ms
//      Memory:     44.80 MB
//
// I have done this many times before on projects such as a calculator. This is how stack-oriented
// programming works: https://en.wikipedia.org/wiki/Stack-oriented_programming

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Evaluates the given <see href="https://en.wikipedia.org/wiki/Reverse_Polish_notation">Reverse
    /// Polish notation</see> array of <paramref name="tokens"/> with addition, subtraction,
    /// multiplication, and division defined for <see langword="int"/> values.
    /// </summary>
    /// <param name="tokens">The array of tokens.</param>
    /// <returns>The computed result.</returns>
    public int EvalRPN(string[] tokens)
    {
        Stack<int> values = [];
        foreach (string token in tokens)
        {
            switch (token)
            {
                case "+":
                    // Pop the last two values in the stack, then push its result back in.
                    values.Push(values.Pop() + values.Pop());
                    break;
                case "*":
                    values.Push(values.Pop() * values.Pop());
                    break;
                case "-":
                    // For a sequence [A, B, -], the stack is [B, A], where B is pushed out first,
                    // despite the operation having to be A - B, so simply insert an addition operator
                    // A + (-B) and rearrange it to form -B + A.
                    values.Push(-values.Pop() + values.Pop());
                    break;
                case "/":
                    // Ditto to subtraction, but integer division is not invertible, so 1 / B * A does
                    // not work. Variables are required for this operation.
                    int denominator = values.Pop(), numerator = values.Pop();
                    values.Push(numerator / denominator);
                    break;
                default:
                    values.Push(int.Parse(token));
                    break;
            }
        }

        // The first value in the Stack is the computed result.
        return values.Pop();
    }
}
