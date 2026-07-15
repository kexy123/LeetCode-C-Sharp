// RESULTS:
//      Submitted on 15 July 2026 at 00:04
//
//      203 / 203 testcases passed.
//
//      Runtime:    0 ms
//      Memory:     44.19 MB

namespace Solution.CSharp.BestTimeToBuyAndSellStockII_0122;

public partial class Solution
{
    /// <summary>
    /// Computes the maximum profit that can be achieved
    /// by buying then selling stock in the <paramref name="prices"/>
    /// <see cref="int"/> array, however only being able
    /// to hold one stock at a time.
    /// </summary>
    /// <param name="prices">The <see langword="int"/> array that is the stock's value at those days.</param>
    /// <returns>The maximum profit that can be achieved.</returns>
    public int MaxProfit(int[] prices)
    {
        int lowPoint = prices[0];
        int maxProfit = 0;
        int sumProfit = 0;

        for (int i = 1; i < prices.Length; i++)
        {
            // Check if the stock value dropped.
            if (prices[i] <= prices[i - 1])
            {
                lowPoint = prices[i];

                // Add to sum and reset the max profit.
                sumProfit += maxProfit;
                maxProfit = 0;
            }
            else
            {
                // Stock value increased; compute profit.
                maxProfit = Math.Max(prices[i] - lowPoint, maxProfit);
            }
        }

        // Add the final sum.
        return sumProfit + maxProfit;
    }
}
