/*
LeetCode daily question #3310 https://leetcode.com/problems/remove-methods-from-project/description/

Using DFS algorithm as shown in http://www.cs.toronto.edu/~heap/270F02/node36.html
*/

namespace Problems.DQ3310_DFS;

public class Solution
{
    public IList<int> RemainingMethods(int n, int k, int[][] invocations)
    {
        IList<int> remainingMethods = Enumerable.Range(0, n).ToList();
        Dictionary<int, List<int>> directInvocations = new Dictionary<int, List<int>>();

        foreach (int[] invocation in invocations)
        {
            int mainMethod = invocation[0];
            int invokedMethod = invocation[1];

            if (directInvocations.TryGetValue(mainMethod, out List<int> methods))
            {
                methods.Add(invokedMethod);
            }
            else
            {
                directInvocations.Add(mainMethod, new List<int>() { invokedMethod });
            }
        }

        // DFS to find all suspicious methods
        List<int> suspiciousMethods = DFS_Search(n, k, directInvocations);

        // Remove suspicious methods
        remainingMethods = remainingMethods.Except(suspiciousMethods).ToList();

        // Check if any remaining method invokes a suspicious method
        HashSet<int> suspiciousSet = suspiciousMethods.ToHashSet();

        foreach (int m in remainingMethods)
        {
            if (directInvocations.TryGetValue(m, out List<int> directlyInvokedMethods))
            {
                foreach (int invokedMethod in directlyInvokedMethods)
                {
                    if (suspiciousSet.Contains(invokedMethod))
                    {
                        return Enumerable.Range(0, n).ToList();
                    }
                }
            }
        }

        return remainingMethods;
    }

    //DFS(G,v)   ( v is the vertex where the search starts )  
    private List<int> DFS_Search(int n, int v, Dictionary<int, List<int>> nodesMapping)
    {
        Stack<int> stack = new Stack<int>(n);       //   Stack S := {};   ( start with an empty stack )
        bool[] visited = new bool[n];
        List<int> descendants = new List<int>();

        for (int u = 0; u < n; u++)     //   for each vertex u, set visited[u] := false;
        {
            visited[u] = false;
        }

        stack.Push(v);      //   push S, v;

        while (stack.Count > 0)      //   while (S is not empty) do
        {
            int u = stack.Pop();    // u := pop S;
            if (!visited[u])        // if (not visited[u]) then
            {
                visited[u] = true;  // visited[u] := true;
                descendants.Add(u);
                if (nodesMapping.TryGetValue(u, out List<int> methods))
                {
                    foreach (int w in methods)     // for each unvisited neighbour w of u
                    {
                        if (!visited[w])
                        {
                            stack.Push(w);  //  push S, w;
                        }

                    }
                }
            }
        }
        return descendants;
    }
}