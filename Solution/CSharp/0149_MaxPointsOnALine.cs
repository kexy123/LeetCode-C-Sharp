// RESULTS:
//      Submitted on 29 August 2026 at 10:51
//
//      42 / 42 testcases passed.
//
//      Runtime:    35 ms
//      Memory:     52.52 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Finds the maximum number of points that are colinear to each other.
    /// </summary>
    /// <param name="points">An array of 2-dimensional <see langword="int"/> coordinates.</param>
    /// <returns>The maximum number of points.</returns>
    public int MaxPoints(int[][] points)
    {
        int maxPoints = 0;

        for (int i = 0; i < points.Length; i++)
        {
            int[] centralPoint = points[i];
            (int x, int y) = (centralPoint[0], centralPoint[1]);
            Dictionary<(int x, int y), int> frequency = [];

            for (int j = 0; j < points.Length; j++)
            {
                if (j == i)
                {
                    continue;
                }

                // Consider the centralPoint as the new point of origin. Calculate the difference from
                // this point to that origin.
                (int diffX, int diffY) = (points[j][0] - x, points[j][1] - y);
                if (diffY < 0)
                {
                    // The new point of origin has four quadrants. A line always intersects two of them
                    // or is on the horizontal or vertical boundary of all four. We can ignore
                    // quadrants III and IV (where y < 0) by simply rotating all the points 90 degrees.
                    // This ensures that the frequency Dictionary will account for both sides of
                    // the line. For example, for the points (0, 0), (2, 2), and (-1, -1), simplifying
                    // the points at (0, 0) form (1, 1) and (-1, -1), meaning that only one other point
                    // would be recognized on the line, despite there being a line that passes through
                    // (1, 1) and (-1, -1) and (0, 0) at the same time, so we flip (-1, -1) to form
                    // (1, 1), which will increase its frequency once more in the Dictionary.
                    diffX *= -1;
                    diffY *= -1;
                }

                // Divide the differences by the GCD, making them coprime. Any integer multiple of
                // these coordinates would also fit in the same line.
                int gcd = GreatestCommonDivisor(diffX, diffY);
                diffX /= gcd;
                diffY /= gcd;

                frequency[(diffX, diffY)] = frequency.GetValueOrDefault((diffX, diffY), 0) + 1;
                maxPoints = Math.Max(maxPoints, frequency[(diffX, diffY)]);
            }
        }

        // Note that the frequency Dictionary does not account for the central point, so we add one
        // more point to account for that origin.
        return maxPoints + 1;


        // Computes the greatest common divisor of two integers a and b ignoring their sign.
        static int GreatestCommonDivisor(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            // This is the Euclidean algorithm for finding the greatest common divisor of two
            // positive integers:
            // https://en.wikipedia.org/wiki/Euclidean_algorithm
            while (b > 0)
            {
                // GCD(a, b) = GCD(b, a mod b). We keep reassigning a and b until b is 0, in which case
                // the value of a is the GCD as it could be divided into its previous value.
                (a, b) = (b, a % b);
            }

            return a;
        }
    }
}
