using System.Diagnostics;

namespace Solution.CSharp;

internal class Program
{
    public static void Main(string[] args)
    {
        Solution p = new();

        Stopwatch stopwatch = Stopwatch.StartNew();
        stopwatch.Start();


        // ENTER p Solution test cases.
        Console.WriteLine();


        stopwatch.Stop();
        Console.WriteLine($"""
            Time elapsed:
                {stopwatch.Elapsed.TotalNanoseconds} ns
                ({stopwatch.ElapsedMilliseconds} ms)
            """);
    }
}
