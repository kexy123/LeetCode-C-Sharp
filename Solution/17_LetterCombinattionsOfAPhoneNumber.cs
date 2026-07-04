// RESULTS:
//      Submitted on 24 June 2026 at 16:20
//
//      24 / 24 testcases passed.
//
//      Runtime:    1 ms
//      Memory:     48.06 MB

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Returns an <see cref="IList{string}"/> of every
    /// possible phone letter combination for each phone
    /// digit in <paramref name="digits"/>.
    /// </summary>
    /// <param name="digits">The sequence of digits.</param>
    /// <returns>The resulting array.</returns>
    /// <exception cref="NotImplementedException"/>
    public IList<string> LetterCombinations(string digits)
    {
        IList<string> result = [];

        foreach (char num in digits)
        {
            // Check which letters are
            // in the given phone digit.
            string letters = num switch
            {
                '2' => "abc",
                '3' => "def",
                '4' => "ghi",
                '5' => "jkl",
                '6' => "mno",
                '7' => "pqrs",
                '8' => "tuv",
                '9' => "wxyz",
                _ => throw new NotImplementedException($"Digit {num} is invalid"),
            };

            result = Extend(letters);
        }

        return result;


        // Returns an array that copies from
        // result and appends its letters,
        // guaranteeing that it has every
        // possible combination for that new
        // digit.
        IList<string> Extend(string letters)
        {
            IList<string> extended = [];
            if (result.Count == 0)
            {
                // If there are zero elements,
                // simply add the letters to
                // the array.
                foreach (char c in letters)
                {
                    extended.Add(c.ToString());
                }
            }
            else
            {
                foreach (char c in letters)
                {
                    foreach (string value in result)
                    {
                        // Append the character to
                        // the value.
                        extended.Add(value + c);
                    }
                }
            }

            return extended;
        }
    }
}
