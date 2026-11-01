/*
LeetCode daily question #1254 https://leetcode.com/problems/number-of-closed-islands/description/
*/

namespace Problems.DQ1254;

public class Solution
{
    // Approach: Start by excluding all land not surrounded by water (on the edges of the map)
    // Find a possible island coordinate and explore all adjacent land, marking visited land as water
    // Time: O(n*m)     Space: O(1)
    public int ClosedIsland(int[][] grid)
    {
        int islands = 0;

        // Explore and exclude land on edges
        for (int x = 0; x < grid.Length; x++)
        {
            ExploreIsland(grid, (x, 0));
            ExploreIsland(grid, (x, grid[x].Length - 1));
        }

        for (int y = 0; y < grid[0].Length; y++)
        {
            ExploreIsland(grid, (0, y));
            ExploreIsland(grid, (grid.Length - 1, y));
        }

        // Explore remaining islands
        for (int x = 0; x < grid.Length; x++)
        {
            for (int y = 0; y < grid[x].Length; y++)
            {
                (int, int) coords = (x, y);
                if (grid[x][y] == 0)
                {
                    ExploreIsland(grid, coords);
                    islands++;
                }
            }
        }
        return islands;
    }

    private void ExploreIsland(int[][] grid, (int x, int y) coords)
    {
        if (coords.x < 0 || coords.x >= grid.Length ||
            coords.y < 0 || coords.y >= grid[0].Length ||
            grid[coords.x][coords.y] != 0) return;

        grid[coords.x][coords.y] = 1;   // Change to water so we don't have to count it again

        ExploreIsland(grid, (coords.x - 1, coords.y));
        ExploreIsland(grid, (coords.x + 1, coords.y));
        ExploreIsland(grid, (coords.x, coords.y - 1));
        ExploreIsland(grid, (coords.x, coords.y + 1));
    }
}
