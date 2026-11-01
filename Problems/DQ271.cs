/*
LeetCode daily question #271 https://leetcode.com/problems/encode-and-decode-strings/description/
NeetCode (free): https://neetcode.io/problems/string-encode-and-decode/question
*/

using System.Text;

namespace Problems.DQ271;

public class Solution
{
    public string Encode(IList<string> strs)
    {
        StringBuilder encoded = new StringBuilder();
        foreach (string s in strs)
        {
            encoded.Append($"{s.Length}#{s}");
        }
        return encoded.ToString();
    }

    public List<string> Decode(string s)
    {
        List<string> strs = new List<string>();
        int i = 0;
        while (i < s.Length)
        {
            int nSize = 0;
            while (s[i + nSize] != '#')
            {
                nSize++;
            }
            int size = Int32.Parse(string.Join("", s[i..(i + nSize)]));
            i += nSize + 1;

            strs.Add(s[i..(i + size)]);
            i += size;
        }
        return strs;
    }
}
