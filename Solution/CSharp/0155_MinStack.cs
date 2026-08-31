// RESULTS:
//      Submitted on 1 September 2026 at 10:27
//
//      45 / 45 testcases passed.
//
//      Runtime:    13 ms
//      Memory:     99.82 MB

namespace Solution.CSharp;

public partial class Solution;

/// <summary>
/// A <see cref="Stack{T}"/> of <see langword="int"/> that tracks the minimum value.
/// </summary>
public class MinStack()
{
    /// <summary>
    /// The minimum value in the <see cref="_stack"/>.
    /// </summary>
    private int _minValue = int.MaxValue;

    /// <summary>
    /// The <see cref="Stack{T}"/> of <see langword="int"/> values that stores the lowest
    /// <see langword="int"/> for each entry.
    /// </summary>
    private readonly Stack<(int value, int min)> _stack = [];


    /// <summary>
    /// Pushes a <paramref name="value"/> to the stack.
    /// </summary>
    /// <param name="value">The <see langword="int"/> to push.</param>
    public void Push(int value)
    {
        // Associate the entry with the current _minValue in the stack.
        _stack.Push((value, _minValue));

        // Change _minValue if the current value is lower.
        _minValue = Math.Min(_minValue, value);
    }

    /// <summary>
    /// Pops the first element in the stack.
    /// </summary>
    public void Pop()
    {
        (int _, int min) = _stack.Pop();
        _minValue = min;
    }

    /// <summary>
    /// Peeks at the first element in the stack.
    /// </summary>
    /// <returns>The value of the first element.</returns>
    public int Top()
    {
        return _stack.Peek().value;
    }

    /// <summary>
    /// Gets the lowest value in the stack.
    /// </summary>
    /// <returns>The lowest <see langword="int"/> value in the stack.</returns>
    public int GetMin()
    {
        return _minValue;
    }
}
