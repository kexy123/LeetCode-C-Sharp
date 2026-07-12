// RESULTS:
//      Submitted on 04 July 2026 at 21:49
//
//      128 / 128 testcases passed.
//
//      Runtime:    32 ms
//      Memory:     66.98 MB
//
// First submission was a frequency counter of
// the strings. However, looking at faster
// solutions, sorting the string as a char array
// seemed to do a quicker job. This is because,
// although frequency-counting the characters
// in a string is O(n), checking the correct
// group to put the entry in is O(n * k) where
// k was the number of groups assigned in the
// array, at worst being O(n^2), as my first
// implementation stored the group's keys as
// its frequency Dictionary. However, sorting
// the string by a char array is O(n log n),
// while searching for the key in a Dictionary
// this way is O(1), making it much quicker.

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Groups all anagrams in <paramref name="strs"/>
    /// together; words that can be rearranged to form
    /// the other letters in its group.
    /// </summary>
    /// <param name="strs">The <see cref="string"/> array to group.</param>
    /// <returns>The <see cref="IList{T}"/> of grouped anagrams.</returns>
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        Dictionary<string, IList<string>> groups = [];

        foreach (string entry in strs)
        {
            // All strings of the same anagram
            // group will always result in the
            // same string when sorted.
            char[] charArray = [.. entry];
            charArray.Sort();
            string result = new(charArray);

            // Add to existing group, otherwise
            // add to new group.
            if (groups.TryGetValue(result, out var group))
            {
                group.Add(entry);
            }
            else
            {
                groups[result] = [entry];
            }
        }

        return [.. groups.Values];
    }
}
