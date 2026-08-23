// RESULTS:
//      Submitted on 22 August 2026 at 21:51
//
//      15 / 15 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     43.93 MB
//
// Looked up an O(n) solution, but I created an explanation to the solution's bit manipulation.

namespace Solution.CSharp.SingleNumberII_0137;

public partial class Solution
{
    /// <summary>
    /// Finds the only number that doesn't have a triplicate in <paramref name="nums"/>.
    /// </summary>
    /// <param name="nums">The array to inspect, where every other number has exactly two more copies.</param>
    /// <returns>The number that has no triplicate.</returns>
    public int SingleNumber(int[] nums)
    {
        int ones = 0, twos = 0;
        foreach (int num in nums)
        {
            // Similar to 0136_SingleNumber, but now we need to find an operation (or combined group of
            // operations) whose abelian group has an exponent of 3, i.e. for a defined operation '*',
            // a * a * a = 0. It should also be associative and commutative. This operation is addition
            // modulo 3, however we don't apply this to the integers themselves, as it will only yield
            // a number between 0 to 2.
            //
            // Int32 contains 32 bits. If each bit individually became ternary (a trit), they could
            // accept the digit 2 as well instead of just 0 and 1. Because the nums array contains
            // triplicates, they contain exactly three copies of the same bit-sets:
            //  5 = 0b 00000000 00000000 00000000 00000101
            //  5 = 0b 00000000 00000000 00000000 00000101
            //  5 = 0b 00000000 00000000 00000000 00000101
            //
            // Therefore if each bit was added to a sequence of 32 trits at the same digit positions
            // three times, those trits would be set back to 0. The only number that does not have two
            // copies is then the one that gets extracted from this sequence in binary form. Therefore
            // addition modulo 3 to each trit-set is part of an abelian group with an exponent of 3,
            // while also being associative and commutative.
            //
            // We can use an array of 32 trit-sets, but addition modulo 3 can be mimicked by bitwise
            // operations on two int variables. Each trit can be represented as two bits, which the
            // ones and twos variables show:
            //  ones = 0b 00000000 00000000 00000000 00001100
            //  twos = 0b 00000000 00000000 00000000 00001010
            //                                          03210
            //
            // We always XOR the bits of ones and twos to the num. The AND operation applied against
            // each other's complements ensures that the ones and twos form the successor trit, going
            // back to 0 if it is at 3:
            //  7 = 0b 00000111 -> ones = 0b 00000111 & ~twos = 0b 00000111 // Adds 1 to each trit, but
            //                     twos = 0b 00000111 & ~ones = 0b 00000000 // not the twos.
            //
            //  7 = 0b 00000111 -> ones = 0b 00000000 & ~twos = 0b 00000000 // The ones are 0 but the
            //                     twos = 0b 00000111 & ~ones = 0b 00000111 // twos now carry the 1s.
            //
            //  7 = 0b 00000111 -> ones = 0b 00000111 & ~twos = 0b 00000000 // Now both the ones and
            //                  -> twos = 0b 00000000 & ~ones = 0b 00000000 // twos are 0.

            ones ^= num;
            ones &= ~twos;

            twos ^= num;
            twos &= ~ones;
        }

        return ones;
    }
}
