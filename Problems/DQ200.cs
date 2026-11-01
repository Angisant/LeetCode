/*
LeetCode daily question #200 https://leetcode.com/problems/number-of-islands/description/
*/

namespace Problems.DQ200;

public class Solution
{
    // USE DFS TO CHECK CONNECTED ISLANDS
    public int NumIslands(char[][] grid)
    {
        int numsIslands = 0, m = grid.Length, n = grid[0].Length;
        int[][] islands = new int[m][];
        for (int i = 0; i < m; i++) islands[i] = new int[n];

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == '1' && islands[i][j] == 0)
                {
                    // Check for connected islands 
                    HashSet<(int, int)> adjs = new HashSet<(int, int)>();
                    GetAllConnectedIslands(grid, i, j, adjs);

                    int id = ++numsIslands;
                    foreach ((int, int) a in adjs)
                    {
                        islands[a.Item1][a.Item2] = id;
                    }
                }
            }
        }
        return numsIslands;
    }

    public void GetAllConnectedIslands(char[][] grid, int i, int j, HashSet<(int, int)> adjs)
    {
        if (grid[i][j] != '1' || adjs.Contains((i, j))) return;

        adjs.Add((i, j));

        if (0 < i && grid[i - 1][j] == '1')   // UP
        {
            GetAllConnectedIslands(grid, i - 1, j, adjs);
        }
        if (0 < j && grid[i][j - 1] == '1')   // LEFT
        {
            GetAllConnectedIslands(grid, i, j - 1, adjs);
        }
        if (i < grid.Length - 1 && grid[i + 1][j] == '1')   // DOWN
        {
            GetAllConnectedIslands(grid, i + 1, j, adjs);
        }
        if (j < grid[0].Length - 1 && grid[i][j + 1] == '1')   // RIGHT
        {
            GetAllConnectedIslands(grid, i, j + 1, adjs);
        }
    }
}