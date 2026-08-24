/*
LeetCode daily question #3016 https://leetcode.com/problems/minimum-number-of-pushes-to-type-word-ii/description/
*/

namespace Problems.DQ3016;

using System.Linq;

public class Solution
{
    public int MinimumPushes(string word)
    {
        int minimumPushes = 0;

        // Get char occurences in word
        Dictionary<char, int> occurences = new Dictionary<char, int>();
        foreach (var c in word.ToCharArray(0, word.Length))
        {
            if (occurences.ContainsKey(c))
            {
                occurences[c]++;
            }
            else
            {
                occurences.Add(c, 1);
            }
        }

        // Order char list (most occurences to least), distribute the chars by the 8 keys and count (CharOccurence*KeyPushes)
        minimumPushes = occurences.OrderByDescending(kvp => kvp.Value)
        .Select((kvp, index) => new { kvp.Value, index })
        .Sum(val => val.Value * (val.index / 8 + 1));

        /*
        // Get char list (most occurences to least)
        List<char> orderedChars = occurences.OrderByDescending(kvp => kvp.Value).Select(kvp => kvp.Key).ToList();

        // In the 8 available keys, distribute the chars one by one and count
        for (int i = 0; i < orderedChars.Count(); i++)
        {
            int keyPushes = i / 8 + 1;
            minimumPushes += occurences[orderedChars[i]] * keyPushes;
        }
        */

        return minimumPushes;
    }
}
