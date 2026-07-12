// RESULTS:
//      Submitted on 08 July 2026 at 19:01
//
//      268 / 268 testcases passed.
//
//      Runtime:    57 ms
//      Memory:     46.96 MB

namespace Solution.CSharp;

public partial class Solution
{
    /// <summary>
    /// Finds the smallest unique substring in
    /// <paramref name="s"/> that contains all
    /// the characters in <paramref name="t"/>.
    /// </summary>
    /// <param name="s">The <see cref="string"/> to search through.</param>
    /// <param name="t">The characters to contain. Can contain duplicates which are considered.</param>
    /// <returns>The shortest substring. If no substring was found, returns an empty <see cref="string"/>.</returns>
    public string MinWindow(string s, string t)
    {
        // Prepare a frequency table counting
        // the characters in t. Note that this
        // frequency table will be modified and
        // some characters can go negative to
        // indicate leftover characters that can
        // be removed when trimming.
        Dictionary<char, int> frequency = [];
        foreach (char c in t)
        {
            frequency[c] = frequency.GetValueOrDefault(c, 0) + 1;
        }

        // Sliding window loop.
        int shortestLeft = 0, shortestLength = int.MaxValue;
        int left = -1;
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (!frequency.ContainsKey(c))
            {
                continue;
            }

            // Prepare the left pointer
            // to the first character
            // of the substring.
            if (left < 0)
            {
                left = i;
            }

            // Evaluate IsContainingAllLetters if
            // the frequency of the current character
            // has reached 0 or negative.
            if (--frequency[c] <= 0 && IsContainingAllLetters())
            {
                TrimLeft();
                if (i - left < shortestLength)
                {
                    // Set the new shortest length.
                    shortestLeft = left;
                    shortestLength = i - left;
                }
            }
        }

        // Check if the shortestLength did not
        // change at all, otherwise get the
        // substring from s.
        return shortestLength == int.MaxValue ? "" : s.Substring(shortestLeft, shortestLength + 1);


        // Checks if the frequency table of
        // the characters in t have all been
        // subtracted in the substring of
        // s.
        bool IsContainingAllLetters()
        {
            foreach (var entry in frequency)
            {
                if (entry.Value > 0)
                {
                    return false;
                }
            }

            return true;
        }

        // Moves the left pointer until it
        // finds a character that is required
        // to be in the substring as it will
        // increase its character in the
        // frequency table.
        void TrimLeft()
        {
            while (true)
            {
                char c = s[left];
                if (frequency.TryGetValue(c, out int value))
                {
                    if (value >= 0)
                    {
                        // Character must exist in the
                        // substring, so end the trim here.
                        return;
                    }

                    // Remove the letter from the substring.
                    frequency[c]++;
                }

                left++;
            }
        }
    }
}
