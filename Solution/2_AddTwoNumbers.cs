// RESULTS:
//      Submitted on 21 June 2026 at 22:27
//
//      1569 / 1569 testcases passed.
//
//      Runtime:    1 ms
//      Memory:     53.55 MB

using Solution.LeetCodeImplementations;

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Adds two numbers <paramref name="l1"/> and
    /// <paramref name="l2"/> interpreted as digits in
    /// <see cref="ListNode"/> from least-significant
    /// to most-significant digit.
    /// </summary>
    /// <param name="l1">The first number.</param>
    /// <param name="l2">The second number</param>
    /// <returns>Their sum also interpreted in the same format.</returns>
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode? rootOutput = null;
        ListNode? old = null;
        ListNode? l1Root = l1;
        ListNode? l2Root = l2;

        int carryDigit = 0;
        while (l1Root is not null || l2Root is not null)
        {
            // The quotient is the carry-on digit, and
            // the remainder is the digit to store into
            // the ListNode.
            (carryDigit, int digit) = Math.DivRem(
                (l1Root?.val ?? 0) +     // Add digit from l1.
                (l2Root?.val ?? 0) +     // Add digit from l2.
                carryDigit,              // Add carryDigit.
                10);

            // Move to next significant digit.
            l1Root = l1Root?.next;
            l2Root = l2Root?.next;

            if (old is not null)
            {
                // Set the old and root to the new ListNode.
                old = old.next = new(digit);
            }
            else
            {
                // Set the old.next and old to the new ListNode.
                old = rootOutput = new(digit);
            }
        }

        // The carry digit is guaranteed to only be
        // 1 because of arithmetic properties with
        // only two digits. It is also guaranteed
        // that this carry-on will only exist when
        // there is a ListNode.
        if (carryDigit > 0)
        {
            old!.next = new(1);
        }

        return rootOutput!;
    }
}
