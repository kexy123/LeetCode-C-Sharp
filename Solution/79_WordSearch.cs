// RESULTS:
//      Submitted on 09 July 2026 at 19:19
//
//      88 / 88 testcases passed.
//
//      Runtime:    436 ms
//      Memory:     45.63 MB

namespace Solution;

public partial class Solution
{
    /// <summary>
    /// Checks if the given <paramref name="word"/>
    /// exists in the <see cref="char"/> matrix array
    /// <paramref name="board"/>, given that you
    /// can move in all four cardinal directions at
    /// any point to search for <paramref name="word"/>,
    /// but cannot go use the same cell.
    /// </summary>
    /// <param name="board">The <see cref="char"/> matrix array to search in.</param>
    /// <param name="word">The <see cref="string"/> to search for.</param>
    /// <returns><see langword="true"/> if it exists in <paramref name="board"/>; otherwise <see langword="false"/>.</returns>
    public bool Exist(char[][] board, string word)
    {
        int width = board[0].Length;
        int height = board.Length;

        if (word.Length > width * height)
        {
            // The word cannot exist in the
            // matrix as it is too long.
            return false;
        }

        // Prepare the backtrackStack with
        // the positions of the cells that
        // are the first letter in the word.
        // The index item in the tuple
        // represents the current letter it
        // is equal to.
        Stack<(int x, int y, int index)> backtrackStack = [];
        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                if (board[row][col] == word[0])
                {
                    if (word.Length == 1)
                    {
                        // It only needed to find one letter.
                        return true;
                    }

                    backtrackStack.Push((col, row, 0));
                }
            }
        }

        List<(int x, int y)> searched = [];
        while (backtrackStack.Count > 0)
        {
            (int x, int y, int index) = backtrackStack.Pop();

            // Add to the search pool.
            searched.RemoveRange(index, searched.Count - index);
            searched.Add((x, y));
            index++;

            if (TrySearch(x, y - 1, index)  // Up
             || TrySearch(x + 1, y, index)  // RIght
             || TrySearch(x, y + 1, index)  // Down
             || TrySearch(x - 1, y, index)) // Left
            {
                return true;
            }
        }

        return false;


        // Tries to push the possible cell
        // into backtrackStack, and returns
        // true if this cell is the end of
        // the word, signaling to end the
        // search as the word exists in the
        // matrix.
        bool TrySearch(int x, int y, int index)
        {
            // Check if out of bounds.
            if (x < 0 || x >= width || y < 0 || y >= height)
            {
                return false;
            }

            // Check if it is already a
            // searched tile.
            if (searched.Contains((x, y)))
            {
                return false;
            }

            if (board[y][x] == word[index])
            {
                backtrackStack.Push((x, y, index));
                return index + 1 == word.Length;
            }

            return false;
        }
    }
}
