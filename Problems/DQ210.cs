/*
LeetCode daily question #210 https://leetcode.com/problems/course-schedule-ii/description/
*/

namespace Problems.DQ210;

public class Solution
{
    // If each course is a node in a graph, if there is a cycle we can't finish the courses. 
    // Check if there's a cycle with topological ordering concept
    public int[] FindOrder(int numCourses, int[][] prerequisites)
    {
        int[] topOrder = new int[numCourses];
        Dictionary<int, List<int>> coursePr = new Dictionary<int, List<int>>();
        int[] coursesDepends = new int[numCourses];
        foreach (int[] pr in prerequisites)
        {
            if (coursePr.TryGetValue(pr[1], out List<int> crs))
            {
                crs.Add(pr[0]);
            }
            else
            {
                coursePr.Add(pr[1], new List<int> { pr[0] });
            }
            coursesDepends[pr[0]]++;
        }

        Queue<int> noDependCourses = new Queue<int>();
        for (int c = 0; c < numCourses; c++)
        {
            if (coursesDepends[c] == 0)
            {
                noDependCourses.Enqueue(c);
            }
        }

        int completed = 0;
        while (noDependCourses.Count > 0)
        {
            int node = noDependCourses.Dequeue();
            if (completed > numCourses) return [];
            topOrder[completed] = node;
            completed++;

            if (coursePr.TryGetValue(node, out List<int> prs))
            {
                foreach (int pr in prs)
                {
                    coursesDepends[pr]--;

                    if (coursesDepends[pr] == 0) noDependCourses.Enqueue(pr);
                }
            }
        }
        return (completed == numCourses) ? topOrder : [];
    }
}