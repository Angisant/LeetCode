/*
LeetCode daily question #547 https://leetcode.com/problems/number-of-provinces/description/
*/

namespace Problems.DQ547;

public class Solution
{
    public int FindCircleNum(int[][] isConnected)
    {
        int circleNum = 0;
        bool[] visited = new bool[isConnected.Length];

        for (int i = 0; i < isConnected.Length; i++)
        {
            if (!visited[i])
            {
                DFS(i, isConnected, visited);
                circleNum++;
            }
        }
        return circleNum;
    }

    // Visit all nodes directly and indirectly connected
    private void DFS(int idx, int[][] isConnected, bool[] visited)
    {
        visited[idx] = true;
        for (int j = 0; j < isConnected.Length; j++)
        {
            if (isConnected[idx][j] == 1 && !visited[j])
            {
                DFS(j, isConnected, visited);
            }
        }
    }
}