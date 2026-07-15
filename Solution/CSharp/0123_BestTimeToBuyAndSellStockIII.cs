// RESULTS:
//      Submitted on 16 July 2026 at 10:01
//
//      214 / 214 testcases passed.
//
//      Runtime:    2 ms
//      Memory:     62.38 MB
//
// Unfortunately had to look up a solution as grasping the
// problem was difficult for me.

namespace Solution.CSharp.BestTimeToBuyAndSellStockIII_0123;

public partial class Solution
{
    /// <summary>
    /// Computes the maximum profit that can be achieved
    /// by buying then selling stock in the <paramref name="prices"/>
    /// <see cref="int"/> array at most twice, however
    /// only being able to hold one stock at a time.
    /// </summary>
    /// <param name="prices">The <see langword="int"/> array that is the stock's value at those days.</param>
    /// <returns>The maximum profit that can be achieved.</returns>
    public int MaxProfit(int[] prices)
    {
        int maxBuy0 = int.MinValue, maxSell0 = 0;
        int maxBuy1 = int.MinValue, maxSell1 = 0;

        foreach (int price in prices)
        {
            // Find the smallest element in the array.
            maxBuy0 = Math.Max(maxBuy0, -price);

            // Find the biggest element to the right of
            // where maxBuy0 was such that it can find
            // the biggest profit for the first sell
            // transaction.
            maxSell0 = Math.Max(maxSell0, maxBuy0 + price);

            // Find the element of the lowest cost.
            maxBuy1 = Math.Max(maxBuy1, maxSell0 - price);

            // Ditto to maxSell0.
            maxSell1 = Math.Max(maxSell1, maxBuy1 + price);
        }

        // If no possible profit can be made,
        // simply return 0.
        return Math.Max(0, maxSell1);
    }
}
