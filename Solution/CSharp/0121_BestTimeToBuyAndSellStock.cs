// RESULTS:
//      Submitted on 14 July 2026 at 23:56
//
//      212 / 212 testcases passed.
//
//      Runtime:    1 ms
//      Memory:     61.38 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Computes the maximum profit that can be achieved
    /// by buying then selling stock between two different
    /// days from the <paramref name="prices"/> <see cref="int"/>
    /// array.
    /// </summary>
    /// <param name="prices">The <see langword="int"/> array that is the stock's value at those days.</param>
    /// <returns>The maximum profit that can be achieved.</returns>
    public int MaxProfit(int[] prices)
    {
        int lowPoint = prices[0];
        int maxProfit = 0;

        for (int i = 1; i < prices.Length; i++)
        {
            if (prices[i] <= lowPoint)
            {
                // Change the lowest sell value.
                lowPoint = prices[i];
            }
            else
            {
                // Check if the profit on this day
                // if we bought from the lowest sell
                // value before it is more than the
                // maximum profit.
                maxProfit = Math.Max(prices[i] - lowPoint, maxProfit);
            }
        }

        return maxProfit;
    }
}
