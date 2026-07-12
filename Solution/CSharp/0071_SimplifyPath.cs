// RESULTS:
//      Submitted on 07 July 2026 at 16:19
//
//      264 / 264 testcases passed.
//
//      Runtime:    2 ms
//      Memory:     42.23 MB
//
// My first submission, which included a Stack
// and StringBuilder, was extremely slow
// compared to using a List and joining it via
// string.Join().

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Simplifies the given directory <paramref name="path"/>.
    /// </summary>
    /// <param name="path">The directory <see cref="string"/> to simplify.</param>
    /// <returns>The simplified result.</returns>
    public string SimplifyPath(string path)
    {
        List<string> simplifiedDirectory = [];
        foreach (string dir in path.Split("/"))
        {
            switch (dir)
            {
                case "..":
                    // Escape current folder if possible.
                    if (simplifiedDirectory.Count > 0)
                    {
                        simplifiedDirectory.RemoveAt(simplifiedDirectory.Count - 1);
                    }
                    break;
                case ".":
                case "":
                    // Do nothing; ignore. This handles
                    // directories with multiple forward
                    // slashes and '.' representing the
                    // current directory.
                    break;
                default:
                    // Add folder name.
                    simplifiedDirectory.Add(dir);
                    break;
            }
        }

        // Start the directory with a forward slash.
        return "/" + string.Join("/", simplifiedDirectory);
    }
}
