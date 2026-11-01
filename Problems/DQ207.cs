/*
LeetCode daily question #207 https://leetcode.com/problems/course-schedule/description/
*/

namespace Problems.DQ207;

public class Solution
{
    // If each course is a node in a graph, if there is a cycle we can't finish the courses. 
    // Check if there's a cycle with topological ordering concept
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
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
        return completed == numCourses;
    }
}