/*
LeetCode daily question #242 https://leetcode.com/problems/valid-anagram/description/
*/

namespace Problems.DQ242;

public class Solution
{
    public bool IsAnagram_Frequencies(string s, string t)
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

    public bool IsAnagram_StringCompare(string s, string t)
    {
        if (s.Length != t.Length) return false;

        char[] sArr = s.ToArray(), tArr = t.ToArray();
        Array.Sort(sArr);
        Array.Sort(tArr);
        for (int i = 0; i < s.Length; i++)
        {
            if (sArr[i] != tArr[i]) return false;
        }
        return true;
    }
}
