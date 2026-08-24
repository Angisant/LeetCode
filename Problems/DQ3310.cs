/*
LeetCode daily question #3310 https://leetcode.com/problems/remove-methods-from-project/description/
*/

namespace Problems.DQ3310;

public class Solution
{
    public IList<int> RemainingMethods(int n, int k, int[][] invocations)
    {
        IList<int> remainingMethods = Enumerable.Range(0, n).ToList();
        List<int> suspiciousMethods = new List<int>() { k };
        List<int> verifiedSuspiciousMethods = new List<int>() { k };
        Dictionary<int, List<int>> directInvocations = new Dictionary<int, List<int>>();

        foreach (int[] invocation in invocations)
        {
            int mainMethod = invocation[0], invokedMethod = invocation[1];
            if (directInvocations.TryGetValue(mainMethod, out List<int> methods))
            {
                methods.Add(invokedMethod);
            }
            else
            {
                directInvocations.Add(mainMethod, new List<int>() { invokedMethod });
            }

            if (mainMethod == k)
            {
                suspiciousMethods.Add(invokedMethod);   // Add direct suspicious invocations
            }
        }

        while (!suspiciousMethods.ToHashSet().SetEquals(verifiedSuspiciousMethods))
        {
            foreach (int m in suspiciousMethods)
            {
                List<int> directlyInvokedMethods = GetDirectlyInvokedMethods(m, directInvocations);
                if (directlyInvokedMethods != null)
                {
                    suspiciousMethods = suspiciousMethods.Union(directlyInvokedMethods).ToList();
                }
                verifiedSuspiciousMethods.Add(m);
            }
        }
        remainingMethods = remainingMethods.Except(verifiedSuspiciousMethods).ToList();

        // check if remaining methods summon any verifiedsuspiciousmethods. if so, return all methods
        foreach (int m in remainingMethods)
        {
            List<int> directlyInvokedMethods = GetDirectlyInvokedMethods(m, directInvocations);
            if (directlyInvokedMethods != null)
            {
                List<int> directlyInvokedSuspiciousMethods = directlyInvokedMethods.Intersect(verifiedSuspiciousMethods).ToList();
                if (directlyInvokedSuspiciousMethods.Count > 0)
                {
                    return remainingMethods.Union(verifiedSuspiciousMethods).ToList(); // return all methods
                }
            }
        }
        return remainingMethods;
    }

    private List<int> GetDirectlyInvokedMethods(int m, Dictionary<int, List<int>> directInvocations)
    {
        directInvocations.TryGetValue(m, out List<int> directlyInvokedMethods);
        return directlyInvokedMethods;
    }
}