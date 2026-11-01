/*
LeetCode daily question #49 https://leetcode.com/problems/group-anagrams/description/
*/

namespace Problems.DQ49;

public class Solution
{
    // Faster approach than frequency count
    public IList<IList<string>> GroupAnagrams_StringCompare(string[] strs)
    {
        IList<IList<string>> res = new List<IList<string>>();
        List<string> ordStrs = new List<string>();
        foreach (string s in strs)
        {
            char[] sArr = s.ToArray();
            Array.Sort(sArr);
            ordStrs.Add(new string(sArr));
        }

        var anGroups = ordStrs.Select((s, i) => new { Idx = i, Val = s }).GroupBy(e => e.Val);
        foreach (var anGroup in anGroups)
        {
            List<string> group = new List<string>();
            foreach (int idx in anGroup.Select(e => e.Idx))
            {
                group.Add(strs[idx]);
            }
            res.Add(group);
        }
        return res;
    }

    public IList<IList<string>> GroupAnagrams_Frequencies(string[] strs)
    {
        Dictionary<string, IList<string>> anGroups = new Dictionary<string, IList<string>>();
        foreach (string s in strs)
        {
            bool hasAnagram = false;
            foreach (string t in anGroups.Keys)
            {
                if (IsAnagram_Frequencies(s, t))
                {
                    anGroups[t].Add(s);
                    hasAnagram = true;
                    break;
                }
            }

            if (!hasAnagram)
            {
                anGroups.Add(s, new List<string> { s });
            }
        }

        return anGroups.Values.ToList();
    }

    private bool IsAnagram_Frequencies(string s, string t)
    {
        Dictionary<char, int> freqs = new Dictionary<char, int>();
        foreach (char c in s)
        {
            if (freqs.ContainsKey(c))
            {
                freqs[c]++;
            }
            else
            {
                freqs.Add(c, 1);
            }
        }

        foreach (char c in t)
        {
            if (freqs.TryGetValue(c, out int freq) && freq > 0)
            {
                freqs[c]--;
            }
            else
            {
                return false;
            }
        }
        return freqs.Values.All(f => f == 0);
    }
}
