// RESULTS:
//      Submitted on 17 August 2026 at 19:32
//
//      1006 / 1006 testcases passed.
//
//      Runtime:    3 ms
//      Memory:     57.70 MB
//
// This question was difficult to configure due to the dependency of the columns.

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Computes the minimum number of candies to give to a line of children with a
    /// rating in the <paramref name="ratings"/> array, such that every child gets
    /// at least one candy, and children get more candies than their neighbors with
    /// lower ratings.
    /// </summary>
    /// <param name="ratings">The ratings <see langword="int"/> array.</param>
    /// <returns>The minimum number of candies that can be distributed.</returns>
    public int Candy(int[] ratings)
    {
        int currentColumn = 1;
        int sum = currentColumn;

        int partitionIndex = 0, partitionColumnLimit = int.MaxValue, partitionStartingColumn = 1;
        for (int i = 1; i < ratings.Length; i++)
        {
            switch (ratings[i] - ratings[i - 1])
            {
                case > 0:
                    // This rating is higher than the previous. It is guaranteed that the
                    // segment from 0..(i - 1) is complete and doesn't need any more candies,
                    // explaining why the partitionColumnLimit is int.MaxValue.
                    partitionIndex = i;
                    partitionColumnLimit = int.MaxValue;

                    currentColumn++;
                    break;
                case 0:
                    // Ditto to case > 0.
                    partitionIndex = i;
                    partitionColumnLimit = int.MaxValue;

                    partitionStartingColumn = currentColumn = 1;
                    break;
                case < 0:
                    if (currentColumn is 1)
                    {
                        // Each child must have one candy, so the currentColumn can never exceed
                        // below 1. That means that we have to perform an extension of an extra
                        // candy on the children before this child as minimally as possible while
                        // also keeping the rating rules consistent. Below are two cases where
                        // minimal extension gets complicated:
                        //
                        // A (1):   #
                        // B (2):   ##
                        // C (4):   ###
                        // D (3):   ##
                        // E (2):   #
                        // F (1):
                        //
                        //      F must have at least one candy, but E must have more candies than
                        //      F, therefore we give E an extra candy, but that also cascades to
                        //      D, which cascades to C. Note that the child before C has a lower
                        //      rating so we can stop at this point.
                        //
                        // A (1):   #
                        // B (2):   ##
                        // C (4):   ###
                        // D (3):   #
                        // E (2):
                        // F (1):
                        //
                        //      Here, E needs at least one candy, but D must have more candies than
                        //      E, so we give D an extra candy. However, we don't cascade to C as
                        //      it satisfies the rules for now. Note that when we reached D we
                        //      simply didn't subtract 1 from C to give D two candies to begin with.
                        //      We gave D only 1 candy. We can consider this a partition that starts
                        //      at D. However, in case 1, the partition from D..F exceeded C, so we
                        //      only had to increase by one more, and we don't have to cascade any
                        //      further.

                        partitionStartingColumn++;
                        if (partitionStartingColumn >= partitionColumnLimit)
                        {
                            // Acknowledge the cascade overflow and add one more candy.
                            partitionIndex--;
                            partitionColumnLimit = int.MaxValue;
                        }

                        sum += i - partitionIndex;
                    }
                    else
                    {
                        // Start a new partition.
                        partitionIndex = i;
                        partitionColumnLimit = currentColumn;
                        partitionStartingColumn = currentColumn = 1;
                    }

                    break;
            }

            sum += currentColumn;
        }

        return sum;
    }
}
