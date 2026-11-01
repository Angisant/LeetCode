/*
LeetCode daily question #36 https://leetcode.com/problems/valid-sudoku/description/
*/

namespace Problems.DQ36;

public class Solution
{
    // Brute Force Approach: Check every row, col and square separately     Time: O(n^2) Space: O(n) if board was nxn
    public bool IsValidSudoku_BruteForce(char[][] board)
    {
        for (int rowColSq = 0; rowColSq < 9; rowColSq++)
        {
            if (GetRowValues(board, rowColSq) == null ||
                GetColValues(board, rowColSq) == null ||
                GetSquareValues(board, rowColSq) == null) return false;

        }
        return true;
    }

    // Hashing Approach: For each element, check their row, col, and square values     Time: O(n^2) Space: O(n^2) if board was nxn
    public bool IsValidSudoku_Hashing(char[][] board)
    {
        HashSet<char>[] rows = new HashSet<char>[9];
        HashSet<char>[] cols = new HashSet<char>[9];
        HashSet<char>[] squares = new HashSet<char>[9];
        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
            {
                char el = board[row][col];

                if (el == '.') continue;

                if (!IsValidValue(el)) return false;

                if (rows[row] != null)
                {
                    if (!rows[row].Add(el)) return false;
                }
                else
                {
                    rows[row] = new HashSet<char> { el };
                }

                if (cols[col] != null)
                {
                    if (!cols[col].Add(el)) return false;
                }
                else
                {
                    cols[col] = new HashSet<char> { el };
                }

                int square = row / 3 * 3 + col / 3;
                if (squares[square] != null)
                {
                    if (!squares[square].Add(el)) return false;
                }
                else
                {
                    squares[square] = new HashSet<char> { el };
                }
            }
        }
        return true;
    }

    private List<char> GetRowValues(char[][] board, int row)
    {
        List<char> vals = new List<char>();
        foreach (char c in board[row])
        {
            if (c == '.') continue;

            if (IsValidValue(c) && !vals.Contains(c))
            {
                vals.Add(c);
            }
            else
            {
                return null;
            }
        }
        return vals;
    }

    private List<char> GetColValues(char[][] board, int col)
    {
        List<char> vals = new List<char>();
        for (int row = 0; row < 9; row++)
        {
            char c = board[row][col];

            if (c == '.') continue;

            if (IsValidValue(c) && !vals.Contains(c))
            {
                vals.Add(c);
            }
            else
            {
                return null;
            }
        }
        return vals;
    }

    private List<char> GetSquareValues(char[][] board, int square)
    {
        List<char> vals = new List<char>();
        for (int row = 0; row < 3; row++)
        {
            int i = square / 3 * 3 + row;
            for (int col = 0; col < 3; col++)
            {
                int j = square % 3 * 3 + col;
                char c = board[i][j];

                if (c == '.') continue;

                if (IsValidValue(c) && !vals.Contains(c))
                {
                    vals.Add(c);
                }
                else
                {
                    return null;
                }
            }
        }
        return vals;
    }

    private bool IsValidValue(char c)
    {
        return Int32.TryParse(c.ToString(), out int sym) && sym >= 1 && sym <= 9;
    }
}