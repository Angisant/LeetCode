/*
LeetCode daily question #1807 https://leetcode.com/problems/evaluate-the-bracket-pairs-of-a-string/description/
*/

using System.Text;

namespace Problems.DQ1807;

public class Solution
{
    public string Evaluate(string s, IList<IList<string>> knowledge)
    {
        StringBuilder builder = new StringBuilder();
        Dictionary<string, string> keyValues = knowledge.ToDictionary(k => k[0], k => k[1]);    // Place key-value pairs in dict to ease and speed search
        string currKey = "";
        bool isKey = false;
        foreach (char c in s)
        {
            switch (c)
            {
                case '(':   // Key start
                    isKey = true;
                    break;
                case ')':   // Key end
                    if (keyValues.TryGetValue(currKey, out string value))
                    {
                        builder.Append(value);
                    }
                    else
                    {
                        builder.Append('?');
                    }
                    isKey = false;
                    currKey = "";
                    break;
                default:
                    if (isKey)
                    {
                        currKey += c;
                    }
                    else
                    {
                        builder.Append(c);
                    }
                    break;
            }
        }
        return builder.ToString();
    }
}