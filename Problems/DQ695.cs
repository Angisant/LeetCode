/*
LeetCode daily question #695 https://leetcode.com/problems/max-area-of-island/description/
*/

namespace Problems.DQ695;

public class Solution
{
    // USE DFS
    public int MaxAreaOfIsland(int[][] grid)
    {
        int maxArea = 0, m = grid.Length, n = grid[0].Length;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 1)
                {
                    // Check for connected islands 
                    HashSet<(int, int)> adjs = new HashSet<(int, int)>();
                    GetAllConnectedIslands(grid, i, j, adjs);

                    if (adjs.Count > maxArea)
                    {
                        maxArea = adjs.Count;
                    }

                    foreach ((int, int) a in adjs)
                    {
                        grid[a.Item1][a.Item2] = 0; // mark as seen
                    }
                }
            }
        }
        return maxArea;
    }

    public void GetAllConnectedIslands(int[][] grid, int i, int j, HashSet<(int, int)> adjs)
    {
        if (grid[i][j] != 1 || adjs.Contains((i, j))) return;

        adjs.Add((i, j));

        if (0 < i && grid[i - 1][j] == 1)   // UP
        {
            GetAllConnectedIslands(grid, i - 1, j, adjs);
        }
        if (0 < j && grid[i][j - 1] == 1)   // LEFT
        {
            GetAllConnectedIslands(grid, i, j - 1, adjs);
        }
        if (i < grid.Length - 1 && grid[i + 1][j] == 1)   // DOWN
        {
            GetAllConnectedIslands(grid, i + 1, j, adjs);
        }
        if (j < grid[0].Length - 1 && grid[i][j + 1] == 1)   // RIGHT
        {
            GetAllConnectedIslands(grid, i, j + 1, adjs);
        }
    }
}